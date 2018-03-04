using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Data
{
    public class DataFaccade
    {
        public void DbMigrate(string connString) {

            MoneyContext.ConnectionString = connString;
            using (var context = new MoneyContext())
            {           
                //context.Database.Migrate();
            }
        }
    }
}
