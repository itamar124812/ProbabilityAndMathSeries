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

            for (int i = 1; i < 101; i++)
            {
                Console.WriteLine(MathSeries.PrimeNumbers(i).Sum());
            }
            //foreach (var item in MathSeries.PrimeNumbers(290))
            //{
            //    Console.Write(item.ToString() + " ");
            //    //if (item == null)
            //    //    Console.WriteLine();
            //}
            Console.WriteLine();
            Console.WriteLine("press any key to close this window");
                Console.ReadKey();
            }
        }
    
}
