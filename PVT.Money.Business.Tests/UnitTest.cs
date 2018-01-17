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
           MoneyClass EUR = new MoneyClass(100m, , Currency.EUR);
            //act

            decimal USD_test = USD.GetNominal();
            decimal EUR_test = EUR.GetNominal();
            //assert
            Assert.AreNotEqual(USD_test,0);
            Assert.AreNotEqual(EUR_test, 0);
        }

            // В таком assert  отлавливаем Exception  (only for me)
            // Assert.Throws<ArgumentNullException>(() => new MoneyClass(0, "USD"));
    


        [Test]
        public void MoneyClassFailedCurrency()
        { 
            //assert
            Assert.Throws<ArgumentNullException>(() => new MoneyClass(10.5m,Currency.AUD));

        }

        [Test]
        public void ConvertMoneyFrom()
        {
            //arrange
          //  MoneyClass australian_dollar = new MoneyClass(100.5m,"AUD");
           // MoneyClass euro = new MoneyClass(100.5m, "EUR");
            //act
          //  CurrExchange new_operation =new CurrExchange(australian_dollar, "USD");
          //  CurrExchange new_operation_2 = new CurrExchange(euro, "USD");

            //assert
       //     Assert.AreEqual(new_operation.GetSecondNominal(), 50.25);
        //    Assert.AreEqual(new_operation_2.GetSecondNominal(), 80.4);

        }

    }
}
