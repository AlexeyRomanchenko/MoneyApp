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
            string name = "Vasya";
            Enums.UserRoles uRoleAdmin = Enums.UserRoles.Admin;

            Models.UserModel uModel = new Models.UserModel();

            uModel.Login = login;
            uModel.Password = password;
            uModel.Name = name;
            uModel.Role = uRoleAdmin;
        }
    }
}
