using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.GITTest
{
    class testClass
    {
        public float testProp;
        public float value;
        public decimal lot_of_money = 1000;

namespace PVT.Money.GITTest
{
    class TestClass
    {
        private float testProperty;
        public float TestProperty
        {
            get
            {
                return testProp;
            }
            set
            {
                testProp = value;
            }
        }

            public void TestMethod(int number, string text)
            {

            }

        public decimal MoneyMethod() {
            return lot_of_money;
        }
        
    }
}
