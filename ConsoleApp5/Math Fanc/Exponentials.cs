using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFunctions
{
    public class Exponentials
    {
        private double Base;
        private Polynomial exponent;
        private Polynomial multiplicationArgument;
        #region constructors
        public Exponentials(double @base)
        {
            Base = @base;
            exponent = new Polynomial(1, new double[2] { 0, 1 }.ToList());
        }

        public Exponentials(double @base, Polynomial exponent)
        {
            Base = @base;
            this.exponent = exponent;
        }

        public Exponentials(double @base, Polynomial exponent, Polynomial multiplicationArgument)
        {
            Base = @base;
            this.exponent = exponent;
            this.multiplicationArgument = multiplicationArgument;
        }
        #endregion
        public Exponentials derivativeOfExponential()
        {
            if (multiplicationArgument == null) return new Exponentials(Base, exponent, exponent.derivativePolynomial().scalePolynomial(Math.Log(Base)));
            else return new Exponentials(Base, exponent, multiplicationArgument.derivativePolynomial().addPolynomial(multiplicationArgument.polynomialProduct(exponent.derivativePolynomial().scalePolynomial(Math.Log(Base)))));
        }
        public double getValueAtX0(double x0)
        {
            if(multiplicationArgument==null)
            {
                return Math.Pow(Base, exponent.getPolyAtSpecificX0(x0));
            }
            else return multiplicationArgument.getPolyAtSpecificX0(x0)* Math.Pow(Base, exponent.getPolyAtSpecificX0(x0));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Exponentials exponentials) ||
                   !(Base == exponentials.Base)) return false;
            if (!exponent.Equals((obj as Exponentials).exponent)) return false;
            if (multiplicationArgument == null|| multiplicationArgument.Equals(new Polynomial(0, new double[1] { 1 }.ToList())))
            {
                if ((obj as Exponentials).multiplicationArgument != null && !(obj as Exponentials).multiplicationArgument.Equals(new Polynomial(0, new double[1] { 1 }.ToList())))return false;
            }
            else if (!multiplicationArgument.Equals((obj as Exponentials).multiplicationArgument)) return false;
            return true;

        }
        public override string ToString()
        {
            if(multiplicationArgument!=null) return string.Format("{2}*{0}^{1}",Base,exponent,multiplicationArgument);
            else return string.Format("{0}^{1}", Base, exponent);
        }
    }
}
