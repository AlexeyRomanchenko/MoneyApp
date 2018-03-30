using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Models;
using PVT.Money.Business;
using PVT.Money.Shell.Web.Domain;
//using PVT.Money.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Reflection;
//using PVT.Money.Shell.Web.Domain;
using Microsoft.AspNetCore.Identity;
using PVT.Money.Shell.Web.Services;

namespace PVT.Money.Shell.Web.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private Authentication Auth { get; }
        private Registration Reg { get; }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return await Task.FromResult(View());
        }
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return await Task.FromResult(View());
        }

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            Authentication auth,
            Registration reg)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            Auth = auth;
            Reg = reg;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([ModelBinder(BinderType = typeof(ModelBinder))]SignInModel model, string returnUrl = null)
        {

            if (ModelState.IsValid)
            {

                User user = new User();

                // var obj = Container.Create(typeof(Authentication));
                //Authentication auth = new Authentication();


                Type type = model.GetType();
                PropertyInfo loginInfo = type.GetProperty("Login");
                PropertyInfo passInfo = type.GetProperty("Password");

                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
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
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.AddClaim(new Claim(ClaimTypes.Role, roleName));
                    principal.AddIdentity(claims);
                    HttpContext.SignInAsync(principal).Wait();

                    ViewData["Authorized"] = model.Login;
                    return RedirectToAction("Index", "Home");
                }

            }
            HttpContext.Response.StatusCode = 401;
            return await Task.FromResult(View());
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (model.Login != null && model.Password != null)
            {
                User user = new Business.User();
                user.Login = model.Login;
                user.Password = model.Password;
                user.Role = 2;

                ApplicationUser userRegister = new ApplicationUser { UserName = model.Name, Email = model.Email };
                var result = await _userManager.CreateAsync(userRegister, model.Password);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(userRegister);
                    var callbackUrl = "google.com";
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(userRegister, isPersistent: false);

                    return RedirectToLocal("");
                }

                //Registration reg_account = new Registration();
                await Reg.CreateNewUser(model.Login, model.Name, model.Email, model.Password, 2);
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [AllowAnonymous]
        public async Task<JsonResult> LoginExists(string Login)
        {
            // Authentication auth = new Authentication();
            var res = await Auth.CheckUser(Login);
            return await Task.FromResult(Json(!res));
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
             HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return RedirectToAction("Login", "Account");
        }


    }
}