using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

namespace PVT.Money.Business
{
    // Один класс- одна функция - спагетти код
    // Всё норм по логике
    public class Authentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private IDataContextProvider _provider;

        internal string connectionString;


        public Authentication(IDataContextProvider provider, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _provider = provider;
        }
        public void AddUser(string login, string password, int role)
        {
            using (var context = _provider.CreateContext())
            {
                context.OldUsers.Add(new UserEntity { Username = login, Password = password, Role_Id = 1 });
                context.SaveChanges();
            }
        }

        public async Task<AuthenticationProperties> ExternalLogin(string provider, string redirectUrl)
        {
            var properties =  _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return properties;
        }

        public async Task<SignInResult> ExternalLoginSignInAsync(string LoginProvider, string ProviderKey,bool isPersistent, bool bypassTwoFactor)
        {
            var result = await _signInManager.ExternalLoginSignInAsync(LoginProvider, ProviderKey, isPersistent, bypassTwoFactor);
            return result;
        }
        public async Task<ExternalLoginInfo> ExternalLoginInfo()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            return info;
        }

        public async Task<IdentityResult> CreateUserExternal(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user);
            return result;
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<User> CheckAuthentication(string login, string password)
        {

            User user = new User(); 
            try
            {

                SignInResult result = await _signInManager.PasswordSignInAsync(login, password, true, false);
                if (result.Succeeded)
                {
                    user.Id = 1;
                    user.Login = login;
                }

            }
            catch {
                return null;
            }
            return user;   
        }

        public async Task<bool> CheckUser(string login)
        {
            try
            {
                using (var context = _provider.CreateContext())
                {
                    bool entity = await context.OldUsers.AnyAsync(user => user.Username == login);
                    return entity;
                  
                }
            }
            catch
            {
                return false;
            }

        }
        public Wallet CheckUserAccount(int Id)
        {
            Wallet acc = new Wallet();
            try
            {
                using (var context = _provider.CreateContext())
                {
                    //AccountEntity entity = context.Accounts.SingleOrDefault(account => account.UserId == Id);
                    // return entity == null ? null : new Wallet { UserId = entity.UserId, USD_Account = entity.USD_Account, EUR_Account = entity.EUR_Account, AUD_Account = entity.AUD_Account };

                    return acc;
                }
            }
            catch
            {
             
                return acc;
            }

        }

        public async Task<UserEntity> CheckRole(User user)
        {
            UserEntity roles = new UserEntity();
            try
            {
                using (var context = _provider.CreateContext())
                {
                    var userName =  await context.OldUsers.Include(e=>e.Role).SingleAsync(username => username.Username == user.Login);
                    string userRole = userName.Role.Role;
                    return userName;
                }
            }
            catch
            {
                return roles;
            }
        }

    }
}
