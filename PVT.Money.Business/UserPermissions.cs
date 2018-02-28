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
                //select p.Rules from Permissions p, UserRoles r, PermissionsRoles pr where r.role = 'admin' and r.Role_Id = pr.Role_Id and p.Rule_Id = pr.Rule_Id
                var permissions = context.Permissions.Where(e => e.Rule == "changing");
                var perms = context.Permissions.Include(p => p.Role);
                //user.Role.Permission = new List<PermissionsRolesEntity>();
                //user.Role.Permission.Add(new PermissionsRolesEntity { Permissions = new PermissionEntity { Rule = "Changing" } });
                foreach (var p in perms)
                {
                    var c = p.Rule;
                }
                //context.Permissions.Include(e => e.Rule);
                context.SaveChanges();

            }
        }
    }
}
