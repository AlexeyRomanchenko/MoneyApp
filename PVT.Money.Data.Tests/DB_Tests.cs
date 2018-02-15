using NUnit.Framework;
using System.Linq;
using PVT.Money.Business;
using Microsoft.EntityFrameworkCore;

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

        //[Test]
        //public void CarTableAdd()
        //{
        //    using (var context = new MoneyContext())
        //    {
        //        var Car_entity = new CarEntity { Car_name = "Posrshe", Engine_Id = 1 };
        //        context.Cars.Add(Car_entity);
        //        context.SaveChanges();
        //    }
        //}
    }


   
}
