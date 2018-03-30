using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public static class BusinessFaccade
    {
        public static IConfiguration Configuration { get;  set; }

        public static void ConfigurationServices(IServiceCollection service)
        {
            DataFaccade.Configuration = Configuration;
            DataFaccade.ConfigureServices(service);
            DataFaccade.InitDatabase(Configuration.GetConnectionString("database"));
            service.AddTransient<Authentication>();
            service.AddTransient<Registration>();
            service.AddTransient<UserPermissions>();
            service.AddTransient<TransfertManager>();
            service.AddTransient<UserWallets>();
            service.AddTransient<MyUserManager>();
            service.AddTransient<IDataContextProvider, DataContextProvider>();
            
            
        }
    }
}
