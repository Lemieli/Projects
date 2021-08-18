using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Kata.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        private static StringCalculator GetNewStringCalculator() => new StringCalculator();

        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            StringCalculator sc = GetNewStringCalculator();

            int result = sc.Add("");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_SingleNumber_SumsItUp()
        {
            StringCalculator sc = GetNewStringCalculator();

            int result = sc.Add("2");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_TwoNumbers_SumsItUp()
        {
            StringCalculator sc = GetNewStringCalculator();

            int result = sc.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [DataTestMethod]
        [DataRow("1,2,3", 6)]
        [DataRow("1,2,3,4", 10)]
        public void Add_MultipleNumbers_SumsItUp(string numbers, int expected)
        {
            StringCalculator sc = GetNewStringCalculator();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void Add_NumbersSeparatedByNewLine_SumsItUp()
        {
            StringCalculator sc = GetNewStringCalculator();

            int result = sc.Add("1\n2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_TwoPreceedingBackslashesChangesDelimiter_SumsItUp()
        {
            StringCalculator sc = GetNewStringCalculator();

            int result = sc.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_NegativeNumber_ThrowsException()
        {
            StringCalculator sc = GetNewStringCalculator();

            try
            {
                sc.Add("-1");
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "negatives not allowed");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        
        [DataTestMethod]
        [DataRow("1000,2", 2)]
        [DataRow("1002,3,4", 7)]
        public void Add_IgnoreNumbersGreaterThanAThousand_SumsItUp(string numbers, int expected)
        {
            StringCalculator sc = GetNewStringCalculator();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_DifferentLengthsOfDelimiterBetweenNumbers_SumsItUp()
        {
            StringCalculator sc = GetNewStringCalculator();

            int result = sc.Add("//***\n1***2***3");

            Assert.AreEqual(6, result);
        }

    }

    internal class StringCalculator
    {
        internal int Add(string numbers)
        {
            if (numbers.Equals(""))
            {
                return 0;
            }


            List<char> delimiters = new List<char>() { ',', '\n', '*' };
            if (numbers.StartsWith("//"))
            {
                delimiters.Add(numbers[2]);
            
                for(int i = 0; i < numbers.Length; i++)
                {
                    if (Char.IsDigit(numbers[i]))
                    {
                        numbers = numbers.Substring(i);
                        break;
                    }
                }                    
            }

            int result = 0;
            int convertedInt = 0;
            string[] separatedNum = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string num in separatedNum)
            {
                convertedInt = Convert.ToInt32(num);
                if (convertedInt < 0)
                {
                    throw new Exception("negatives not allowed");
                }

                if (convertedInt >= 1000)
                {
                    convertedInt = 0;
                }


                result += convertedInt;
                convertedInt = 0;

            }

            return result;
        }
    }
}
