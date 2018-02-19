using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Models;
using PVT.Money.Business;
using PVT.Money.Shell.Web.Domain;
using PVT.Money.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace PVT.Money.Shell.Web.Controllers
{
    [AllowAnonymous]
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
                ClaimsPrincipal principal = new ClaimsPrincipal();
                ClaimsIdentity claims = new ClaimsIdentity("MyAuth");

                User user = new User();                  
                Authentication auth = new Authentication();

                user =  auth.CheckAuthentication(model.Login.ToString(), model.Password.ToString());
                       
                if (user == null)
                {
                    return View();
                }
                claims.AddClaim(new Claim(ClaimTypes.Name, user.Login));
                claims.AddClaim(new Claim(ClaimTypes.GivenName, "Mr. " + user.Login));
                principal.AddIdentity(claims);
                HttpContext.SignInAsync(principal).Wait();

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
                reg_account.CreateNewUser(model.Login, model.Name,model.Email, model.Password, 2);
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

       
        public JsonResult LoginExists(string Login)
        {
            Authentication auth = new Authentication();
            var res = auth.CheckUser(Login);
            return Json(!res);
        }
    }
}