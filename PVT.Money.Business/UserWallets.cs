using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PVT.Money.Business
{
    public class UserWallets
    {
        public async Task<IEnumerable<Wallet>> GetWallets(string username)
        {
           USD_AccountEntity[] wall;
           List<Wallet> walletList = new List<Wallet>();
            using (var context = new MoneyContext())
            {
                wall = await context.UserUSDWallets.Include(u => u.User).Where(u => u.User.Username == username).ToArrayAsync();
                
            }
            foreach (var res in wall)
                {
                    Wallet wallet = new Wallet();
                    wallet.Currency = res.Currency;
                    wallet.Value = res.Value;
                    wallet.WalletName = res.WalletName;
                    wallet.WalletId = res.WalletId;
                    walletList.Add(wallet);
                }
                return walletList;
        }

        public async Task<IEnumerable<Wallet>> GetTransactWallets(int walletId,string currency, int userID)
        {
            List<Wallet> walletList = new List<Wallet>();
            using (var context = new MoneyContext())
            {
                var wall = from wallets in context.UserUSDWallets join user in context.Users on wallets.UserId equals user.ID where user.ID == 1 && wallets.WalletId != 1 && wallets.Currency == "USD" select wallets;
                foreach (var wallet in wall)
                {
                    string WalletName = wallet.WalletName;
                }
            }
            return walletList;
        }
    }
}
