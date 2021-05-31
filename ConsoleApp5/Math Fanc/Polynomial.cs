using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFunctions
{
      public class Polynomial
    {
        #region Fields
        private int rank;
        private List<double> Coefficients;
        public static Polynomial ZeroPolynomial = new Polynomial();
        #endregion
        #region Constructors
        public Polynomial(int rank, List<double> coefficients)
        {
            if (rank < 0) throw new ArgumentOutOfRangeException("The rank must be equal or bigger then zero");
            this.rank = rank;
            if (coefficients.Count != rank + 1) throw new ArgumentOutOfRangeException("The length of the coefficients must be equal to rank+1 ");
            Coefficients = coefficients;
            if (Coefficients[rank] == 0) throw new ArgumentOutOfRangeException("The coefficient of x in the power of rank must not be 0.");
        }
        public Polynomial(int rank, double[] coefficients)
        {
            if (rank < 0) throw new ArgumentOutOfRangeException("The rank must be equal or bigger then zero");
            this.rank = rank;
            if (coefficients.Length != rank + 1) throw new ArgumentOutOfRangeException("The length of the coefficients must be equal to rank+1 ");
            Coefficients = coefficients.ToList();
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
        public Polynomial (Polynomial other) : this(other.rank, other.Coefficients) { }
        private Polynomial()
        {
            rank = 0;
            Coefficients = new List<double>();
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
            return new Polynomial(rank + 1, newR.ToList());
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
        #region overload operators
        public static Polynomial operator-(Polynomial polynomial)
        {
            return polynomial.scalePolynomial(-1);
        }
        public static Polynomial operator -(Polynomial polynomial, Polynomial other)
        {
            return polynomial.substructPolynomial(other);
        }
        public static Polynomial operator+(Polynomial polynomial,Polynomial other)
        {
            return polynomial.addPolynomial(other);
        }
        public static Polynomial operator*(Polynomial polynomial, Polynomial other)
        {
            return polynomial.polynomialProduct(other);
        }
        public static Polynomial operator*(double a,Polynomial polynomial)
        {
            return polynomial.scalePolynomial(a);
        }
        public static Polynomial operator/(Polynomial polynomial, double a)
        {
            return polynomial.scalePolynomial(1d / a);
        }
        #endregion
        #region Arithmetic
        
        public Polynomial[] dividingPolynomials(Polynomial other)
        {
            if (!MathTools.MathTools.isZero(other))
            {
                int currentDegree = this.rank;
                Polynomial solution = new Polynomial();
                Polynomial  remainder ;
                 remainder =new Polynomial(this);
                
                for (int i = 0; i <= this.rank - other.rank; i++)
                {
                    if (currentDegree >= 0)
                    {
                       solution.setCoefficientAtPlaceN( i ,remainder.Coefficients[0]/ other.Coefficients[0]);
                        for (int e = 0; e < other.rank; e++)
                        {
                             remainder .Coefficients[i + e] =  remainder .Coefficients[i + e] - (solution.Coefficients[i] * other.Coefficients[e]);
                        }
                        currentDegree--;
                    }
                    else
                    {
                        solution.Coefficients.ToList().Add( remainder .Coefficients[i] / other.Coefficients[0]);
                    }                   
                }
                return new Polynomial[2] { solution, remainder };
            }
            else throw new DivideByZeroException("the diviter must not be equal zero. ");

        }
        public Polynomial polynomialProduct(Polynomial other)
        {
            List<double> coefficients = new double[rank + other.rank + 1].ToList();
            for (int i = rank; i >=0; i--)
            {
                for (int j = other.rank; j >=0; j--)
                {
                    coefficients[i + j] += Coefficients[i] * other.Coefficients[j];
                }
            }
            return new Polynomial(rank + other.rank, coefficients);
        }
        public Polynomial scalePolynomial(double a)
        {
            if (a == 0) throw new ArgumentOutOfRangeException("The scalar cannot be zero.");
            List<double> newCoefficients = Coefficients;
            for (int i = 0; i < newCoefficients.Count; i++)
            {
                newCoefficients[i] *= a;
            }
            return new Polynomial(rank, newCoefficients);
        }
        public Polynomial addPolynomial(Polynomial other)
        {
            List<double> coefficients = other.Coefficients.Count > Coefficients.Count ? other.Coefficients : Coefficients;
            int Rank = rank < other.rank ? rank : other.rank;
            for (int i = 0; i <=Rank ; i++)
            {
                coefficients[i] += other.Coefficients.Count > Coefficients.Count ? Coefficients[i] : other.Coefficients[i];
            }
            return new Polynomial(rank > other.rank ? rank : other.rank, coefficients);
        }
        public Polynomial substructPolynomial(Polynomial other)
        {
            if (other.Equals(this)) throw new ArgumentException("The polynomial must be diffrent from zero.");
            return this.addPolynomial(other.scalePolynomial(-1));
        }

        #endregion      
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
                if (Math.Pow(Coefficients[1], 2) - 4 * Coefficients[0] * Coefficients[2] < 0 && !MathTools.MathTools.isZero(Math.Pow(Coefficients[1], 2) - 4 * Coefficients[0] * Coefficients[2])) return null;
                else if (MathTools.MathTools.isZero(Math.Pow(Coefficients[1], 2) - 4 * Coefficients[0] * Coefficients[2])) return new double[1] { -Coefficients[1] / (2 * Coefficients[2]) };
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
            else
            {
                for (int i = 0; i < this.rank; i++)
                {
                    if (!(Math.Floor(Coefficients[i]) == Coefficients[i])) return null;
                }
                return null;
            }

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
        public void setCoefficientAtPlaceN(int index, double value)
        {
            if (index < 0) throw new IndexOutOfRangeException();
            if (index > rank) rank++;
             Coefficients.Insert( index, value);
        }
        public override string ToString()
        {
            string result =Coefficients[0]==0?string.Empty: Coefficients[0].ToString();
            for (int i = 1; i <= rank; i++)
            {
                if(Coefficients[i]!=0&& Coefficients[i]!=1&&Coefficients[i]>0) result += string.Format("+{0}x^{1}",Coefficients[i],i);
                else if(Coefficients[i] == 1) result += string.Format("+x^{0}", i);
                else if(Coefficients[i] < 0)result += string.Format("{0}x^{1}", Coefficients[i], i);
            }
            return result;
        }

        public override int GetHashCode()
        {
            int hashCode = 1695225810;
            hashCode = hashCode * -1521134295 + rank.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<double>>.Default.GetHashCode(Coefficients);
            return hashCode;
        }
    }

}
