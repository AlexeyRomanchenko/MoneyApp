using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Business;
using System.Threading.Tasks;
using PVT.Money.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PVT.Money.Business.Tests
{
    [TestFixture]
    class UnitTest
    {
        public UnitTest()
        {
            MoneyContext.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MoneyExchange;Integrated Security=true;";
        }


        [Test]
        public void MoneyClassTest()
        {
            //arrange
            MoneyClass USD = new MoneyClass(100.5m, Currency.USD);
            MoneyClass EUR = new MoneyClass(100m, Currency.EUR);
            //act

            MoneyClass euro = new MoneyClass(100m, Currency.EUR);
            CurrExchange new_operation = new CurrExchange(euro, Currency.USD);

            //Account millions = new Account(new_operation.GetSecondNominal());

             // millions.RegisterDelegate(new Account.AccountDelegate(Added));
        }

        [Test]
        public void MoneyClassFailedCurrency()
        {
            //assert
            Assert.Throws<ArgumentNullException>(() => new MoneyClass(10.5m, Currency.AUD));

            //arrange
            MoneyClass australian_dollar = new MoneyClass(100m, Currency.EUR);
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
               Assert.AreEqual(new_operation.GetSecondNominal(), 50.25);
               Assert.AreEqual(new_operation_2.GetSecondNominal(), 80.4);


        }

        [Test]
        public void AddMoneyToSingleton()
        {
            MoneyClass euro = new MoneyClass(100m, Currency.EUR);
            CurrExchange exchanging = new CurrExchange(euro, Currency.USD);

            MoneyClass euro2 = new MoneyClass(200m, Currency.AUD);
            CurrExchange exchanging2 = new CurrExchange(euro2, Currency.EUR);

            MoneyClass euro22 = new MoneyClass(1300m, Currency.EUR);
            CurrExchange exchanging22 = new CurrExchange(euro22, Currency.AUD);

        }

        [Test]
        public void RateTest()
        {
            string first = "EUR";
            string second = "AUD";
            Rate rate = new Rate(first, second);
        }


        [Test]
        public async Task ChangeMoneyAnotherWalletOneCurency()
        {
            //Wallet firstWallet = new Wallet();
            //firstWallet.Value = 3200;
            //firstWallet.UserId = 1;
            //firstWallet.WalletName = "First";
            //firstWallet.Currency = "USD";

            //Wallet secondWallet = new Wallet();
            //secondWallet.Value = 200;
            //firstWallet.UserId = 1;
            //secondWallet.Currency = "USD";
            //secondWallet.WalletName = "Sec";

            string dbName = Guid.NewGuid().ToString();

            InMemoryDataContextProvider prov = new InMemoryDataContextProvider(dbName);
            var context = prov.CreateContext();

            using (context)
            {
                // INSERT DATA 
            }
               

            int transfMoney = 10;
            int firstWalletId = 1;
            int secondWalletId = 2;


            TransfertManager transfertMoney = new TransfertManager(transfMoney, firstWalletId, secondWalletId, prov);
            //Assert.AreEqual(firstWallet.Value, 3190);
            //Assert.AreEqual(secondWallet.Value, 210);
        }
    }
}
