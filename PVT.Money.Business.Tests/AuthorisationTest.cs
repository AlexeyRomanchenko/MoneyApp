using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Business;

namespace PVT.Money.Business.Tests
{
    [TestFixture]
    public class AuthorizationTest
    {
       
        [Test]
        public void AuthorizationOFailed()
        {
            string login = "Sergey2";
            string password = "1234";
            User userCheck = null;

            Authentication autentification = new FakeAuth();
            userCheck = autentification.CheckAuthentication(login, password);

            Assert.Null(userCheck);
        }

        [Test]
        public void FakeAuthenticationConnection()
        {
            User user = new User();
            user.Login = "Alexey";
           user.Password = "1234";
            FakeAuth autentification = new FakeAuth(user);
            autentification.CreateContext();

           User userCheck = autentification.CheckAuthentication(user.Login, user.Password);

            Assert.NotNull(userCheck);
        }

    }
}
