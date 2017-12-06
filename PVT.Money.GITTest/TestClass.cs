using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.GITTest
{
    class testClass
    {
     
        public decimal lot_of_money = 1000;
    }

    namespace PVT.Money.GITTest
    {
        class TestClass
        {
            private float testProperty;
            public float TestProperty
            {
                get
                {
                    return testProperty;
                }
                set
                {
                    testProperty = value;
                }
            }

            public void TestMethod(int number, string text)
            {

            }

            public decimal MoneyMethod()
            {
                return 10;
            }

        }
    }
}
