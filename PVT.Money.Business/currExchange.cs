using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{ // Класс обмена валют
    public class CurrExchange
    {
        public decimal secondNominal;

        //Получаем коэффициент исходя ил двух наименований валют
        private decimal GetKoeff(string frst, string sec) {
            decimal koef = -1;
            if (frst == "USD")
            {              
                switch (sec)
                {
                    case "AUD":
                        {
                            koef = 0.5m;
                            break;
                        }
                    case "EUR":
                        {
                            koef = 0.8m;
                            break;
                        }
                }
                return koef;
            }
            else if (frst == "AUD")
            {
                switch (sec)
                {
                    case "USD":
                        {
                            koef = 2m;
                            break;
                        }
                    case "EUR":
                        {
                            koef = 1.7m;
                            break;
                        }
                }
                return koef;
            }
            else if (frst == "EUR")
            {                
                switch (sec)
                {
                    case "AUD":
                        {
                            koef = 0.3m;
                            break;
                        }
                    case "USD":
                        {
                            koef = 2m;
                            break;
                        }
                }
                return koef;
            }
            else {
                throw new Exception("We haven't such kind of money, sorry Man");
            }
        }

        // Метод для обмена валют. Необходимо иметь класс Money и наименование валюты, в кот хотим перевести 
        private decimal Change(MoneyClass first, string secCurr) {
            if (Convert.ToBoolean(first.nominal) == true)
            {
                if (secCurr != first.currency)
                {
                    try
                    {
                        decimal old_nominal = first.nominal;
                        string old_currency = first.currency;
                        string new_currency = secCurr;

                        decimal koefficient = this.GetKoeff(new_currency, old_currency);
                        this.secondNominal = old_nominal * koefficient;

                        return this.secondNominal;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in converting", ex);
                    }
                }
                else
                {
                    throw new Exception("You selected an old currency!");
                }

            }
            else {
                throw new ArgumentNullException("first nominal returned false");
            }
        }

        //Конструктор
        public CurrExchange(MoneyClass YourMoney,string NeedCurr) {
            decimal res = Change(YourMoney, NeedCurr);
            
        }
    }
}
