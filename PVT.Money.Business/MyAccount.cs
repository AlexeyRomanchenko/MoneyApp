using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
   public class MyFee
    {
        private decimal nominal;
        
        // Take 1 % of every transaction in USD
        public decimal GetProcents(MoneyClass first) {
            
                nominal = first.GetNominal() / 100;
                decimal some = first.GetNominal() - nominal;
                return some;
            
            
        }

        public MyFee(MoneyClass other_money) {
            this.GetProcents(other_money);
        }
    }

}
