using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class Registration
    {
        private List<User> users = new List<User>();

        // Check for the existence of a user with the same login
        public bool IsLoginCorrect(string login)
        {
            foreach (User user in users)
            {
                if (user.Login == login)
                {
                    return false;
                }
            }
            return true;
        }

        // Check for the password complexity
        public bool IsPasswordCorrect(string password)
        {
            int letterCount = 0, numberCount = 0, upperLetterCount = 0;
            if (password.Length >= 8)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (char.IsLetter(password[i]))
                    {
                        letterCount++;
                    }
                    if (char.IsNumber(password[i]))
                    {
                        numberCount++;
                    }
                    if (char.IsUpper(password[i]))
                    {
                        upperLetterCount++;
                    }
                }
                if (letterCount > 0 && numberCount > 0 && upperLetterCount > 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Creating a new user
        public bool CreateNewUser(string name, string login, string password, UserRoles role)
        {
            if (IsLoginCorrect(login) && (IsPasswordCorrect(password)))
            {
                User newUser = new User
                {
                    Login = login,
                    Password = password,
                    Role = role
                };
                users.Add(newUser);
                return true;
            }
            return false;
        }
    }
}
