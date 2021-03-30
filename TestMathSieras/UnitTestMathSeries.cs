using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp5;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp5.Tests
{
    [TestClass()]
    public class UnitTestMathSeries
    {
        [TestMethod()]
        public void continuedFractionTest()
        {
            List<int> check = new List<int> { 8, 19, 1, 1, 3, 2 };
            Assert.AreEqual(MathTools.continuedFraction(2520, 313).Count, check.Count);
            int i = 0;
            foreach (var item in MathTools.continuedFraction(2520,313))
            {              
                Assert.AreEqual(item, check[i]);
                i++;
            }
        }
    }
}

namespace TestMathSieras
{

    [TestClass]
    public class UnitTestMathSeries
    {
        [TestMethod]
        public void TestIntFuctorial()
        {
            //Boundary case analysis
            Assert.AreEqual(MathTools.Fuctorial(0),1);
            Assert.AreEqual(MathTools.Fuctorial(1), 1);
            Assert.AreEqual(MathTools.Fuctorial(3), 6);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => MathTools.Fuctorial(-1));
        }
        [TestMethod]
        public void TestFibonacci()
        {
            Assert.AreEqual(MathSeries.Fibonacci(0).Min(),1);
            Assert.AreEqual(MathSeries.Fibonacci(0).Max(), 1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathSeries.Fibonacci(-1).Min());
        }
        [TestMethod]
        public void TestSumOfPowers()
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            int index = ran.Next(1000);
            Assert.AreEqual(MathSeries.SumOfPowers((uint)index,2),((double)(index*(index+1)*(2*index+1)))/6);
            Assert.AreEqual(MathSeries.SumOfPowers((uint)index, 3), (Math.Pow(((index+1)*index)/2,2)));
        }
        [TestMethod]
        public void TestRisingFuctorial()
        {
            Assert.AreEqual(MathTools.RisingFactorial(1, 0), 1);
            Assert.AreEqual(MathTools.RisingFactorial(0, 0), 1);
            Assert.AreEqual(MathTools.RisingFactorial(2, 2), 6);
            Assert.AreEqual(MathTools.RisingFactorial(3, 3), 60);
            Assert.AreEqual(MathTools.RisingFactorial(4, 5), 6400 + 320);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathTools.RisingFactorial(1, -1));
            
        }
    }
}
