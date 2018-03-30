using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Data;
using Microsoft.EntityFrameworkCore;

namespace PVT.Money.Business.Tests
{
    class InMemoryContext : MoneyContext
    {
        private string db;
        private IDataContextProvider _provider;


        public InMemoryContext(string _db)
        {
            db = _db;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(db);
        }
    }
}
