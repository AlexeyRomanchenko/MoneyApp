using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Data;

namespace PVT.Money.Business.Tests
{
    class FakeAuth : Authentication
    {
        public FakeAuth(params User[] user)
        {
           // List<User[]> collection = new List<User[]>();
           // collection.Add(user);

            using (var context = new InMemoryContext())
            {
                foreach (var i in user)
                {
                    //context.Users.Add(new UserEntity { Username = i.Login,Password = i.Password,Role = 1 });
                }
                context.SaveChanges();               
            }
        }

        public override MoneyContext CreateContext()
        {
            return new InMemoryContext();
        }
    }
}
