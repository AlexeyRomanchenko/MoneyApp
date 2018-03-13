using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PVT.Money.Business
{
    public class UserWallets
    {
        public IEnumerable<Wallet> GetWallets(string username)
        {
           List<Wallet> walletList = new List<Wallet>();
            using (var context = new MoneyContext())
            {
                var wall = context.UserUSDWallets.Include(u => u.User).Where(u => u.User.Username == username);
                foreach (var res in wall)
                {
                    Wallet wallet = new Wallet();
                    wallet.Currency = res.Currency;
                    wallet.Value = res.UsdValue;
                    wallet.WalletName = res.WalletName;
                    wallet.WalletId = res.WalletId;
                    walletList.Add(wallet);
                }
                return walletList;
            }
        }
    }
}
