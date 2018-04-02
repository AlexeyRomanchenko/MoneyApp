using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Business;
using PVT.Money.Shell.Web.Models;
using Microsoft.AspNetCore.Identity;

using PVT.Money.Data;

namespace PVT.Money.Shell.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
       // private readonly Services.IEmailSender _emailSender;
        private UserPermissions _userPerms;
        private UserWallets _wallet;

        public UserController(
             UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager,
            // Services.IEmailSender emailSender,
             UserWallets wallet,
             UserPermissions userPerms)
        {
            _userManager = userManager;
            _signInManager = signInManager;
         //   _emailSender = emailSender;
            _userPerms = userPerms;
            _wallet = wallet;
        }



        [HttpPost]
        public async Task<IActionResult> LoginPermissions(string login)
        {
            IEnumerable<string> result = new List<string>();
           // UserPermissions permissions = new UserPermissions();
            result = await _userPerms.GetPermissions(login);
            return await Task.FromResult(Json(new{perms= result}));
        }

        [HttpPost]
        public async Task<IActionResult> GetWallets(int walletId,string currency,int userId)
        {
            
          //  UserWallets userWallets = new UserWallets();
            var wallets = await _wallet.GetTransactWallets(walletId,currency,userId);

            return Json(new {wallet = wallets });
        }


    }
   
}