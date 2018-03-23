using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Data;

namespace PVT.Money.Business
{
  public  class DataContextProvider : IDataContextProvider
    {
        public MoneyContext CreateContext()
        {
            return new MoneyContext();
        }
    }
}
