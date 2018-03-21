using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        /// переделать чтобы все было вне соединения БД  
        /// </summary>
        /// 
        public async Task<IEnumerable<string>> GetPermissions(string login)
        {

            List<string> resultList = new List<string>();
            using (var context = new MoneyContext())
            {
                var user = await context.Users.Include(e => e.Role).SingleOrDefaultAsync(saved_user => saved_user.Username == login);
                string userRole = user.Role.Role;

                var res = await context.UserRoles.Include(r => r.Permission).ThenInclude(e => e.Permissions).Where(q => q.Role == userRole).ToListAsync();
                foreach (var c in res)
                {
                    var rw = c.Permission.Select(e => e.Permissions).ToList();
                    foreach (var role in rw)
                    {
                        var result = role.Role.Select(e => e.Permissions.Rule).FirstOrDefault();
                        resultList.Add(result);
                    }
                }

                context.SaveChanges();

            }
            return await Task.FromResult(resultList);
        }
    }  
}
