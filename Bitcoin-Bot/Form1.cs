using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Bitcoin_Bot
{
    public partial class Form1 : Form
    {
        static readonly Uri endpointUri = new Uri("https://api.bitflyer.com");

        //GetCurrentBtcFxPrice() で受け取るレスポンスの型を定義
        public class JsonTicker
        {
            public string product_code { get; set; }
            public string state { get; set; }
            public DateTime timestamp { get; set; }
            public int tick_id { get; set; }
            public double best_bid { get; set; }
            public double best_ask { get; set; }
            public double best_bid_size { get; set; }
            public double best_ask_size { get; set; }
            public double total_bid_depth { get; set; }
            public double total_ask_depth { get; set; }
            public double market_bid_size { get; set; }
            public double market_ask_size { get; set; }
            public double ltp { get; set; }
            public double volume { get; set; }
            public double volume_by_product { get; set; }
        }

        ///v1/me/sendchildorder で受け取るレスポンスの型を定義
        public class JsonSendChildOrder
        {
            public string child_order_acceptance_id;
        }

        ///v1/me/getchildorders
        public class JsonGetChildOrders
        {
            public double id { get; set; }
            public string child_order_id { get; set; }
            public string product_code { get; set; }
            public string side { get; set; }
            public string child_order_type { get; set; }
            public double price { get; set; }
            public double average_price { get; set; }
            public double size { get; set; }
            public string child_order_state { get; set; }
            public DateTime expire_date { get; set; }
            public DateTime child_order_date { get; set; }
            public string child_order_acceptance_id { get; set; }
            public double outstanding_size { get; set; }
            public double cancel_size { get; set; }
            public double executed_size { get; set; }
            public double total_commission { get; set; }
        }

        //最終取引価格を TextBox に出力する
        public async Task GetCurrentBtcFxPrice()
        {
            while (true)
            {
                var method = "GET";
                var path = "/v1/ticker";
                var query = "?product_code=FX_BTC_JPY";

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(new HttpMethod(method), path + query))
                {
                    client.BaseAddress = endpointUri;
                    var message = await client.SendAsync(request);
                    var response = await message.Content.ReadAsStringAsync();

                    var DesirializedResponse = JsonConvert.DeserializeObject<JsonTicker>(response);
                    var CurrentPrice = String.Format("{0:#,0}", DesirializedResponse.ltp);
                    textBoxPrice.Text = CurrentPrice;
                }
                await Task.Delay(1000);
            }
        }

        static readonly string apiKey = "{{ YOUR API KEY }}";
        static readonly string apiSecret = "{{ YOUR API SECRET }}";

        //成行注文を入れる
        //  Param:
        //  sSide: "BUY" か "SELL"
        //  iSize: 枚数
        public async Task<string> MakeMarketOrder(string sSide, double iSize)
        {
            var method = "POST";
            var path = "/v1/me/sendchildorder";
            var query = "";
            var body = @"{
                        ""product_code"": ""FX_BTC_JPY"",
                        ""child_order_type"": ""MARKET"",
                        ""side"": """ + sSide + @""", 
                        ""price"": 0,
                        ""size"": " + numericUpDownMarketOrder.Value + @",  
                        ""minute_to_expire"": 43200,
                        ""time_in_force"": ""GTC""
                        }";
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(new HttpMethod(method), path + query))
            using (var content = new StringContent(body))
            {
                client.BaseAddress = endpointUri;
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = content;
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
                var data = timestamp + method + path + query + body;
                var hash = SignWithHMACSHA256(data, apiSecret);
                request.Headers.Add("ACCESS-KEY", apiKey);
                request.Headers.Add("ACCESS-TIMESTAMP", timestamp);
                request.Headers.Add("ACCESS-SIGN", hash);
                var message = await client.SendAsync(request);
                var response = await message.Content.ReadAsStringAsync();
                if (response == "[]")
                {
                    Console.WriteLine("Error: MakeMarketOrder() returning ERROR_NO_RESPONSE");
                    return "ERROR_NO_RESPONSE";
                }

                return response;
            }
        }

        public async Task<string> GetOrderInformationWithID(string ChildOrderAcceptanceID)
        {
            var method = "GET";
            var path = "/v1/me/getchildorders";
            var query = "?product_code=FX_BTC_JPY&child_order_acceptance_id=" + ChildOrderAcceptanceID;

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(new HttpMethod(method), path + query))
            {
                client.BaseAddress = endpointUri;
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
                var data = timestamp + method + path + query;
                var hash = SignWithHMACSHA256(data, apiSecret);
                request.Headers.Add("ACCESS-KEY", apiKey);
                request.Headers.Add("ACCESS-TIMESTAMP", timestamp);
                request.Headers.Add("ACCESS-SIGN", hash);
                var message = await client.SendAsync(request);
                var response = await message.Content.ReadAsStringAsync();

                if (response == "[]")
                {
                    Console.WriteLine("GetOrderInformationWithID():OUT returning ERROR_NO_RESPONSE");
                    return "ERROR_NO_RESPONSE";
                }
                return response;
            }
        }

        static string SignWithHMACSHA256(string data, string secret)
        {
            using (var encoder = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                var hash = encoder.ComputeHash(Encoding.UTF8.GetBytes(data));
                return ToHexString(hash);
            }
        }

        static string ToHexString(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }


        public Form1()
        {
            InitializeComponent();
            Task JobUpdatePrice = GetCurrentBtcFxPrice(); //最終取引価格更新処理
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonMarketOrder_Click(object sender, EventArgs e)
        {
            Task job1 = RunThisWhenButtonMarketOrderIsClicked();
        }

        public async Task RunThisWhenButtonMarketOrderIsClicked()
        {
            textBox1.AppendText("MakeMarketOrder() Start." + System.Environment.NewLine);

            string ResponseMakeMarketOrder = await MakeMarketOrder("BUY", (double)numericUpDownMarketOrder.Value);
            var DesirializedResponse = JsonConvert.DeserializeObject<JsonSendChildOrder>(ResponseMakeMarketOrder);
            var ChildOrderAcceptanceID = DesirializedResponse.child_order_acceptance_id;

            textBox1.AppendText("MakeMarketOrder() succeeded with ID: " + ChildOrderAcceptanceID + System.Environment.NewLine);
        }

        private void buttonCheckOrderFromID_Click(object sender, EventArgs e)
        {
            Task Job1 = RunThisWhenButtonCheckOrderFromIDIsClicked();
        }
        public async Task RunThisWhenButtonCheckOrderFromIDIsClicked()
        {
            //注文 ID の情報を取得。早すぎるとエラーになるのでその場合には再チャレンジ
            string ResponseGetOrderInformationWithID = await GetOrderInformationWithID(textBoxCheckOrderFromID.Text);
            for (int i = 0; (ResponseGetOrderInformationWithID == "ERROR_NO_RESPONSE") && (i < 100); i++)
            {
                textBox1.AppendText("Waiting for response. Re-check in 10sec.");
                await Task.Delay(10000);
                ResponseGetOrderInformationWithID = await GetOrderInformationWithID(textBoxCheckOrderFromID.Text);
            }

            //レスポンス (JsonGetChildOrders) を表示。
            var DesirializedResponse = JsonConvert.DeserializeObject<JsonGetChildOrders>(ResponseGetOrderInformationWithID.Substring(1, ResponseGetOrderInformationWithID.Length - 2));
            textBox1.AppendText("GetOrderInformationWithID succeeded for ID: " + textBoxCheckOrderFromID.Text + System.Environment.NewLine);
            textBox1.AppendText("  id: " + DesirializedResponse.id + System.Environment.NewLine);
            textBox1.AppendText("  child_order_id: " + DesirializedResponse.child_order_id + System.Environment.NewLine);
            textBox1.AppendText("  product_code: " + DesirializedResponse.product_code + System.Environment.NewLine);
            textBox1.AppendText("  side: " + DesirializedResponse.side + System.Environment.NewLine);
            textBox1.AppendText("  child_order_type: " + DesirializedResponse.child_order_type + System.Environment.NewLine);
            textBox1.AppendText("  price: " + DesirializedResponse.price + System.Environment.NewLine);
            textBox1.AppendText("  average_price: " + DesirializedResponse.average_price + System.Environment.NewLine);
            textBox1.AppendText("  size: " + DesirializedResponse.size + System.Environment.NewLine);
            textBox1.AppendText("  child_order_state: " + DesirializedResponse.child_order_state + System.Environment.NewLine);
            textBox1.AppendText("  expire_date: " + DesirializedResponse.expire_date + System.Environment.NewLine);
            textBox1.AppendText("  child_order_date: " + DesirializedResponse.child_order_date + System.Environment.NewLine);
            textBox1.AppendText("  child_order_acceptance_id: " + DesirializedResponse.child_order_acceptance_id + System.Environment.NewLine);
            textBox1.AppendText("  outstanding_size: " + DesirializedResponse.outstanding_size + System.Environment.NewLine);
            textBox1.AppendText("  cancel_size: " + DesirializedResponse.cancel_size + System.Environment.NewLine);
            textBox1.AppendText("  executed_size: " + DesirializedResponse.executed_size + System.Environment.NewLine);
            textBox1.AppendText("  total_commission: " + DesirializedResponse.total_commission + System.Environment.NewLine);
        }
    }
}
