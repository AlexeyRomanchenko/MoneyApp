using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Data;
namespace PVT.Money.Business
{
    public interface IDataContextProvider
    {
        MoneyContext CreateContext();
    }
}
