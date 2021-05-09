using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Tests
{
    [TestClass()]
    public class ExponentialsTests
    {
        [TestMethod()]
        public void derivativeOfExponentialTest()
        {
            Assert.AreEqual(new Exponentials(Math.E).derivativeOfExponential(), new Exponentials(Math.E));
            Assert.AreEqual(new Exponentials(2).derivativeOfExponential(), new Exponentials(2, new Polynomial(1, new double[2] { 0, 1 }), new Polynomial(0, new double[1] { Math.Log(2) })));
        }

        [TestMethod()]
        public void getValueAtX0Test()
        {
            Assert.AreEqual(new Exponentials(Math.E).getValueAtX0(0), 1);
            Assert.AreEqual(new Exponentials(Math.E, new Polynomial(2, new double[3] { 2, 2, 2 })).getValueAtX0(0), Math.E * Math.E);
        }
    }
}