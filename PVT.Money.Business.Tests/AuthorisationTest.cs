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
        public void AuthorizationOK()
        {
            string login = "Sergey";
            string password = "1234";
            User userCheck = null;

            Authentication autentification = new Authentication();
            userCheck = autentification.CheckAuthentication(login, password);

            Assert.NotNull(userCheck);
        }

        [Test]
        public void AuthorizationOFailed()
        {
            string login = "Sergey2";
            string password = "1234";
            User userCheck = null;

            Authentication autentification = new Authentication();
            userCheck = autentification.CheckAuthentication(login, password);

            Assert.Null(userCheck);
        }
    }
}
