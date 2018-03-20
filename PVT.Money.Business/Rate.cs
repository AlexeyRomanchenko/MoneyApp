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
        //Получаем коэффициент исходя ил двух наименований валют
        //private void GetRate(Currency frst, Currency sec)
        //{
        //    decimal koef = -1;
        //    if (frst == Currency.USD)
        //    {
        //        switch (sec)
        //        {
        //            case Currency.AUD:
        //                {
        //                    koef = 1.25m;
        //                    break;
        //                }
        //            case Currency.EUR:
        //                {
        //                    koef = 0.81m;
        //                    break;
        //                }
        //        }
        //        rateCount = koef;
        //        //return koef;
        //    }
        //    else if (frst == Currency.AUD)
        //    {
        //        switch (sec)
        //        {
        //            case Currency.USD:
        //                {
        //                    koef = 0.8m;
        //                    break;
        //                }
        //            case Currency.EUR:
        //                {
        //                    koef = 0.65m;
        //                    break;
        //                }
        //        }
        //        rateCount = koef;
        //        //return koef;
        //    }
        //    else if (frst == Currency.EUR)
        //    {
        //        switch (sec)
        //        {
        //            case Currency.AUD:
        //                {
        //                    koef = 1.53m;
        //                    break;
        //                }
        //            case Currency.USD:
        //                {
        //                    koef = 1.23m;
        //                    break;
        //                }
        //        }
        //        rateCount = koef;
        //        //return koef;
        //    }
        //    else
        //    {
        //        throw new Exception("We haven't such kind of money, sorry Man");
        //    }
        //}

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
