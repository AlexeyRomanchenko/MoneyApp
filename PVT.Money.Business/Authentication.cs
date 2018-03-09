using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PVT.Money.Business
{
    // Один класс- одна функция - спагетти код
    // Всё норм по логике
    public class Authentication
    {
        private List<User> users;

        public Authentication()
        {
            users = new List<User>();
          
        }
      public virtual MoneyContext CreateContext()
        {
            MoneyContext different_context = new MoneyContext();
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

      
        public User CheckAuthentication(string login, string password)
        {
            try
            {
                using (var context = CreateContext())
                {
                    UserEntity entity = context.Users.SingleOrDefault(user => user.Username == login && user.Password == password);
                    return entity == null ? null : new User {Id= entity.ID,Login = entity.Username, Password = entity.Password };
                }
            }
            catch {
                return null;
            }
                
        }

        public bool CheckUser(string login)
        {
            try
            {
                using (var context = CreateContext())
                {
                    bool entity = context.Users.Any(user => user.Username == login);
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

        public UserEntity CheckRole(User user)
        {
            UserEntity roles = new UserEntity();
            try
            {
                using (var context = CreateContext())
                {
                    var userName = context.Users.Include(e=>e.Role).Single(username => username.Username == user.Login);
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
