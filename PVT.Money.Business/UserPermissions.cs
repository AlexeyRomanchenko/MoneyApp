using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PVT.Money.Business
{
    public class UserPermissions
    {
        private IDataContextProvider _provider;

        public UserPermissions(IDataContextProvider provider)
        {
            _provider = provider;
        }


        public async Task<IEnumerable<ViewWallet>> GetPermissions(string id)
        {
            List<ViewWallet> resultList = new List<ViewWallet>();
            if (id != null)
            {

                using (var context = _provider.CreateContext())
                {
                    var walls = await context.UserUSDWallets.Where(r => r.UserId == id).ToArrayAsync();
                    foreach (var count in walls)
                    {
                        ViewWallet wall = new ViewWallet();
                        wall.Currency = count.Currency;
                        wall.WalletName = count.WalletName;
                        wall.Value = count.Value;
                        resultList.Add(wall);
                    }

                    context.SaveChanges();

                }

            }

            return await Task.FromResult(resultList);
        }

    }  
}
