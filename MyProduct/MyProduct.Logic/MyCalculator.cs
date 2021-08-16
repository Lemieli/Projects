using System;

namespace MyProduct.Logic
{
    public class MyCalculator
    {
        public int Add(int a, int b)
        {
            if(a < 0)
            {
                throw new Exception("Number cannot be less than zero.");
            }
            return a + b;
        }
    }
}
