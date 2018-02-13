using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Data
{
    public class MoneyContext : DbContext 
    {
        #region EF_6_Connection
        //EF 6 Connection

        //public MoneyContext() : base(@"Server=(localdb)\MoneyExchange;Integrated Security=true;")
        //{
        //    Database.CreateIfNotExists();
        //}

        #endregion

        #region EF_7_Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MoneyExchange;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        #endregion
    }
}
