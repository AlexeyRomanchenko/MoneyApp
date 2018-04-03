using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Business
{
   

    public class Registration
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private Authentication _auth;
        private IDataContextProvider _provider;

        public Registration(Authentication auth,IDataContextProvider provider,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager
            )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _provider = provider;
            _signInManager = signInManager;
            _emailSender = emailSender;
           
        }

        private List<User> users = new List<User>();


        // Creating a new user
        public async Task CreateNewUser(string login, string name, string email, string password, int role)
        {

            ApplicationUser userRegister = new ApplicationUser { UserName = name, Email = email };
            var result = await _userManager.CreateAsync(userRegister, password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(userRegister);
                var callbackUrl = "google.com";
                await _emailSender.SendEmailConfirmationAsync(email, callbackUrl);

                await _signInManager.SignInAsync(userRegister, isPersistent: false);

               await _userManager.AddToRoleAsync(userRegister, "Admin");

            }           
        }
        
    }
}
