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
using System.Reflection;
using PVT.Money.Shell.Web.Domain;

namespace PVT.Money.Shell.Web.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IContainer container { get; }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {        
            return View();
        }
        public AccountController()
        {
          //  Container.Create();
        }

        [HttpPost]
        public IActionResult Login([ModelBinder(BinderType = typeof(ModelBinder))]SignInModel model)
        {
          


            if (this.ModelState.IsValid)
            {
               
                User user = new User();

                var obj = container.Create(typeof(Authentication));

                Authentication auth = new Authentication();

                Type type = model.GetType();
                PropertyInfo loginInfo = type.GetProperty("Login");
                PropertyInfo passInfo = type.GetProperty("Password");
                
                user = auth.CheckAuthentication(model.Login.ToString(), model.Password.ToString());


                if (user == null)
                {
                    return View();
                }
                else
                {
                    var role = auth.CheckRole(user);
                    string roleName = role.Role.Role;
                    ClaimsPrincipal principal = new ClaimsPrincipal();
                    ClaimsIdentity claims = new ClaimsIdentity("MyAuth");
                    claims.AddClaim(new Claim(ClaimTypes.Name, user.Login));
                    claims.AddClaim(new Claim(ClaimTypes.GivenName, "Mr. " + user.Login));
                    claims.AddClaim(new Claim(ClaimTypes.Role, roleName));
                    principal.AddIdentity(claims);
                    HttpContext.SignInAsync(principal).Wait();

                    ViewData["Authorized"] = model.Login;
                    return RedirectToAction("Index", "Home", user);
                }
               
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Login != null && model.Password != null)
            {
                User user = new Business.User();
                user.Login = model.Login;
                user.Password = model.Password;
                user.Role = 2;
                
                Registration reg_account = new Registration();
                reg_account.CreateNewUser(model.Login, model.Name, model.Email, model.Password, 2);
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