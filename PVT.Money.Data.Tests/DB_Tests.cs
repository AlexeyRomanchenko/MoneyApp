using NUnit.Framework;
using System.Linq;

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
    }
}
