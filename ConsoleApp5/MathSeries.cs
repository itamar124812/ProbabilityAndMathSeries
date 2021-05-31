using System;
using System.Collections.Generic;
using MathematicalFunctions.MathTools;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
   public static class MathSeries
    {

        public static double SumOfPowers(uint index,int power)
        {
            double c = (double)1 / (power + 1);
            double sum = 0;
            for (int i = 0; i <= power; i++)
            {
                sum += MathTools.NcR(power + 1, i) * MathTools.BrenoulliNumber((uint)i, true) * Math.Pow(index, power + 1 - i);
            }
            return Math.Round(sum * c);
        }
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
        public static IEnumerable<double> BrenoulliNumbers(uint index,bool Sign)
        {
            if (Sign) {
                for (int i = 0; i < index; i++)
                {
                    if (i % 2 == 0 || i==1)
                    {
                        double sum = 0;
                        for (int k = 0; k <= i; k++)
                        {
                            for (int v = 0; v <= k; v++)
                            {
                                sum += (Math.Pow(-1, v) * MathTools.NcR(k, v) * ((double)Math.Pow(v + 1, i) / (k + 1)));
                            }
                        }
                        yield return Math.Round(sum,8);
                    }
                    else yield return 0;
                } }
            else
            {
                for (int i = 0; i < index; i++)
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
                        yield return Math.Round(sum, 8); 
                    }
                    else yield return 0;
                }
            }
        }
        
        public static IEnumerable<double> TheHormonalSeries(uint index,int s)
        {
            if (s > 0)
            {
                for (int i = 1; i < index; i++)
                {
                    yield return Math.Pow(i, -s);
                }
            }
            else throw new ArgumentOutOfRangeException();
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
        public static IEnumerable<int> MinNumSiers(uint index)
        {
            for (int i = 1; i <= index; i++)
            {
                yield return MathTools.MinNum(i);
            }
        }
    }
    
}
