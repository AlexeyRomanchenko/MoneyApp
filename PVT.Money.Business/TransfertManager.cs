using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Business
{
    class TransfertManager
    {
        private IDataContextProvider __provider; 

        private async Task<IEnumerable<Wallet>> Transfert(int value , int first, int second) {

            List<Wallet> walletList = new List<Wallet>();
            Wallet firstWallet = new Wallet();
            Wallet secondWallet = new Wallet();
            try
            {
                using (var context =  __provider.CreateContext())
                {
                    USD_AccountEntity wallet = await context.UserUSDWallets.Include(e => e.User).Where(e => e.WalletId == first).SingleAsync();
                    
                        firstWallet.WalletName = wallet.WalletName;
                        firstWallet.Value = wallet.Value;
                        firstWallet.WalletId = wallet.WalletId;
                        firstWallet.Currency = wallet.Currency;
                        firstWallet.UserId = firstWallet.UserId;
                    


                    

                    USD_AccountEntity sec_wallet = await context.UserUSDWallets.Include(e=>e.User).Where(e => e.WalletId == second).SingleAsync();
                    
                        secondWallet.WalletName = sec_wallet.WalletName;
                        secondWallet.Value = sec_wallet.Value;
                        secondWallet.WalletId = sec_wallet.WalletId;
                        secondWallet.Currency = sec_wallet.Currency;
                        secondWallet.UserId = sec_wallet.UserId;
                    
                    
                }


                if (firstWallet.Currency == secondWallet.Currency && value > 0)
                {

                    if (firstWallet.Value > value)
                    {
                        firstWallet.Value = firstWallet.Value - value;
                        secondWallet.Value += value;
                        walletList.Add(firstWallet);
                        walletList.Add(secondWallet);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Exception in Transfering one currency ",ex);
            }

           
            return walletList;


        }

       
        public TransfertManager(int value, int firstWallet, int secondWallet, IDataContextProvider provider)
        {
            __provider = provider;
            Transfert(value, firstWallet, secondWallet);
        }
    }
}
