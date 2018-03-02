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
        DB_Tests() {

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

               

                //PermissionEntity permission = new PermissionEntity() { Permission = permissionName };
                //context.Permissions.Add(permission);
                //UserRoleEntity role = new UserRoleEntity() { Role = roleName };
                //context.Roles.Add(role);

                //context.SaveChanges();

                ////Act
                //role.RolePermissions = new List<PermissionToRoleEntity>();
                //role.RolePermissions.Add(new PermissionToRoleEntity() { Permission = permission });
                //context.Roles.Update(role);
                //context.SaveChanges();

                //UserRoleEntity newRole = context.Roles.Include(r => r.RolePermissions).SingleOrDefault(r => r.ID == role.ID);
                //PermissionEntity newPermission = context.Permissions.Include(p => p.PermissionRoles).SingleOrDefault(p => p.ID == permission.ID);

                //PermissionEntity rolePermission = newRole.RolePermissions.SingleOrDefault(p => p.Permission.ID == permission.ID).Permission;
                //UserRoleEntity permissionRole = newPermission.PermissionRoles.SingleOrDefault(p => p.Role.ID == role.ID).Role;

[Test]
        public void UserPermissions()
        {
            using (var context = new MoneyContext())
            {
                var res = context.UserRoles.Include(r => r.Permission).SingleOrDefault(p=>p.Role=="Admin");
               // var res2 = res.Permission.SingleOrDefault(p=>p.Permissions.RuleId == )
               
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
