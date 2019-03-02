using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoInv.Data.Crypto
{
    public class CryptoAPI
    {
        public CryptoAPI()
        {

        }

        public static async Task<CryptoAPIData> GetDataAsync()
        {
            var Data = new CryptoAPIData();

            HttpClient Client = new HttpClient
            {
                BaseAddress = new System.Uri("https://min-api.cryptocompare.com/")
            };
            Client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            HttpResponseMessage Response = await Client.GetAsync("data/pricemultifull?fsyms=BTC,ETH,BCH,LTC,XMR,XLM,XRP,ZEC,WAVES,DOGE,DASH,TRX&tsyms=GBP");
            Response.EnsureSuccessStatusCode();

            Data = await Response.Content.ReadAsAsync<CryptoAPIData>();

            return Data;
        }
    }
}
