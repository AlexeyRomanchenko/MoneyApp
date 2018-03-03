using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Business;
using PVT.Money.Shell.Web.Models;

namespace PVT.Money.Shell.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult LoginPermissions(string login)
        {
            UserPermissions permissions = new UserPermissions();
            permissions.GetPermissions(login);
            return Json(permissions);
        }

        [HttpPost]
        public JsonResult AjaxPostCall(Employee employee)
        {
            Employee employee2 = new Employee
            {
                Name = employee.Name,
                Address = employee.Address,
                Location = employee.Location
            };
            return Json(employee2);
        }

    }
    public class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}