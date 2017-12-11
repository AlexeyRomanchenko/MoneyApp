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
        private User user;

        public Autentification(string login, string password)
        {
            this.login = login;
            this.password = password;

            users = new List<User>();
            AddUser("Sergey", "1234", "Admin");
            AddUser("Sasha", "4321", "User");

        }

        private void AddUser(string login, string password, string role)
        {
            user = new User();
            user.Login = login;
            user.Password = password;
            user.Role = role;
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
