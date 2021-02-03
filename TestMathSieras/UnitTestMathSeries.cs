﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp5;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;



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
        public void TestRisingFuctorial()
        {
            Assert.AreEqual(MathTools.RisingFactorial(1, 0), 1);
            Assert.AreEqual(MathTools.RisingFactorial(0, 0), 1);
            Assert.AreEqual(MathTools.RisingFactorial(2, 2), 6);

        }
    }
}
