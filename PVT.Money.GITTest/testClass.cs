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

        public void TestMethod(int a, string b) {
          
        }

        public decimal MoneyMethod() {
            return lot_of_money;
        }
    }
}
