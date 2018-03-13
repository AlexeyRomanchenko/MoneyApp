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
        public IActionResult LoginPermissions(string login)
        {
            List<string> result = new List<string>();
            UserPermissions permissions = new UserPermissions();
            result = permissions.GetPermissions(login);
            return Json(new{perms= result});
        }

        [HttpPost]
        public IActionResult GetWallets(string login)
        {
            List<string> result = new List<string>();
            result.Add("First");
            result.Add("Second");
            return Json(new { wallets = result });
        }


    }
   
}