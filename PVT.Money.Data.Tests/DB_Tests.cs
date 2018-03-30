using NUnit.Framework;
using System.Linq;
using PVT.Money.Business;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace PVT.Money.Data.Tests
{
    [TestFixture]
    [Category("Интеграционные тесты")]
    public class DB_Tests
    {
        private IDataContextProvider _provider;
        public DB_Tests(IDataContextProvider provider) {
            _provider = provider;
          //  MoneyContext.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MoneyExchange;Integrated Security=true;";
            
        }
        [Test]
        public void UsersTableExists()
        {
            using (var context = _provider.CreateContext())
            {
                var users = context.OldUsers.ToArray();
                Assert.IsNotNull(users);
            }

        }

        [Test]
        public void UsersTableAdd()
        {
            using (var context = _provider.CreateContext())
            {
                //  Authentication auth = new Authentication();
                // auth.AddUser("Alex","0505",1);
                var entity = new UserEntity { Username = "Alex", Password = "pswd", Role_Id = 1 };
                context.OldUsers.Add(entity);
                context.SaveChanges();

                var user = context.OldUsers.Include(e=>e.Role).SingleOrDefault(saved_user => saved_user.ID == entity.ID);               
                var role = entity.Role.Role;
                Assert.IsNotNull(role);
            }

        }
       
        [Test]
        public void UserPermissions()
        {
            using (var context = _provider.CreateContext())
            {
                List<string> resultList = new List<string>();



               // var resultMany = from roles in context.UserRoles join userPerm in context.Permissions on roles.ID equals userPerm.Role select userPerm.Rule;
                var res = context.OldUserRoles.Include(r => r.Permission).ThenInclude(e=>e.Permissions).Where(q=>q.Role=="Admin").ToList();
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
            using (var context = _provider.CreateContext())
            {

                var roleResult = from users in context.OldUsers join role in context.OldUserRoles on users.ID equals role.ID where users.Name == "Alexey" select role.Role;
                foreach (var r in roleResult)
                {
                    string res = r;
                }

                   
                var user = context.OldUsers.Include(e => e.Role).SingleOrDefault(saved_user => saved_user.Name == "Alexey");
                string userRole = user.Role.Role;


                Assert.IsNotNull(userRole);
               

            }
        }

        [Test]
        public void SelectUsers()
        {
            using (var context = _provider.CreateContext())
            {
                List<UserEntity> userList = new List<UserEntity>();
                var user = context.OldUsers;
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
            using (var context = _provider.CreateContext())
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

        [Test]
        public async Task SelectWalletByWalletId()
        {
            USD_AccountEntity wallet;
            using (var context = _provider.CreateContext())
            {
                wallet = await context.UserUSDWallets.Include(e => e.User).Where(e => e.WalletId == 1).SingleOrDefaultAsync();
            }
            Assert.NotNull(wallet);
        }

        [Test]
        public void SelectOneCurrWalletsTransf()
        {
            
            using (var context = _provider.CreateContext())
            {
              var wall = from wallets in context.UserUSDWallets join user in context.OldUsers on wallets.UserId equals user.ID where user.ID == 1 && wallets.WalletId != 1 && wallets.Currency == "USD" select wallets;
                foreach (var wallet in wall)
                {
                    string WalletName = wallet.WalletName;
                }
            }
        }





        

        
    }


   
}
