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
                            koef = 0.5m;
                            break;
                        }
                    case Currency.EUR:
                        {
                            koef = 0.8m;
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
                            koef = 2m;
                            break;
                        }
                    case Currency.EUR:
                        {
                            koef = 1.7m;
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
                            koef = 0.3m;
                            break;
                        }
                    case Currency.USD:
                        {
                            koef = 2m;
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
