using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Data;
using Microsoft.EntityFrameworkCore;

namespace PVT.Money.Business.Tests
{
    class InMemoryContext :MoneyContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDB");
        }
    }
}
