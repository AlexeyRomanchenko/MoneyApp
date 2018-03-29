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

namespace PVT.Money.Business
{
    // Один класс- одна функция - спагетти код
    // Всё норм по логике
    public class Authentication
    {
        private List<User> users;

        internal Authentication()
        {
            users = new List<User>();
          
        }
      public virtual MoneyContext CreateContext()
        {
            DbContextOptionsBuilder<MoneyContext> contextOptionsBuilder = new DbContextOptionsBuilder<MoneyContext>();
            contextOptionsBuilder.UseSqlServer(connectionString);
            DbContextOptions<MoneyContext> options = contextOptionsBuilder.Options;
            MoneyContext different_context = new MoneyContext(options);
            return different_context;
        }
      public void AddUser(string login, string password, int role)
        {
            using (var context = CreateContext())
            {
                context.Users.Add(new UserEntity { Username = login,Password= password,Role_Id = 1 });
                context.SaveChanges();
            }
         }

      
        public async Task<User> CheckAuthentication(string login, string password)
        {
            try
            {
                using (var context = CreateContext())
                {
                    UserEntity entity = await context.Users.SingleOrDefaultAsync(user => user.Username == login && user.Password == password);
                    return entity == null ? null : new User {Id= entity.ID,Login = entity.Username, Password = entity.Password };
                }
            }
            catch {
                return null;
            }
                
        }

        public async Task<bool> CheckUser(string login)
        {
            try
            {
                using (var context = CreateContext())
                {
                    bool entity = await context.Users.AnyAsync(user => user.Username == login);
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
                using (var context = CreateContext())
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
                using (var context = CreateContext())
                {
                    var userName =  await context.Users.Include(e=>e.Role).SingleAsync(username => username.Username == user.Login);
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
