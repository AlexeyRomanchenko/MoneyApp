using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Data;
using Microsoft.EntityFrameworkCore;

namespace PVT.Money.Business.Tests
{
    class InMemoryContext :MoneyContext
    {
        private string db;
        public InMemoryContext(string dbName)
        {
            db = dbName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(db);
        }
    }
}
