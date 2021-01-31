using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    static class MathSeries
    {
        public static IEnumerable<int> Fibonacci(int index)
        {
            if (index >= 0)
            {
                int a = 1;
                int b = 1;
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
        public static IEnumerable<int> PascalNumbers(int index)
        {
            if (index >= 0)
            {
                for (int i = 0; i < index; i++)
                {
                    foreach (var item in nCr(i))
                    {
                        yield return item;
                    }
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
                yield return Factorial(i);
            }
        }
        private static double Factorial(int num)
        {
            double mal = 1;
            for (int i = 1; i <= num; i++)
            {
                mal *= i;
            }
            return mal;
        }
        public static int Fuctorial(this int  a)
        {
            return (int)Factorial(a);
        }
        public static IEnumerable<double> FermatNumbers(uint index)
        {
            for (int i = 0; i < index; i++)
            {
                yield return Math.Pow(2, Math.Pow(2, i)) + 1;
            }
            
        }
    }
}
