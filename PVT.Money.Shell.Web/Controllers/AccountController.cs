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
            SignInModel LoginModel = new SignInModel();
            LoginModel.Login = "Alexey";
            LoginModel.Password = "123456";
            return View(LoginModel);
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
    }
}