using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PVT.Money.Business
{
    public class MyUserManager
    {
        private IDataContextProvider _provider;
        private readonly UserManager<ApplicationUser> _userManager;
       // private EmailService _emailService;

        public MyUserManager(IDataContextProvider provider, UserManager<ApplicationUser> userManager)//
        {
            _userManager = userManager;
            _provider = provider;
        }


        public async Task<string> GetUserId(string username)
        {
            
            using (var context = _provider.CreateContext())
            {
                var user = await _userManager.Users.Where(e => e.UserName == username).SingleAsync();
                return await Task.FromResult(user.Id);
            }
        }


        public async Task<IEnumerable<User>> GetUsers()
        {
            ApplicationUser[] users;
            User[] user;
            List<User> userList = new List<User>();
            using (var context = _provider.CreateContext())
            {
                 users = await _userManager.Users.ToArrayAsync();
                
            }

            foreach (var u in users)
            {
                User usr = new User();
                usr.Id = u.Id;
                usr.Login = u.UserName;
                userList.Add(usr);
            }
            return userList;
        }


        public async Task<User> GetUserIdByName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            User usr = new User();
            usr.Id = user.Id;
            usr.Login = user.UserName;
            usr.Email = user.Email;
            
            return usr;
        }

        public async Task<string> GenerateCode(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            return code;
        }
        public async Task SendEmail(string email, string callbackUrl)
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(email, "Reset Password",
                $"Для сброса пароля пройдите по ссылке: <a href='{callbackUrl}'>link</a>");
        }

        public async Task<bool> ConfirmationUser(User user,string Code, string Password )
        {
            Code = Code.Replace(" ", "+");
            ApplicationUser usr = new ApplicationUser();
            usr.Id = user.Id;
            usr.UserName = user.Login;
            usr.Email = user.Email;
            var result = await _userManager.ResetPasswordAsync(usr, Code, Password);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
