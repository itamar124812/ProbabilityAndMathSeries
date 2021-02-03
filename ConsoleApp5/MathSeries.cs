﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
   public static class MathSeries
    {
        public static IEnumerable<double> Fibonacci(int index)
        {
            if (index >= 0)
            {
                double a = 1;
                double b = 1;
                yield return a;
                yield return b;
                for (int i = 0; i < index; i++)
                {
                    if (i % 2 == 0)
                    {
                        a += b;
                        yield return a;
                    }
                    else
                    {
                        b += a;
                        yield return b;
                    }
                }
            }
            else throw new ArgumentOutOfRangeException();
        }
        public static IEnumerable<int> SquaresNumbers(int index)
        {
            if (index > 0)
            {
                for (int i = 0; i < index; i++)
                {
                    yield return i * i;
                }
            }
            else throw new ArgumentOutOfRangeException();
        }
        public static IEnumerable<int> PrimeNumbers(int index)
        {
            if (index > 0)
            {
                int RetuenNum = 0;
                int prime = 2;
                bool IsPrime;
                while(RetuenNum<=index)
                {
                    IsPrime = true;
                    for (int i = 2; i <= Math.Abs(Math.Sqrt(prime)); i++)
                    {
                        if (prime % i == 0)
                            IsPrime = false;
                    }
                    if(IsPrime)
                    {
                        yield return prime;
                        ++RetuenNum;                       
                    }
                    ++prime;
                }
                
            }
            else throw new ArgumentOutOfRangeException();
        }
        public static IEnumerable<int?> PascalNumbers(int index)
        {
            if (index >= 0)
            {
                for (int i = 0; i < index; i++)
                {
                    foreach (var item in nCr(i))
                    {
                        yield return item;
                    }
                    yield return null;
                }
            }
            else throw new ArgumentOutOfRangeException();
        }
        public static IEnumerable<int> nCr(int n)
        {
            if (n >= 0)
            {
                for (int i = 0; i <= n; i++)
                {
                    yield return n.Fuctorial() / (i.Fuctorial() * (n - i).Fuctorial());
                }
            }
            else throw new ArgumentOutOfRangeException();
        }
        public static IEnumerable<double> Factorial(uint index)
        {         
            for (int i = 0; i < index; i++)
            {
                yield return MathTools.Factorial(i);
            }
        }    
        public static IEnumerable<double> FermatNumbers(uint index)
        {
            for (int i = 0; i < index; i++)
            {
                yield return Math.Pow(2, Math.Pow(2, i)) + 1;
            }
            
        }
        public static IEnumerable<double> CatalanNumbers(uint index)
        {
            for (int i = 0; i < index; i++)
            {
                yield return (MathTools.Factorial(i * 2) / (MathTools.Factorial(i) * MathTools.Factorial(i+1)));
            }
        }
        //public static IEnumerable<double> EulerNumbers(uint index)
        //{
        //    yield return 1;
        //    for (int i = 2; i < index; i++)
        //    {
        //        double constant= Math.Pow((2*i-1), i);
        //        double sum = 0;
        //        for (int j = 1; j < i; j++)
        //        {
        //          sum+= (Math.Pow(-1, j) * MathTools.Stirlingnum(i, j)) / (j + 1);
        //            sum *=( 3 * MathTools.RisingFactorial(0.25, j) - MathTools.RisingFactorial(0.75, j));
        //        }
        //        yield return sum * constant;
        //    }
        //}
    }
    public static class MathTools
    {
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
        public static double RisingFactorial(double x,int n)
        {
            if (x >= 0 && n >= 0)
            {
                if (n == 0) return 1;
                double Mul = 1;
                for (double i = x; i < n+x; i++)
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
    }
}
