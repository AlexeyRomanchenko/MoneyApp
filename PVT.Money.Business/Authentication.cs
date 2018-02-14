using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PVT.Money.Business
{
    public class Authentication
    {
        private List<User> users;

        public Authentication()
        {
            users = new List<User>();
          //  AddUser("Sergey", "1234", UserRoles.Admin);
          //  AddUser("Sasha", "123456", UserRoles.User);
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
                context.Users.Add(new UserEntity {Username = login,Password= password,Role_Id = 1 });
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
                    return entity == null ? null : new User { Login = entity.Username, Password = entity.Password };
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

        public bool CheckRole(UserRoles role, User user)
        {
            return (user.Role == role);            
        }

    }
}
