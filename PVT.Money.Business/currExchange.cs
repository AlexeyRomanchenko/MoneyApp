using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{ // Класс обмена валют
    public class CurrExchange
    {
        private decimal secondNominal;
        private MoneyClass resMoney;
        public MoneyClass SetSecondNominal(decimal nom, Currency s) {
            
            MoneyClass res_count = new MoneyClass(nom, s);
            this.resMoney = res_count;
            return res_count;
        }
        public MoneyClass GetSecondNominal() {
            return this.resMoney;
        }

        // Метод для обмена валют. Необходимо иметь класс Money и наименование валюты, в кот хотим перевести 
        private decimal Change(MoneyClass first, Currency secCurr) {
        
                if (secCurr != first.currency)
                {
                    try
                    {
                    decimal old_nominal = first.GetNominal();
                        
                        Currency old_currency = first.currency;
                        Currency new_currency = secCurr;

                        //Rate rate = new Rate(old_currency,new_currency);
                       // this.secondNominal = old_nominal * rate.rateCount;

                    MoneyClass changed_money = new MoneyClass(this.secondNominal,new_currency);
                    return Account.GetInstance.GetProcents(changed_money);
                 
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in converting", ex);
                    }
                }
                else
                {
                
                return first.GetNominal();
                }

        }

        //Конструктор
        public CurrExchange(MoneyClass YourMoney,Currency NeedCurr)
        {
            decimal res = Change(YourMoney, NeedCurr);

            this.SetSecondNominal(res,NeedCurr);
           
            
        }
    }
}
