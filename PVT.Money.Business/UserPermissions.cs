using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PVT.Money.Business
{
    public class UserPermissions
    {
        public void GetPermissions(string login) {
            using (var context = new MoneyContext())
            {

                var user = context.Users.Include(e => e.Role).SingleOrDefault(saved_user => saved_user.Username == login);

                user.Role.Permission = new List<PermissionsRolesEntity>();
                user.Role.Permission.Add(new PermissionsRolesEntity { Permissions = new PermissionEntity { Rule = "Changing" } });

                context.SaveChanges();

            }
        }
    }
}
