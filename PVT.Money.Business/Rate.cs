using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
   public class Rate
    {

        public decimal rateCount;
        //Получаем коэффициент исходя ил двух наименований валют
        private void GetRate(Currency frst, Currency sec)
        {
            decimal koef = -1;
            if (frst == Currency.USD)
            {
                switch (sec)
                {
                    case Currency.AUD:
                        {
                            koef = 1.25m;
                            break;
                        }
                    case Currency.EUR:
                        {
                            koef = 0.81m;
                            break;
                        }
                }
                rateCount = koef;
                //return koef;
            }
            else if (frst == Currency.AUD)
            {
                switch (sec)
                {
                    case Currency.USD:
                        {
                            koef = 0.8m;
                            break;
                        }
                    case Currency.EUR:
                        {
                            koef = 0.65m;
                            break;
                        }
                }
                rateCount = koef;
                //return koef;
            }
            else if (frst == Currency.EUR)
            {
                switch (sec)
                {
                    case Currency.AUD:
                        {
                            koef = 1.53m;
                            break;
                        }
                    case Currency.USD:
                        {
                            koef = 1.23m;
                            break;
                        }
                }
                rateCount = koef;
                //return koef;
            }
            else
            {
                throw new Exception("We haven't such kind of money, sorry Man");
            }
        }

        public Rate(Currency curr,Currency needCurr) {
            this.GetRate(curr, needCurr);

        }

    }
}
