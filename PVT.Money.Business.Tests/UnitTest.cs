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

            decimal USD_test = USD.nominal;
            decimal EUR_test = EUR.nominal;
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
        public void ConvertMoney()
        {
            //arrange
            MoneyClass australian_dollar = new MoneyClass(100.5m,"AUD");

            //act
            CurrExchange new_operation =new CurrExchange(australian_dollar, "USD");

        //assert
        
        }
    }
}
