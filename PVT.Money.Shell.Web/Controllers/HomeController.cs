using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Models;
using PVT.Money.Business;

namespace PVT.Money.Shell.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(User user)
        {
            int userID = user.Id;
            Authentication auth = new Authentication();
            Wallet result = auth.CheckUserAccount(user.Id);
         //   ViewBag["USD"] = result.USD_Account;
         //   ViewBag["EUR"] = result.EUR_Account;
          //  ViewBag["AUD"] = result.AUD_Account;
            return View();
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
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
