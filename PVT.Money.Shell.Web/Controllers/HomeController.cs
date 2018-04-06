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

using PVT.Money.Data;
using Microsoft.AspNetCore.SignalR;
using System.Threading;

namespace PVT.Money.Shell.Web.Controllers
{
    [Documentation("someInfo")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly MyUserManager _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private UserPermissions _userPerms;
        private UserWallets _wallet;
        private Authentication _auth;
        private IHubContext<SomeHub> _hubcontext;

        public HomeController(
             MyUserManager userManager,
             SignInManager<ApplicationUser> signInManager,
             Authentication authentication,
             UserWallets wallet,
             UserPermissions userPerms,
             IHubContext<SomeHub> hubContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _auth = authentication;
            _userPerms = userPerms;
            _wallet = wallet;
            _hubcontext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Task.Run(()=> 
            //{
            //    Thread.Sleep(10000);
            //    SendSignalRMessage();
            //});
            var username = User.Identity.Name;
            var userWallets = await _wallet.GetAllWallets(username);
            string id = await this.GetUserId(username);
            ViewBag.Id = id;
            return View(userWallets);
       }

        private async Task SendSignalRMessage()
        {
          //  _hubcontext.Clients.All.InvokeAsync("Send","Hello");
        }



        public async Task<IActionResult> About()
        {
            var username = User.Identity.Name;
            string id = await this.GetUserId(username);
            ViewBag.Id = id;
            var userList = await _userManager.GetUsers();
            return await Task.FromResult(View(userList));
        }

        public async Task<IActionResult> Contact()
        {
            var username = User.Identity.Name;
            string id = await this.GetUserId(username);
            ViewBag.Id = id;


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

        public async Task<string> GetUserId(string username)
        {
          string userId = await _userManager.GetUserId(username);
            return userId;

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
