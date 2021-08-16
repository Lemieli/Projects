using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyProduct.Logic.Tests
{
    [TestClass]
    public class MyCalculatorTests
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsTheSum()
        {
            //Arrange
            MyCalculator c = new MyCalculator();
             
            //Act
            int result = c.Add(1,2);

            //Assert
            Assert.AreEqual(3, result);
            
        }
    }
}
