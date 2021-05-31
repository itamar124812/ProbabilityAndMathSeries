using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp5;
using System;
using MathematicalFunctions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Tests
{
    [TestClass()]
    public class PolynomialTests
    {
        [TestMethod()]
        public void getRealRootsTest()
        {
            Assert.AreEqual(new Polynomial(0, new double[1] { 2 }).getRealRoots(), null);
            CollectionAssert.AreEqual(new Polynomial(1, new double[2] { 2, 7 }).getRealRoots(), new double[1] { -(2d / 7) });
            CollectionAssert.AreEqual(new Polynomial(2, new double[3] { 3, 4, 1 }).getRealRoots(), new double[2] { -1, -3 });
        }

        [TestMethod()]
        public void getPolyAtSpecificX0Test()
        {
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 4, 1 }).getPolyAtSpecificX0(8), 99);
            //BVA-When X0 equal zero
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 4, 1 }).getPolyAtSpecificX0(0), 3);
            //BVA-When the result Should be zero
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 4, 1 }).getPolyAtSpecificX0(-1), 0);
            //BVA-When all the coefficients execpt an are zero
            Assert.AreEqual(new Polynomial(2, new double[3] { 0, 0, 1 }).getPolyAtSpecificX0(-1), 1);
            //BVA-When X0 is irrational 
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 4, 1 }).getPolyAtSpecificX0(Math.PI), Math.PI * Math.PI + 4 * Math.PI + 3);
        }

        [TestMethod()]
        public void derivativePolynomialTest()
        {
            Assert.IsTrue(new Polynomial(3, new double[4] { 2, 3, 4, 1 }).derivativePolynomial().Equals((new Polynomial(2, new double[3] { 3, 8, 3 }))));
            //BVA-The rank is equal to zero(Null execpted)
            Assert.IsNull(new Polynomial(0, new double[1] { 1 }).derivativePolynomial());
        }

        [TestMethod()]
        public void integralPolynomialTest()
        {
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 8, 3 }).integralPolynomial(2), new Polynomial(3, new double[4] { 2, 3, 4, 1 }));
        }

        [TestMethod()]
        public void nIntegralTest()
        {
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 8, 3 }).nIntegral(1, 0), 8);
            //EP=The upper bound is lower then the lower bound
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 8, 3 }).nIntegral(0, 1), -8);
            //BVA-The upper bound has the same value as the lower bound
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 8, 3 }).nIntegral(1, 1), 0);
        }

        [TestMethod()]
        public void addPolynomialTest()
        {
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 8, 3 }).addPolynomial(new Polynomial(1, new double[2] { 1, 2 })), new Polynomial(2, new double[3] { 4, 10, 3 }));
            Assert.AreEqual(new Polynomial(1, new double[2] { 1, 2 }).addPolynomial(new Polynomial(2, new double[3] { 3, 8, 3 })), new Polynomial(2, new double[3] { 4, 10, 3 }));
            Assert.AreEqual(new Polynomial(1, new double[2] { 1, 2 }).addPolynomial(new Polynomial(1, new double[2] { 3, 4 })), new Polynomial(1, new double[2] { 4, 6 }));
        }
        [TestMethod()]
        public void substructPolynomialTest()
        {
            Assert.AreEqual(new Polynomial(2, new double[3] { 3, 8, 3 }).substructPolynomial(new Polynomial(1, new double[2] { 1, 2 })), new Polynomial(2, new double[3] { 2, 6, 3 }));
            Assert.AreEqual(new Polynomial(1, new double[2] { 1, 2 }).substructPolynomial(new Polynomial(2, new double[3] { 3, 8, 3 })), new Polynomial(2, new double[3] { -2, -6, -3 }));
            Assert.AreEqual(new Polynomial(1, new double[2] { 1, 2 }).substructPolynomial(new Polynomial(1, new double[2] { 3, 4 })), new Polynomial(1, new double[2] { -2, -2 }));
        }

        [TestMethod()]
        public void polynomialProductTest()
        {
            Assert.AreEqual(new Polynomial(1, new double[2] { 3, 4 }).polynomialProduct(new Polynomial(1, new double[2] { 2, 2 })),new Polynomial(2,new double[3] { 6,14,8}));
        }
    }
}