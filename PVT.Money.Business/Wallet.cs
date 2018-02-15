using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class Wallet
    {
        public int UserId { get; set; }     
        public string USD_Account { get; set; }
        public string EUR_Account { get; set; }
        public string AUD_Account { get; set; }
    }
}
