using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class CurrExchangeModel
    {
        public int value { get; set; }
        public Wallet FirstWallet { get; set; }
        public Wallet SecondWallet{ get; set; }
    }
}
