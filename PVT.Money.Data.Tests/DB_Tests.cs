using NUnit.Framework;
using System.Linq;
using PVT.Money.Business;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.Generic;

namespace PVT.Money.Data.Tests
{
    [TestFixture]
    [Category("Интеграционные тесты")]
    public class DB_Tests
    {
       public DB_Tests() {
            DataFaccade dbFaccade = new DataFaccade();
            dbFaccade.DbMigrate("Server=(localdb)\\MSSQLLocalDB;Database=MoneyExchange;Integrated Security=true;");
        }
        [Test]
        public void UsersTableExists()
        {
            using (var context = new MoneyContext())
            {
                var users = context.Users.ToArray();
                Assert.IsNotNull(users);
            }

        }

        [Test]
        public void UsersTableAdd()
        {
            using (var context = new MoneyContext())
            {
                //  Authentication auth = new Authentication();
                // auth.AddUser("Alex","0505",1);
                var entity = new UserEntity { Username = "Alex", Password = "pswd", Role_Id = 1 };
                context.Users.Add(entity);
                context.SaveChanges();

                var user = context.Users.Include(e=>e.Role).SingleOrDefault(saved_user => saved_user.ID == entity.ID);               
                var role = entity.Role.Role;
                Assert.IsNotNull(role);
            }

        }

[Test]
        public void UserPermissions()
        {
            using (var context = new MoneyContext())
            {
                var res = context.UserRoles.Include(r => r.Permission).SingleOrDefault(p=>p.Role=="Admin");
                var res2 = res.Permission; 
               
                var perms = context.Permissions.Include(p => p.Role.Where(t => t.RuleId <= 1));

                context.SaveChanges();
                 
            }
        }

        [Test]
        public void CheckRoleTests()
        {
            using (var context = new MoneyContext())
            {

                var user = context.Users.Include(e => e.Role).SingleOrDefault(saved_user => saved_user.Name == "Alex");
                string userRole = user.Role.Role;


                Assert.IsNotNull(userRole);
               

            }
        }

        [Test]
        public void SelectUsers()
        {
            using (var context = new MoneyContext())
            {
                List<UserEntity> userList = new List<UserEntity>();
                var user = context.Users;
                foreach (var u in user)
                {
                    
                    userList.Add(u);
                }
                Assert.IsNotNull(userList);
            }
        }

        [Test]
        public void SelectUSDWalletsTests()
        {
            List<string> USDList = new List<string>();
            using (var context = new MoneyContext())
            {
                var wall = context.UserUSDWallets.Include(u => u.User).Where(u=>u.User.Username=="Alexey");
                foreach (var res in wall)
                {
                   var e = res.UsdValue;
                    USDList.Add(e);
                }
                Assert.NotNull(USDList);
            }

        }

        
    }


   
}
