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

        //最終取引価格を TextBox に出力する
        public async Task GetCurrentBtcFxPrice()
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
                textBox1.AppendText($"最終取引価格: {DesirializedResponse.ltp}" + System.Environment.NewLine);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task Job1 = GetCurrentBtcFxPrice();
        }
    }
}
