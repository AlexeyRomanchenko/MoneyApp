using PVT.Money.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    public class BusinessFaccade
    {
        public void UseDataFaccade(string connString)
        {
            DataFaccade dbFaccade = new DataFaccade();
            dbFaccade.DbMigrate(connString);
        }
    }
}
