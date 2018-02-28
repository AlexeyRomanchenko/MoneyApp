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

                var user = context.Users.Include(e => e.Role).SingleOrDefault(saved_user => saved_user.Name == "Alex");


                var perms = context.Permissions.Include(p => p.Role.Where(t => t.RuleId <= 1));
                //user.Role.Permission = new List<PermissionsRolesEntity>();
                //user.Role.Permission.Add(new PermissionsRolesEntity { Permissions = new PermissionEntity { Rule = "Changing" } });
              //  foreach (var p in perms)
             //   {
                    //var c = p.Rule;
             //   }

               // user.Role.Permission = new List<PermissionsRolesEntity>();
               // user.Role.Permission.Add(new PermissionsRolesEntity { Permissions= new PermissionEntity {Rule = "Changing" } });

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
        public void SelectPermissionsTests()
        {
            using (var context = new MoneyContext())
            {

                var pe = context.UserRoles.Include(p => p.Permission).SingleOrDefault(e=>e.Role=="admin");
                var ptt = context.Permissions.Include(pr => pr.Role).ToList();
                foreach (var i in ptt)
                {
                    var s = i.RuleId;
                    var r = i.Rule;
                }
            }
        }

        
    }


   
}
