using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Models;

namespace PVT.Money.Shell.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(SignInModel model)
        {
            if (model.login != null)
            {
                ViewData["Authorized"] = model.login;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}