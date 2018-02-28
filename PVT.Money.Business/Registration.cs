using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CreateNewUser(string login, string name, string email, string password, int role)
        {

            using (var context = new MoneyContext())
            {
                context.Users.Add(new UserEntity { Username = login, Name = name, Email = email, Password = password, Role_Id = role });
               
                context.SaveChanges();

                var user = context.Users.Include(e => e.Role).SingleOrDefault(saved_user => saved_user.Username == login);
                this.CreateUserPermissions(user);

            }
           
        }

        public void CreateUserAccount(string login, string password)
        {
            using (var context = new MoneyContext())
            {
                Authentication auth = new Authentication();
                User userCheck = auth.CheckAuthentication(login, password);
                context.Accounts.Add(new AccountEntity { UserId = userCheck.Id, USD_Account = "0", EUR_Account = "0", AUD_Account = "0" });
                context.SaveChanges();
            }
        }
        public void CreateUserPermissions(UserEntity user)
        {
            using (var context = new MoneyContext())
            {   
              //  user.Role.Permission = new List<PermissionsRolesEntity>();
              //  user.Role.Permission.Add(new PermissionsRolesEntity { Permissions = new PermissionEntity { Rule = "Changing" } });

                context.SaveChanges();

            }
        }
    }
}
