using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class ViewWallet
    {
        public int WalletId { get; set; }
        public string UserId { get; set; }
        public decimal Value { get; set; }
        public string WalletName { get; set; }
        public string Currency { get; set; }
    }
}
