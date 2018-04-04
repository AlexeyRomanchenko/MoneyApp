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
        private IDataContextProvider _provider;

        public UserPermissions(IDataContextProvider provider)
        {
            _provider = provider;
        }


        public async Task<IEnumerable<string>> GetPermissions(string id)
        {
            List<string> resultList = new List<string>();
            if (id != null)
            {
                
                using (var context = _provider.CreateContext())
                {

                    var rrole = from roles in context.Roles join userRoles in context.UserRoles on roles.Id equals userRoles.RoleId where userRoles.UserId == "1" select roles.Name;

                    context.SaveChanges();

                }

            }
            
            return await Task.FromResult(resultList);
        }

    }  
}
