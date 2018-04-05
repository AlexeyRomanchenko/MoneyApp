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
        private IDataContextProvider _provider;
        public UserWallets(IDataContextProvider provider)
        {
            _provider = provider;
        }


        public async Task<IEnumerable<Wallet>> GetWallets(string username)
        {
           USD_AccountEntity[] wall;
           List<Wallet> walletList = new List<Wallet>();
            using (var context = _provider.CreateContext())
            {
                wall = await context.UserUSDWallets.Include(u => u.User).Where(u => u.User.UserName == username).ToArrayAsync();
                
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

        public async Task<IEnumerable<Wallet>> GetTransactWallets(int walletId,string currency, string userID)
        {
            List<Wallet> walletList = new List<Wallet>();
            using (var context = _provider.CreateContext())
            {
                var wall = from wallets in context.UserUSDWallets join user in context.Users on wallets.UserId equals user.Id where user.Id == userID && wallets.WalletId != walletId && wallets.Currency == currency select wallets;
                foreach (var wallet in wall)
                {
                    Wallet oneWallet = new Wallet();

                    oneWallet.UserId = wallet.UserId;
                    oneWallet.Value = wallet.Value;
                    oneWallet.WalletId = wallet.WalletId;
                    oneWallet.WalletName = wallet.WalletName;
                    oneWallet.Currency = wallet.Currency;
                    string WalletName = wallet.WalletName;
                    walletList.Add(oneWallet);
                }
            }
            return walletList;
        }
    }
}
