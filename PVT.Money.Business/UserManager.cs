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
    public class MyUserManager
    {
        private IDataContextProvider _provider;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyUserManager(IDataContextProvider provider, UserManager<ApplicationUser> userManager)
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
    }
}
