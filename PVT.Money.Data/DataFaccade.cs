using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace PVT.Money.Data
{
    public static class DataFaccade
    {
        public static IConfiguration Configuration { get;  set; }

        public static void ConfigureServices(IServiceCollection service)
        {
            MoneyContext.ConnectionString = Configuration.GetConnectionString("database");
            using (var context = new MoneyContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
