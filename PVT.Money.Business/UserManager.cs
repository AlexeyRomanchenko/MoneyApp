using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class UserManager
    {
        public IEnumerable<User> GetUsers()
        {
            List<User> userList = new List<User>();
            using (var context = new MoneyContext())
            {

                var user = context.Users;
                foreach (var u in user)
                {
                    User usr = new User();
                    usr.Login = u.Username;
                    usr.Password = u.Password;
                    usr.Role = u.Role_Id;
                    userList.Add(usr);
                }

            }
            return userList;
        }
    }
}
