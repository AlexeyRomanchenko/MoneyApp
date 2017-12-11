using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Business;

namespace PVT.Money.Business.Tests
{
    [TestFixture]
    public class AuthorisationTest
    {
        [Test]
        public void AuthorisationOK()
        {
            string login = "tdfgdfg";
            string password = "123abc123";

            User userCheck = new User();

            Autentification autentification = new Autentification(login, password);
            userCheck = autentification.CheckAutentification(); 
        }
    }
}
