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
        public Authentication Auth { get; }

        public async Task<IActionResult> Login()
        {
            return await Task.FromResult(View());
        }

        public async Task<IActionResult> Register()
        {        
            return await Task.FromResult(View());
        }

        public AccountController(Authentication auth)
        {
            Auth = auth;        
        }

        [HttpPost]
        public async Task<IActionResult> Login([ModelBinder(BinderType = typeof(ModelBinder))]SignInModel model)
        {
          


            if (this.ModelState.IsValid)
            {
               
                User user = new User();

               // var obj = Container.Create(typeof(Authentication));
                //Authentication auth = new Authentication();
                

                Type type = model.GetType();
                PropertyInfo loginInfo = type.GetProperty("Login");
                PropertyInfo passInfo = type.GetProperty("Password");
                
                user = await Auth.CheckAuthentication(model.Login.ToString(), model.Password.ToString());


                if (user == null)
                {
                    HttpContext.Response.StatusCode = 401;
                    return View();
                }
                else
                {
                    var role = await Auth.CheckRole(user);
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
            HttpContext.Response.StatusCode = 401;
            return await Task.FromResult(View());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (model.Login != null && model.Password != null)
            {
                User user = new Business.User();
                user.Login = model.Login;
                user.Password = model.Password;
                user.Role = 2;
                
                Registration reg_account = new Registration();
                await reg_account.CreateNewUser(model.Login, model.Name, model.Email, model.Password, 2);
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

       
        public async Task<JsonResult> LoginExists(string Login)
        {
           // Authentication auth = new Authentication();
            var res = await Auth.CheckUser(Login);
            return await Task.FromResult(Json(!res));
        }
    }
}