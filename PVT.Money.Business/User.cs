﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
