using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Models;
using PVT.Money.Business;

namespace PVT.Money.Shell.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {        
            return View();
        }


        [HttpPost]
        public IActionResult Login(SignInModel model)
        {
            if (model.Login != null && model.Password != null)
            {
                    User user = new User();
                    
                    Authentication auth = new Authentication();
                  user=  auth.CheckAuthentication(model.Login.ToString(), model.Password.ToString());

                
                ViewData["Authorized"] = model.Login;
                     return RedirectToAction("Index", "Home",user);
                //return View();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Login != null && model.Password != null)
            {
                Registration reg_account = new Registration();
                reg_account.CreateNewUser(model.Name, model.Login, model.Password, UserRoles.User);
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

    }
}