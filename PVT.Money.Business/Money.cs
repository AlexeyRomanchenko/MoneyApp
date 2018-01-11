using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{ // Класс денег
    public class MoneyClass
    {
        private decimal nominal;
        public Currency currency;

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

        public decimal GetNominal() {
            return this.nominal;
        }
        public Currency AddCurrency(Currency curr) {

            try
            {
                this.currency = curr;
                return this.currency;
            }
            catch (Exception ex) {
                throw new ArgumentException("Add Currency error", ex);
            }
        }


        //public string AddCurrency(string curr) {
        //        if (curr =="USD") { 
        //        this.currency = curr;
        //        return this.currency;
        //   }
        //    else {
        //       throw new ArgumentNullException("Not selected currency");
        //   }
        //}

        //Constructor
        public MoneyClass(decimal nom, Currency currency){
            this.nominal = nom;
            this.AddCurrency(currency);
}

       
       


    }
}
