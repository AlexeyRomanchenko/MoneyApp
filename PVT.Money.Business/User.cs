using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }
    }
}
