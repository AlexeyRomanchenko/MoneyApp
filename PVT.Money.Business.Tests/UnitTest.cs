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
        public void MoneyClassTest() {
            //arrange
           MoneyClass USD = new MoneyClass(100.5m,Currency.USD);
           MoneyClass EUR = new MoneyClass(100m, Currency.EUR);
            //act

            decimal USD_test = USD.GetNominal();
            decimal EUR_test = EUR.GetNominal();
            //assert
            Assert.AreNotEqual(USD_test,0);
            Assert.AreNotEqual(EUR_test, 0);
        }    

        [Test]
        public void ConvertMoneyFrom()
        {

            //arrange
            MoneyClass australian_dollar = new MoneyClass(100m,Currency.EUR);

            //act
            CurrExchange new_operation =new CurrExchange(australian_dollar, Currency.AUD);


            //assert
            Assert.AreEqual(new_operation.GetSecondNominal(), 29.7);


        }

    }
}
