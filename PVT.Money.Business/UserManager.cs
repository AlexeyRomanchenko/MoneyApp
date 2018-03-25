using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Business
{
    public class UserManager
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            UserEntity[] user;
            List<User> userList = new List<User>();
            using (var context = new MoneyContext())
            {
                user = context.Users.ToArray();
            }

            foreach (var u in user)
            {
                User usr = new User();
                usr.Id = u.ID;
                usr.Login = u.Username;
                usr.Password = u.Password;
                usr.Role = u.Role_Id;
                userList.Add(usr);
            }
            return userList;
        }
    }
}
