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

namespace PVT.Money.Shell.Web.Controllers
{
    [Documentation("someInfo")]
    [Authorize]
    public class HomeController : Controller
    {
      
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            UserWallets wallet = new UserWallets();
            var userWallets = await wallet.GetWallets(username);
            return await Task.FromResult(View(userWallets));
        }

        public async Task<IActionResult> About()
        {           
            UserManager users = new UserManager();
            var userList = await users.GetUsers();
            var s = userList.GetType();
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


        public async Task<IActionResult> TransfertOneCurrency()
        {

            return Json(new{success=true});
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
