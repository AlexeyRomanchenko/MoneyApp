using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class Wallet
    {   
        public int WalletId { get; set; }
        public int Value { get; set; }
        public string WalletName { get; set; }
        public string Currency { get; set; }
    }
}
