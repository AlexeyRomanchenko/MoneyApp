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
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            UserWallets wallet = new Business.UserWallets();
            IEnumerable<string> usd = wallet.GetUSD(username);
            Dictionary<string, IEnumerable<string>> walletDictionary = new Dictionary<string, IEnumerable<string>>();
            walletDictionary.Add("USD",usd);

            return View(walletDictionary);
        }

        public IActionResult About()
        {
            
            UserManager users = new UserManager();
            var userList = users.GetUsers();
            var s = userList.GetType();
            return View(userList);
        }

        public IActionResult Contact()
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


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
