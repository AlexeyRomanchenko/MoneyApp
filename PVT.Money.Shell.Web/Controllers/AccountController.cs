using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Models;
using PVT.Money.Business;
using PVT.Money.Shell.Web.Domain;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using PVT.Money.Data;
using PVT.Money.Models;

namespace PVT.Money.Shell.Web.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
       
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
           // Services.IEmailSender emailSender,
            Authentication auth,
            Registration reg)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;
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
                    return RedirectToLocal(returnUrl);
                }

            }
          
            return await Task.FromResult(View());
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (model.Login != null && model.Password != null)
            {
                User user = new User();
                user.Login = model.Login;
                user.Password = model.Password;
                user.Role = 2;

               
                await Reg.CreateNewUser(model.Login, model.Name, model.Email, model.Password, 2);
                return RedirectToLocal("");
            }
            return View();
        }

        [AllowAnonymous]
        public async Task<JsonResult> LoginExists(string Login)
        {
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

        [HttpGet]
        [AllowAnonymous]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await Auth.Logout();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = Auth.ExternalLogin(provider, redirectUrl);
           
            return Challenge(properties.Result, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
                if (remoteError != null)
                {

                return RedirectToAction(nameof(Login));
            }
            ExternalLoginInfo info = await Auth.ExternalLoginInfo();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result =  await Auth.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {

                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Logout));
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
               // return await Task.FromResult(View());
            }
            }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                //var info = await _signInManager.GetExternalLoginInfoAsync();
                var info = await Auth.ExternalLoginInfo();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await Auth.CreateUserExternal(user);
               // var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {

                    // Here stopped continue tomorrow 
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }

            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }



    }
}