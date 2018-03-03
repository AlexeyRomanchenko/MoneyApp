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
        public static string ConnectionString;

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
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<UserEntity> Users { get; set; }
       // public DbSet<AccountEntity> Accounts { get; set; }

        public DbSet<USD_AccountEntity> UserUSDWallets { get; set; }
        //public DbSet<CountryEntity> Countries { get; set; }
        //public DbSet<LangEntity> Languages { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set;}
        public DbSet<RoleEntity> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionsRolesEntity>().HasKey(p=> new {p.RoleId,p.RuleId });
          
           
        }
        #endregion
    }
}
