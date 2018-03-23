using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Data;

namespace PVT.Money.Business.Tests
{
   public class InMemoryDataContextProvider : IDataContextProvider
    {
        private string db;
        public MoneyContext CreateContext()
        {
            return new InMemoryContext(db);
        }
        public InMemoryDataContextProvider(string dbName)
            {
            db = dbName;
            }
    }
}
