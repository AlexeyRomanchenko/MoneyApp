using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Business
{
    public class TransfertManager
    {
        private IDataContextProvider _provider;


        public async Task<IEnumerable<Wallet>> Transfert(int value , int first, int second) {

            List<Wallet> walletList = new List<Wallet>();
            Wallet firstWallet = new Wallet();
            Wallet secondWallet = new Wallet();
            try
            {
                using (var context = _provider.CreateContext())
                {
                    USD_AccountEntity wallet = await context.UserUSDWallets.Include(e => e.User).Where(e => e.WalletId == first).SingleAsync();
                    
                      
                    USD_AccountEntity sec_wallet = await context.UserUSDWallets.Include(e=>e.User).Where(e => e.WalletId == second).SingleAsync();
                    
                      
                    if (wallet.Currency == sec_wallet.Currency && value > 0)
                    {

                        if (wallet.Value > value)
                        {
                            wallet.Value = wallet.Value - value;
                            sec_wallet.Value += value;

                           
                                context.UserUSDWallets.Update(wallet);
                                await context.SaveChangesAsync();
                            

                            //walletList.Add(firstWallet);
                            //walletList.Add(secondWallet);
                        }
                    }
                }


               
            }
            catch(Exception ex)
            {
                throw new Exception("Exception in Transfering one currency ",ex);
            }

            return walletList;


        }

        public TransfertManager(IDataContextProvider provider)
        {
            _provider = provider;
        }

        
    }
}
