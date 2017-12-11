using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    class Autentification
    {

        private string login;
        private string password;
        private User user;

        public Autentification(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public User CheckAutentification()
        {

            User userResult = new User();
            
            foreach (User user in List<User>)
            {
                if (user.Login == this.login && user.Password == this.password)
                {
                    userResult = user;
                }
            }
                        
            return userResult;
        }

    }
}
