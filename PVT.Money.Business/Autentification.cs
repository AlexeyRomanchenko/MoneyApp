using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class Autentification
    {

        private string login;
        private string password;
        private List<User> users;

        public Autentification(string login, string password)
        {
            this.login = login;
            this.password = password;

            // for test
            users = new List<User>();

            User user = new User();
            user.Login = "Sergey";
            user.Password = "1234";
            user.Role = "Admin";
            users.Add(user);

            user = new User();
            user.Login = "Sasha";
            user.Password = "4321";
            user.Role = "User";
            users.Add(user);

        }

        public User CheckAutentification()
        {

            User userResult = null;

            foreach (User user in users)
            {
                if (user.Login == this.login && user.Password == this.password)
                {
                    userResult = user;
                }
            }

            return userResult;
        }


        public bool CheckRole(string role, User user)
        {
            return (user.Role == role);            
        }

    }
}
