﻿using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PVT.Money.Business
{
    public class UserPermissions
    {
        private IDataContextProvider _provider;

        public UserPermissions(IDataContextProvider provider)
        {
            _provider = provider;
        }


        public async Task<IEnumerable<string>> GetPermissions(string user_id)
        {

            List<string> resultList = new List<string>();
            using (var context = _provider.CreateContext())
            {

                var rrole = from roles in context.Roles join userRoles in context.UserRoles on roles.Id equals userRoles.RoleId where userRoles.UserId == "1" select roles.Name;


              //  var user = await context.OldUsers.Include(e => e.Role).SingleOrDefaultAsync(saved_user => saved_user.Username == login);
               // string userRole = user.Role.Role;

                //var res = await context.OldUserRoles.Include(r => r.Permission).ThenInclude(e => e.Permissions).Where(q => q.Role == userRole).ToListAsync();
                //foreach (var c in res)
                //{
                //    var rw = c.Permission.Select(e => e.Permissions).ToList();
                //    foreach (var role in rw)
                //    {
                //        var result = role.Role.Select(e => e.Permissions.Rule).FirstOrDefault();
                //        resultList.Add(result);
                //    }
                //}

                context.SaveChanges();

            }
            return await Task.FromResult(resultList);
        }
    }  
}
