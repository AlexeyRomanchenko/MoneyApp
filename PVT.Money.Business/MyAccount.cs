using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{ //
    public class Account {

        //public delegate void AccountDelegate(decimal cash);

        //AccountDelegate accDeleg;

        //public void RegisterDelegate(AccountDelegate _accDeleg)
        //{
        //    accDeleg = _accDeleg;
        //}
        //public void Add(decimal _sum)
        //{
        //    if (_sum != 0)
        //    {
        //        nominal += _sum;               
        //        accDeleg(_sum);   
        //    }          
        //}

        private decimal nominal;
        public decimal moneyAfter;
        

        public decimal GetMoney
        {
            get { return nominal; }
        }
       

        // Take 1 % of every transaction
        public decimal GetProcents(MoneyClass first)
        {
            nominal = first.GetNominal() / 100;
            moneyAfter = first.GetNominal() - nominal;
            return moneyAfter;
        }

        private static Account instance;

        private Account()
        {
        }

        public static Account GetInstance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new Account();
                }
                return instance;
            }
        }
        

        



    }



}
