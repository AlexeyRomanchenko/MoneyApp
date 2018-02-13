using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Models;
using PVT.Money.Business;
using PVT.Money.Shell.Web.Domain;
using PVT.Money.Data;

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
        public IActionResult Login([ModelBinder(BinderType = typeof(ModelBinder))]SignInModel model)
        {
            if (this.ModelState.IsValid)
            {
                    User user = new User();
                    
                    Authentication auth = new Authentication();
                  user=  auth.CheckAuthentication(model.Login.ToString(), model.Password.ToString());
                if (user == null)
                {
                    return View();
                }
                
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
                reg_account.CreateNewUser(model.Login, model.Name, model.Password, 1);
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

    }
}