using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class Authentication
    {
        private List<User> users;

        public Authentication()
        {
            users = new List<User>();
            AddUser("Sergey", "1234", UserRoles.Admin);
            AddUser("Sasha", "123456", UserRoles.User);
        }

        private void AddUser(string login, string password, UserRoles role)
        {
            User user = new User();
            user.Login = login;
            user.Password = password;
            user.Role = role;
            users.Add(user);
        }

        public User CheckAuthentication(string login, string password)
        {
            User checkedUser = null;

            foreach (User user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    checkedUser = user;
                }
            }

            return checkedUser;
        }


        public bool CheckRole(UserRoles role, User user)
        {
            return (user.Role == role);            
        }

    }
}
