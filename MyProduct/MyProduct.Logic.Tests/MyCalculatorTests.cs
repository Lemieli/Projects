using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyProduct.Logic.Tests
{
    [TestClass]
    public class MyCalculatorTests
    {
        //Get new instance of calc = maintainability/readability.
        private static MyCalculator GetNewCalc() => new MyCalculator();

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
        public void Add_FirstParamNegative_Throws()
        {
            MyCalculator c = GetNewCalc();
            int ANY_POSITIVE = 1;

            Assert.ThrowsException<Exception>(() => c.Add(-1, ANY_POSITIVE));
            //Assert.ThrowsException<Exception>(delegate { c.Add(-1, ANY_POSITIVE); });
        }
         
        [TestMethod]
        public void Add_SecondParamNegative_Throws()
        {
            MyCalculator c = GetNewCalc();
            int ANY_POSITIVE = 1;

            Assert.ThrowsException<Exception>(() => c.Add(ANY_POSITIVE, -1));
        }
    }
}
