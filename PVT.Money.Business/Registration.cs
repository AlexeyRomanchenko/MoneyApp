using Microsoft.EntityFrameworkCore;
using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Business
{
    public class Registration
    {
        private List<User> users = new List<User>();


        // Creating a new user
        public async Task CreateNewUser(string login, string name, string email, string password, int role)
        {

            using (var context = new MoneyContext())
            {
                await context.Users.AddAsync(new UserEntity { Username = login, Name = name, Email = email, Password = password, Role_Id = role });
               
                context.SaveChanges();

                var user = await context.Users.Include(e => e.Role).SingleOrDefaultAsync(saved_user => saved_user.Username == login);
                this.CreateUserPermissions(user);

            }
           
        }

        public async void CreateUserAccount(string login, string password)
        {
            using (var context = new MoneyContext())
            {
                Authentication auth = new Authentication();
                User userCheck = await auth.CheckAuthentication(login, password);
              
                context.SaveChanges();
            }
        }
       
    }
}
