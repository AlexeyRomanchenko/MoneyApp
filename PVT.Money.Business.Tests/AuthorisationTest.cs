using NUnit.Framework;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

using PVT.Money.Data;
using Microsoft.Extensions.Configuration;

namespace PVT.Money.Business.Tests
{
    [TestFixture]
    public class AuthorizationTest
    {
       
       
        [Test]
        public async Task AuthorizationOFailed()
        {
            string login = "Sergey2";
            string password = "1234";
            User userCheck = null;

            Authentication autentification = new Authentication(new InMemoryDataContextProvider(BusinessFaccade.Configuration.GetConnectionString("database")));
            userCheck = await autentification.CheckAuthentication(login, password);

            Assert.Null(userCheck);
        }

        [Test]
        public async Task FakeAuthenticationConnection()
        {
            User user = new User();
            user.Login = "Alexey";
           user.Password = "1234";
            Authentication autentification = new Authentication(new InMemoryDataContextProvider(BusinessFaccade.Configuration.GetConnectionString("database")));
            

           User userCheck = await autentification.CheckAuthentication(user.Login, user.Password);

            Assert.NotNull(userCheck);
        }

        [Test]
        public async Task FakeAuthenticationGetIDCreateAccountOK()
        {
            User user = new User();
            user.Login = "Alexey";
            user.Password = "1234";
            Authentication autentification = new Authentication(new InMemoryDataContextProvider(BusinessFaccade.Configuration.GetConnectionString("database")));
           
            User userCheck = await autentification.CheckAuthentication(user.Login, user.Password);

           

            Assert.NotNull(userCheck);
        }

    }
}
