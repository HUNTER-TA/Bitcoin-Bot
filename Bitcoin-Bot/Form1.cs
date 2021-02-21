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

namespace Bitcoin_Bot
{
    public partial class Form1 : Form
    {
        static readonly Uri endpointUri = new Uri("https://api.bitflyer.com");

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

                textBox1.AppendText(response + System.Environment.NewLine);
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
