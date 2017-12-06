using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.GITTest
{
    class ClassGITTest
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

        public void TestMethod(int number, string name)
        {
        }

        public decimal GetMoney()
        {
            return 10;
        }

    }
}

namespace PVT.Money.GITTest
{
    class Class1
    {
        private float testProperty;

        public float TestProperty
        {
            get { return testProperty; }
            set { testProperty = value; }
        }
        public void TestMethod(int number, string text)
        {
            
        }
        public decimal Money ()
        {
            return 8;
        }

    }
}
