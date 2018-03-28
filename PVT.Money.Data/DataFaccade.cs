using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace PVT.Money.Data
{
    public static class DataFaccade
    {
        public static IConfiguration Configuration { get;  set; }

        public static void InitDatabase(string connectionString)
        {
            DbContextOptionsBuilder<MoneyContext> contextOptionsBuilder = new DbContextOptionsBuilder<MoneyContext>();
            contextOptionsBuilder.UseSqlServer(connectionString);
            DbContextOptions<MoneyContext> options = contextOptionsBuilder.Options;
            using (var context = new MoneyContext(options))
            {
                context.Database.Migrate();
            }
        }



        public static void ConfigureServices(IServiceCollection service)
        {

            service.AddDbContext<MoneyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("database")));
            service.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<MoneyContext>()
               .AddDefaultTokenProviders();

            MoneyContext.ConnectionString = Configuration.GetConnectionString("database");
          
        }
    }
}
