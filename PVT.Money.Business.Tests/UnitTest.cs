﻿using NUnit.Framework;
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
        public void MoneyClassTest()
        {
            //arrange
            MoneyClass USD = new MoneyClass(100.5m, Currency.USD);
            MoneyClass EUR = new MoneyClass(100m, Currency.EUR);
            //act

            MoneyClass euro = new MoneyClass(100m, Currency.EUR);
            CurrExchange new_operation = new CurrExchange(euro, Currency.USD);

            Account millions = new Account(new_operation.GetSecondNominal());

             // millions.RegisterDelegate(new Account.AccountDelegate(Added));
        }

        [Test]
        public void ConvertMoneyFrom()
        {
            //arrange
           MoneyClass australian_dollar = new MoneyClass(100.5m,Currency.AUD);
           MoneyClass euro = new MoneyClass(100.5m, Currency.EUR);
            //act
              CurrExchange new_operation =new CurrExchange(australian_dollar, Currency.USD);
              CurrExchange new_operation_2 = new CurrExchange(euro, Currency.USD);

            //assert
            Assert.NotNull(new_operation.GetSecondNominal());
            Assert.NotNull(new_operation_2.GetSecondNominal());
               

        }

    }
}
