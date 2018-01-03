using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{ // Класс обмена валют
    public class CurrExchange
    {
        private decimal secondNominal;

        public decimal SetSecondNominal(decimal nom) {
            this.secondNominal = nom;
            return this.secondNominal;
        }
        public decimal GetSecondNominal() {
            return this.secondNominal;
        }

        // Метод для обмена валют. Необходимо иметь класс Money и наименование валюты, в кот хотим перевести 
        private MoneyClass Change(MoneyClass first, Currency secCurr) {
        
                if (secCurr != first.currency)
                {
                    try
                    {
                    decimal old_nominal = first.GetNominal();
                        
                        Currency old_currency = first.currency;
                        Currency new_currency = secCurr;

                    // decimal koefficient = this.GetKoeff(new_currency, old_currency);
                        Rate rate = new Rate(old_currency,new_currency);
                        this.secondNominal = old_nominal * rate.rateCount;

                    MoneyClass changed_money = new MoneyClass(this.secondNominal,new_currency);
                    MyFee money_after_procents = new MyFee(changed_money);

                    return changed_money;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in converting", ex);
                    }
                }
                else
                {
                
                return first;
                }

        }

        //Конструктор
        public CurrExchange(MoneyClass YourMoney,Currency NeedCurr) {
            MoneyClass res = Change(YourMoney, NeedCurr);

            
        }
    }
}
