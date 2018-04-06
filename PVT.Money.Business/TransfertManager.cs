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

                            firstWallet.WalletName = wallet.WalletName;
                            firstWallet.Value = wallet.Value;
                            firstWallet.WalletId = wallet.WalletId;
                            firstWallet.Currency = wallet.Currency;
                            firstWallet.UserId = firstWallet.UserId;

                            secondWallet.WalletName = sec_wallet.WalletName;
                            secondWallet.Value = sec_wallet.Value;
                            secondWallet.WalletId = sec_wallet.WalletId;
                            secondWallet.Currency = sec_wallet.Currency;
                            secondWallet.UserId = sec_wallet.UserId;

                            walletList.Add(firstWallet);
                            walletList.Add(secondWallet);
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


        public async Task<IEnumerable<Wallet>> Exchange(CurrExchangeModel model)//int value, int first, int second, string firstMoney,string secondMoney
        {

            List<Wallet> walletList = new List<Wallet>();
            Wallet firstWallet = new Wallet();
            Wallet secondWallet = new Wallet();

            if (model != null)
            {
                Rate rate = new Rate(model.FirstWallet.Currency, model.SecondWallet.Currency);
                try
                {
                    using (var context = _provider.CreateContext())
                    {
                        USD_AccountEntity wallet = await context.UserUSDWallets.Include(e => e.User).Where(e => e.WalletId == model.FirstWallet.WalletId).SingleAsync();


                        USD_AccountEntity sec_wallet = await context.UserUSDWallets.Include(e => e.User).Where(e => e.WalletId == model.SecondWallet.WalletId).SingleAsync();
                        if (wallet.Currency != sec_wallet.Currency && model.value > 0)
                        {

                            if (wallet.Value > model.value)
                            {
                                wallet.Value = wallet.Value - model.value;
                                sec_wallet.Value += model.value;


                                context.UserUSDWallets.Update(wallet);
                                await context.SaveChangesAsync();

                                firstWallet.WalletName = wallet.WalletName;
                                firstWallet.Value = wallet.Value;
                                firstWallet.WalletId = wallet.WalletId;
                                firstWallet.Currency = wallet.Currency;
                                firstWallet.UserId = firstWallet.UserId;

                                secondWallet.WalletName = sec_wallet.WalletName;
                                secondWallet.Value = sec_wallet.Value;
                                secondWallet.WalletId = sec_wallet.WalletId;
                                secondWallet.Currency = sec_wallet.Currency;
                                secondWallet.UserId = sec_wallet.UserId;

                                walletList.Add(firstWallet);
                                walletList.Add(secondWallet);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Exception in Transfering one currency ", ex);
                }
            }
            return walletList;
        }

        public TransfertManager(IDataContextProvider provider)
        {
            _provider = provider;
        }

        
    }
}
