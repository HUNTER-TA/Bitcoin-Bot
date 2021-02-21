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

        public async Task<string> MakeMarketOrder()
        {
            var method = "POST";
            var path = "/v1/me/sendchildorder";
            var query = "";
            var body = @"{
              ""product_code"": ""FX_BTC_JPY"",
              ""child_order_type"": ""MARKET"",
              ""side"": ""BUY"",
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
                    textBox1.AppendText("  Error: GetOrderInformationWithID() returning ERROR_NO_RESPONSE" + System.Environment.NewLine);
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
            textBox1.AppendText("RunThisWhenButtonMarketOrderIsClicked():IN" + System.Environment.NewLine);

            //MakeMarketOrder() で成行注文を発行
            string ResponseMakeMarketOrder = await MakeMarketOrder();
            textBox1.AppendText(ResponseMakeMarketOrder + System.Environment.NewLine);

            //以下のようなレスポンスの文字列から値だけを取り出す
            //{ "child_order_acceptance_id":"JRF20180314-102635-135926"}
            var DesirializedResponse = JsonConvert.DeserializeObject<JsonSendChildOrder>(ResponseMakeMarketOrder);
            var ChildOrderAcceptanceID = DesirializedResponse.child_order_acceptance_id;

            //処理をした旨を通知
            textBox1.AppendText("--------------------------" + System.Environment.NewLine);
            textBox1.AppendText("Market Order made: " + numericUpDownMarketOrder.Value + System.Environment.NewLine);
            textBox1.AppendText(ChildOrderAcceptanceID + System.Environment.NewLine);
            textBox1.AppendText("--------------------------" + System.Environment.NewLine);
        }
    }
}
