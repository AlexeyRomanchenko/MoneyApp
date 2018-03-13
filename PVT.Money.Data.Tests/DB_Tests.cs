using NUnit.Framework;
using System.Linq;
using PVT.Money.Business;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.Generic;

namespace PVT.Money.Data.Tests
{
    [TestFixture]
    [Category("�������������� �����")]
    public class DB_Tests
    {
       public DB_Tests() {
           // DataFaccade dbFaccade = new DataFaccade();
           // dbFaccade.DbMigrate("Server=(localdb)\\MSSQLLocalDB;Database=MoneyExchange;Integrated Security=true;");
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
                List<string> resultList = new List<string>();
                var res = context.UserRoles.Include(r => r.Permission).ThenInclude(e=>e.Permissions).Where(q=>q.Role=="Admin").ToList();
                foreach (var c in res)
                {
                    var rw = c.Permission.Select(e => e.Permissions).ToList();
                    foreach (var role in rw)
                    {
                        var result = role.Role.Select(e=>e.Permissions.Rule).FirstOrDefault();
                        resultList.Add(result);
                    }
                }
                   // var ww = context.Languages.Include(e => e.Countries).ThenInclude(e => e.Countries).Where(w=>w.Lang=="RU").ToList();
               
                
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
                   //var e = res.UsdValue;
                   // USDList.Add(e);
                }
                Assert.NotNull(USDList);
            }

        }

        
    }


   
}
