using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PVT.Money.Business
{
   // Магические числа
   public class Rate
    {

        public decimal rateCount;
       
        private void GetRate(string first, string second)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency="+ first + "&to_currency="+ second + "&apikey=2S5FURKC6SUUOTS8");
                HttpResponseMessage res = client.SendAsync(req).Result;
                var r = res.Content.ReadAsStringAsync().Result;
                CurrencyModelAPI s = JsonConvert.DeserializeObject<CurrencyModelAPI>(r);
                rateCount = s.model.Exchange_Rate;
            }
           
        }


        public Rate(string curr, string needCurr) {
            this.GetRate(curr, needCurr);

        }

    }
}
