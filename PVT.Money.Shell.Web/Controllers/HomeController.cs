using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Models;
using PVT.Money.Business;
using System.Reflection;
using PVT.Money.Shell.Web.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PVT.Money.Shell.Web.Services;
using PVT.Money.Data;

namespace PVT.Money.Shell.Web.Controllers
{
    [Documentation("someInfo")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly MyUserManager _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Services.IEmailSender _emailSender;
        private UserPermissions _userPerms;
        private UserWallets _wallet;

        public HomeController(
             MyUserManager userManager,
             SignInManager<ApplicationUser> signInManager,
             Services.IEmailSender emailSender,
             UserWallets wallet,
             UserPermissions userPerms)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _userPerms = userPerms;
            _wallet = wallet;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
          
            var username = User.Identity.Name;
            var userWallets = await _wallet.GetWallets(username);
            return await Task.FromResult(View(userWallets));
        }

        public async Task<IActionResult> About()
        {           
            //UserManager users = new UserManager();
            var userList = await _userManager.GetUsers();
            return await Task.FromResult(View(userList));
        }

        public async Task<IActionResult> Contact()
        {         
            DocumentationClass value = new DocumentationClass();
            var a = Assembly.GetExecutingAssembly();
            var b = a.DefinedTypes;
            foreach (var t in b) {
                foreach (var attributes in t.CustomAttributes)
                {
                    if (attributes.AttributeType == typeof(DocumentationAttribute))
                    {
                        value.ClassName = t.Name;
                        value.Desc = "";                      
                    }
                }
            }

            ViewData["Message"] = "Your contact page.";

            return View(value);
        }


        public async Task<IActionResult> TransfertMoney()
        {

            return Json(new{success=true});
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
