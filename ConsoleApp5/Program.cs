using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.ComponentModel;
using System.Threading;

 
namespace ConsoleApp5
{
    
        class Program
        {
            static void Main(string[] args)
            {
            double[] X = new double[5] { 18, 15, 12, 10, 5 };
            double[] Y = new double[5] { 14, 14, 10, 8, 6};
           
            //for (int i = 1; i < 101; i++)
            //{
            //    Console.WriteLine(MathSeries.PrimeNumbers(i).Sum());
            //}
            //foreach (var item in MathSeries.PrimeNumbers(290))
            //{
            //    Console.Write(item.ToString() + " ");
            //    //if (item == null)
            //    //    Console.WriteLine();
            //}
            Console.WriteLine(string.Format("y = {0}x + {1}", Probability.ALinearRegression(X, Y), Probability.BLinearRegression(X, Y)));
            Console.WriteLine("press any key to close this window");
                Console.ReadKey();
            }
        }
    
}
