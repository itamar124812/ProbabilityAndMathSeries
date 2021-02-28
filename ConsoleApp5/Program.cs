using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp5
{
    
        class Program
        {
            static void Main(string[] args)
            {
            double[] X = new double[5] { 18, 15, 12, 10, 5 };
            double[] Y = new double[5] { 14, 14, 10, 8, 6};
            foreach (var item in MathSeries.BrenoulliNumbers(10,true))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(MathSeries.SumOfPowers(10, 10));
            //  Console.WriteLine(string.Format("y = {0}x + {1}", Probability.ALinearRegression(X, Y), Probability.BLinearRegression(X, Y)));
            Console.WriteLine("press any key to close this window");
                Console.ReadKey();
            }
        public static uint Gcd(uint a,uint b)
        {
           return b==0 ? a: Gcd(b, a % b);
        }
        }
    
}
