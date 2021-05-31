using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFunctions.MathTools
{
    public static class MathTools
    {
        public static bool isZero<T>(T Num)
        {
            if (Num is double)
            {
                double num = Convert.ToDouble(Num);
                if (Math.Abs(num) < Math.Pow(10, -14)) return true;
                else return false;
            }
            else if (Num is Polynomial polynomial)
            {
                if (polynomial.Equals(Polynomial.ZeroPolynomial))
                    return true;
                else return false;
            }
            else return false;
        }
        //neesds to be more accurate
        public static double Integral(Func<double, double> func, double upper, double down)
        {
            double sum = 0;
            double preI = down;
            for (double i = (down + 0.0001); i < upper; i += 0.0001)
            {
                sum += (i - preI) * (func(i) + func(preI) / 2);
            }
            return sum / 10000;
        }
        public static double BrenoulliNumber(uint i, bool Sign)
        {
            if (Sign)
            {
                if (i % 2 == 0 || i == 1)
                {
                    double sum = 0;
                    for (int k = 0; k <= i; k++)
                    {
                        for (int v = 0; v <= k; v++)
                        {
                            sum += (Math.Pow(-1, v) * MathTools.NcR(k, v) * ((double)Math.Pow(v + 1, i) / (k + 1)));
                        }
                    }
                    return Math.Round(sum, 8);
                }
                else return 0;
            }
            else
            {
                if (i % 2 == 0 || i == 1)
                {
                    double sum = 0;
                    for (int k = 0; k <= i; k++)
                    {
                        for (int v = 0; v <= k; v++)
                        {
                            sum += (Math.Pow(-1, v) * MathTools.NcR(k, v) * ((double)Math.Pow(v, i) / (k + 1)));
                        }
                    }
                    return Math.Round(sum, 8);
                }
                else return 0;
            }

        }
        public static int Fuctorial(this int a)
        {
            return (int)MathTools.Factorial(a);
        }
        public static double Factorial(int num)
        {
            if (num >= 0)
            {
                double mal = 1;
                for (int i = 1; i <= num; i++)
                {
                    mal *= i;
                }
                return mal;
            }
            else throw new ArgumentOutOfRangeException();
        }
        public static double Stirlingnum(int n, int k)
        {
            if (n >= k && k >= 0)
            {
                double constant = 1 / Factorial(k);
                double sum = 0;
                for (int i = 0; i < k; i++)
                {
                    sum += MathTools.NcR(k, i) * Math.Pow((k - i), n) * Math.Pow(-1, i);
                }
                return sum * constant;
            }
            else throw new ArgumentOutOfRangeException();
        }
        public static double RisingFactorial(double x, int n)
        {
            if (x >= 0 && n >= 0)
            {
                if (n == 0) return 1;
                double Mul = 1;
                for (double i = x; i < n + x; i++)
                {
                    Mul *= i;
                }
                return Mul;
            }
            else throw new ArgumentOutOfRangeException();
        }
        public static double NcR(int n, int k)
        {
            if (n >= k && k >= 0)
            {
                return Factorial(n) / (Factorial(k) * Factorial(n - k));
            }
            else throw new ArgumentOutOfRangeException();
        }
        //returns the minimum number by which all numbers are divided
        public static int MinNum(int x)
        {
            int result = 1;
            for (int i = 1; i < x; i++)
            {
                if (IsPrime(i))
                {
                    result *= i;
                }
                else
                {
                    foreach (int item in PraimaryFactors(i))
                    {
                        if (result % item != 0)
                            result *= item;
                    }
                }
            }
            return result;
        }
        public static bool IsPrime(double p)
        {
            //if(Primes.GetPrimes.ElementAt((int)p/1000).Find(e=>e==p)!=null)
            {
                return true;
            }
            return false;
        }
        public static IEnumerable<int> PraimaryFactors(int x)
        {
            for (int i = 2; i <= Math.Pow(x, 0.5); i++)
            {
                if (x % i == 0)
                {
                    if (IsPrime(i)) yield return i;
                    else PraimaryFactors(x / i);
                }
            }
        }
        public static List<int> rationalContinuedFraction(int a, int b)
        {
            List<int> result = new List<int>();
            while (b != 0)
            {
                result.Add(a / b);
                int temp = b;
                b = a % b;
                a = temp;
            }
            return result;

        }
        public static List<double> irrationalContinuedFraction(double number)
        {
            string Number = number.ToString();
            int length = Number.Substring(Number.IndexOf(".") + 1).Length;
            double a = number * Math.Pow(10, length);
            double b = Math.Pow(10, length);
            List<double> result = new List<double>();
            while (b != 0)
            {
                result.Add(Math.Floor(a / b));
                double temp = b;
                b = a % b;
                a = temp;
            }
            return result;
        }
        public static double convertFromContinuedFractionToDouble<T>(List<T> number)
        {
            double result = 0;
            for (int i = number.Count - 1; i >= 0; i--)
            {
                result += Convert.ToDouble(number[i]);
                if (i != 0) result = 1 / result;
            }
            return result;
        }

    }
}
