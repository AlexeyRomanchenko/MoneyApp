﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
   public class MyFee
    {
        private decimal nominal;
        public decimal moneyAfter;
        
        // Take 1 % of every transaction
        public decimal GetProcents(MoneyClass first) {
            
                nominal = first.GetNominal() / 100;
                moneyAfter = first.GetNominal() - nominal;
                return moneyAfter;
            
            
        }
     
        public MyFee(MoneyClass other_money) {



            this.GetProcents(other_money);


        }

        private void Procents_Added(object sender,WalletArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                throw new Exception("Err", ex);
            }
        }

    }
    
    // Кошелек хранит мои отчисления с переводов

    public class Wallet
    {
        public event EventHandler ProcentsPaid;

        private void OnPaid(decimal cash) {
            if (ProcentsPaid != null)
            {
                WalletArgs args = new WalletArgs(cash);
                ProcentsPaid(this,args);
            }
        }
        public void OnWalletPut(decimal cash) {
            OnPaid(cash);
        }
        
    }

    public class WalletArgs : EventArgs
    {
        public decimal Cash { get; private set; }
        public WalletArgs(decimal myProcents)
        {
            Cash = myProcents;
        }
    }

}
