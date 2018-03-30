using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace PVT.Money.Business
{
  public  class DataContextProvider : IDataContextProvider
    {
        private string connectionString;
        public MoneyContext CreateContext()
        {
            connectionString = BusinessFaccade.Configuration.GetConnectionString("database");

            DbContextOptionsBuilder<MoneyContext> contextOptionsBuilder = new DbContextOptionsBuilder<MoneyContext>();
           // contextOptionsBuilder.UseSqlServer(connectionString);
            DbContextOptions<MoneyContext> options = contextOptionsBuilder.Options;

          
            return new MoneyContext(options);
        }
    }
}
