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
            Console.WriteLine(MathTools.RisingFactorial(0, 0));
            foreach (var item in MathSeries.EulerNumbers(10))
            {
                Console.Write(item.ToString() + " ");
                //if (item == null)
                //    Console.WriteLine();
            }

            Console.WriteLine("press any key to close this window");
            Console.ReadKey();       
     }        
    }
}
