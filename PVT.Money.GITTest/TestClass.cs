using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.GITTest
{
    class TestClass
    {
        float testProperty;

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

        public decimal MoneyBack()
        {
            return 5;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

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

        public void TestMethod( int a, string str)
        {

        }

        public decimal AnyMethod()
        {
            return 10000000000000000000m;
        }
        
    }
}
