using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
      public class Polynomial
    {
        #region Fields
        private int rank;
        private double[] Coefficients;
        #endregion
        #region Constructors
        public Polynomial(int rank, double[] coefficients)
        {
            if (rank < 0) throw new ArgumentOutOfRangeException("The rank must be equal or bigger then zero");
            this.rank = rank;
            if (coefficients.Length != rank + 1) throw new ArgumentOutOfRangeException("The length of the coefficients must be equal to rank+1 ");
            Coefficients = coefficients;
            if (Coefficients[rank] == 0) throw new ArgumentOutOfRangeException("The coefficient of x in the power of rank must not be 0.");
        }
        public Polynomial(int rank)
        {
            if (rank < 0) throw new ArgumentOutOfRangeException("The rank must be equal or bigger then zero");
            for (int i = 0; i <= rank; i++)
            {
                Console.WriteLine("Enter the coefficient of x to the power of {0}", i);
                Coefficients[i] = double.Parse(Console.ReadLine());
            }
            if (Coefficients[rank] == 0) throw new ArgumentOutOfRangeException("The coefficient of x in the power of rank must not be 0.");
        }
        #endregion
        #region Methods
        #region Calculus
        public double nIntegral(double upperBound,double lowerBound)
        {
            return integralPolynomial(0).getPolyAtSpecificX0(upperBound) - integralPolynomial(0).getPolyAtSpecificX0(lowerBound);
        }
        public Polynomial integralPolynomial(double c)
        {            
                double[] newR = new double[rank + 2];
                for (int i = rank+1; i >0; i--)
                {
                    newR[i] = Coefficients[i - 1] /i;
                }
            newR[0] = c;
            return new Polynomial(rank + 1, newR);
        }
        public Polynomial derivativePolynomial()
        {
            if (rank == 0) return null;
            double[] newR = new double[rank];
            for (int i = rank; i >0; i--)
            {
                newR[i-1] = Coefficients[i] * i;
            }
            return new Polynomial(rank-1, newR);
        }
        #endregion
        private bool isZero(double num)
        {
            if (Math.Abs(num)< Math.Pow(10, -14)) return true;
            else return false;
        }
        public double getPolyAtSpecificX0(double X0)
        {
            double sum = Coefficients[rank];
            for (int i = rank-1; i >=0; i--)
            {
                sum = Coefficients[i] + sum * X0;
            }
            return sum;
        }

        public double [] getRealRoots()
        {
            if (rank == 0) return null;
            else if (rank == 1) return new double[1] { -Coefficients[0] / Coefficients[1] };
            else if (rank == 2)
            {
                if (Math.Pow(Coefficients[1], 2) - 4 * Coefficients[0] * Coefficients[2] < 0 && !isZero(Math.Pow(Coefficients[1], 2) - 4 * Coefficients[0] * Coefficients[2])) return null;
                else if (isZero(Math.Pow(Coefficients[1], 2) - 4 * Coefficients[0] * Coefficients[2])) return new double[1] { -Coefficients[1] / (2 * Coefficients[2]) };
                else
                {
                    double delta = Math.Sqrt(Math.Pow(Coefficients[1], 2) - 4 * Coefficients[0] * Coefficients[2]);
                    return new double[2]
                    {
                        (-Coefficients[1]+delta) / (2 * Coefficients[2]),
                        (-Coefficients[1]-delta) / (2 * Coefficients[2])
                    };
                }
            }
            else if(rank==3)
            {
                return null;
            }
            return null;

        }

        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial polynomial) || rank != (obj as Polynomial).rank) return false;
            for (int i = 0; i <= rank; i++)
            {
                if (Coefficients[i] != (obj as Polynomial).Coefficients[i]) return false;
            }
            return true;
        }
        #endregion
    }

}
