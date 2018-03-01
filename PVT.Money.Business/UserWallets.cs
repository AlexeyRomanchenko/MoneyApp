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
        public IEnumerable<string> GetUSD(string username)
        {
            List<string> usdList = new List<string>();
            using (var context = new MoneyContext())
            {
                var wall = context.UserUSDWallets.Include(u => u.User).Where(u => u.User.Username == username);
                foreach (var res in wall)
                {
                    var e = res.UsdValue;
                    usdList.Add(e);
                }
                return usdList;
            }
        }
    }
}
