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

            service.AddTransient<Authentication>(u=>new Authentication());
            
            //DataFaccade dbFaccade = new DataFaccade();
            //dbFaccade.DbMigrate(connString);
        }
    }
}
