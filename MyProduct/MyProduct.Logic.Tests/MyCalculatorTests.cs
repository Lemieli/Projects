using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyProduct.Logic.Tests
{
    [TestClass]
    public class MyCalculatorTests
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsTheSum()
        {
            //Arrange
            MyCalculator c = GetNewCalc();

            //Act
            int result = c.Add(1, 2); 

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_FirstParamNegative_Throw()
        {
            MyCalculator c = GetNewCalc();

            int ANY_POSITIVE = 1;
            try
            {
                c.Add(-1, ANY_POSITIVE);
            }
            catch (Exception e)
            {

                return;
            }

            Assert.Fail("Expected exception!");
        }


        //Get new instance of calc = maintainability/readability.
        private static MyCalculator GetNewCalc() => new MyCalculator();

    }
}
