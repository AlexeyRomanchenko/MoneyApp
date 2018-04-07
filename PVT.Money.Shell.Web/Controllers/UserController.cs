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
        private TransfertManager _transfertManager;
        private UserPermissions _userPerms;
        private UserWallets _wallet;

        public UserController(
             UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager,
            TransfertManager transfertManager,
             UserWallets wallet,
             UserPermissions userPerms)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _transfertManager = transfertManager;
               _userPerms = userPerms;
            _wallet = wallet;
        }



        [HttpPost]
        public async Task<IActionResult> LoginPermissions(string id)
        {
            IEnumerable<string> result = new List<string>();
            result = await _userPerms.GetPermissions(id);
            return await Task.FromResult(Json(new{perms= result}));
        }

        [HttpPost]
        public async Task<IActionResult> TransfertMoney(int value, int firstWalletId, int secondWalletId)
        {
            IEnumerable<string> result = new List<string>();
           var wallets = await _transfertManager.Transfert(value, firstWalletId, secondWalletId);
            return RedirectToAction("Index", "Home");
           
        }

        [HttpPost]
        public async Task<IActionResult> ExchangeMoney(int value, int firstWalletId, int secondWalletId)
        {
            IEnumerable<string> result = new List<string>();
           
            var wallets = await _transfertManager.Exchange(value, firstWalletId, secondWalletId);
            return RedirectToAction("Index", "Home");
            

        }

        [HttpPost]
        public async Task<IActionResult> GetWallets(int walletId,string currency,string userId)
        {
            var wallets = await _wallet.GetTransactWallets(walletId,currency,userId);
            return Json(new {wallet = wallets });
        }

        [HttpPost]
        public async Task<IActionResult> GetCurrWallets(int walletId, string currency, string userId)
        {
            var wallets = await _wallet.GetCurrencyWallets(walletId, currency, userId);
            return Json(new { wallet = wallets });
        }

        [HttpPost]
        public async Task<IActionResult> AddWallet(string walName, string selCurr, string userId)
        {
            var res =  _wallet.AddWallet(walName,selCurr,userId);
            return RedirectToAction("Index", "Home");
        }


    }
   
}