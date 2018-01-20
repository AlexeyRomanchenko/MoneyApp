using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Business;

namespace PVT.Money.Business.Tests
{
    [TestFixture]
    class UnitTest
    {

        [Test]
        public void DelegateTest() {

            MoneyClass euro = new MoneyClass(100m, Currency.EUR);
            CurrExchange new_operation = new CurrExchange(euro,Currency.USD);

            Account millions = new Account(new_operation.GetSecondNominal());

            millions.RegisterDelegate(new Account.AccountDelegate(Added));

            void Added(decimal my_fee)
            {
                millions.Add(my_fee);
            }
            decimal my = millions.GetMoney;


        }

    }
}
