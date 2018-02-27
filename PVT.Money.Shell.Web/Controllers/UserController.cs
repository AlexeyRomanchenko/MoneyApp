using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Business;

namespace PVT.Money.Shell.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult LoginPermissions(string login)
        {
            UserPermissions permissions = new UserPermissions();
            permissions.GetPermissions(login);
            return View();
        }
    }
}