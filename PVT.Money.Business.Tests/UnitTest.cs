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
        public void SystemCheck()
        {
            Assert.Pass("Проверка системы тестирования");
        }

        [Test]
        public void MoneyClassTest() {
            //arrange
           MoneyClass USD = new MoneyClass(100.5m,"USD");
           MoneyClass EUR = new MoneyClass(100m, "EUR");
            //act

            decimal USD_test = USD.GetNominal();
            decimal EUR_test = EUR.GetNominal();
            //assert
            Assert.AreNotEqual(USD_test,0);
            Assert.AreNotEqual(EUR_test, 0);
        }

        [Test]
        public void MoneyClassFailed() {
            
            //arrange
            
            //act
            //decimal USD_test = USD.nominal;

            //assert
            Assert.Throws<ArgumentNullException>(() => new MoneyClass(0, "USD"));
    
        }

        [Test]
        public void MoneyClassFailedCurrency()
        { 
            //assert
            Assert.Throws<ArgumentNullException>(() => new MoneyClass(10.5m, "UAH"));

        }

        [Test]
        public void ConvertMoneyFromAUDToUSD()
        {
            //arrange
            MoneyClass australian_dollar = new MoneyClass(100.5m,"AUD");

            //act
            CurrExchange new_operation =new CurrExchange(australian_dollar, "USD");

            //assert
            Assert.AreNotEqual(new_operation, 0);
            Assert.AreEqual(new_operation.secondNominal, 50.25);
        }

        [Test]
        public void ConvertMoneyFromEURToUSD()
        {
            //arrange
            MoneyClass euro = new MoneyClass(100.5m, "EUR");

            //act
            CurrExchange new_operation = new CurrExchange(euro, "USD");

            //assert
            Assert.AreNotEqual(new_operation, 0);
            Assert.AreEqual(new_operation.secondNominal, 80.4);
        }

        [Test]
        public void currExchangeClassFailed()
        {
            MoneyClass euro = new MoneyClass(100.5m, "EUR");
          //  CurrExchange new_operation = new CurrExchange(euro, "UAH");
            //assert
            Assert.Throws<Exception>(() => new CurrExchange(euro, "UAH"));

        }
    }
}
