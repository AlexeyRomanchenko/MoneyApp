using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{ // Класс денег
    public class MoneyClass
    {
        public decimal nominal;
        public string currency;
        
        public decimal AddNominal(decimal nom)
        {
            if (nom > 0)
            {
                this.nominal = nom;
                return this.nominal;
            }
            else
            {
                throw new ArgumentNullException("Your nominal is null");
            }
        }
        public string AddCurrency(string curr) {
            if (curr == "USD" || curr == "EUR" || curr == "AUD") {
                this.currency = curr;
                return this.currency;
            }
            else {
                throw new ArgumentNullException("Not selected currency");
            }
        }
        // Конструктор
        public MoneyClass(decimal nom, string curr){

            this.AddNominal(nom);
            this.AddCurrency(curr);
        }


    }
}
