using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Business;
using PVT.Money.Shell.Web.Models;

namespace PVT.Money.Shell.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> LoginPermissions(string login)
        {
            IEnumerable<string> result = new List<string>();
            UserPermissions permissions = new UserPermissions();
            result = await permissions.GetPermissions(login);
            return await Task.FromResult(Json(new{perms= result}));
        }

        [HttpPost]
        public async Task<IActionResult> GetWallets(int walletId,string currency,int userId)
        {
            
            UserWallets userWallets = new UserWallets();
            var wallets = await userWallets.GetTransactWallets(walletId,currency,userId);

            return Json(new {wallet = wallets });
        }


    }
   
}