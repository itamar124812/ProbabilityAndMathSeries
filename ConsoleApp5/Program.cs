﻿using System;
using MathematicalFunctions;

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
        static double func(double x)
        {
            return x;
        }
            static void Main(string[] args)
        {
            Console.WriteLine(new Polynomial(2, new double[3] { -1, 0, 1 }).dividingPolynomials(new Polynomial(1, new double[2] { 1, 1 }))[0]);
            //     double sum = 0;
            //         int result = Math.Pow(2, 1000).ToString("C").Sum(c => c - '0');
            Console.WriteLine(new Exponentials(Math.E,new Polynomial(1,new double[2] {0,-1 }), new Polynomial(2, new double[3] { 0, 1,1 })).derivativeOfExponential().derivativeOfExponential());
               //Console.Write('\n');
               //double[] X = new double[5] { 18, 15, 12, 10, 5 };
               //double[] Y = new double[5] { 14, 14, 10, 8, 6};

               //List<int> numbers = new List<int>();
               //for (int i = 0; i < 99; i++)
               //{
               //    numbers.Add(i);
               //}
               //Console.WriteLine(MathTools.convertFromContinuedFractionToDouble(numbers)) ;
               //for (int i = 0; i < 6; i++)
               //{
               //    sum += (int)Math.Pow(i, 2) + i;
               //}
               //Console.WriteLine(sum);

               //foreach (double item in MathSeries.Fibonacci(70))
               //{
               //    if (item % 2 == 1 && item < 4 * Math.Pow(10, 6))
               //    {
               //        sum += item;

               //    }

               //}
               //  Console.WriteLine(sum);
               //Console.WriteLine(MathSeries.SumOfPowers(10, 10));
               ////  Console.WriteLine(string.Format("y = {0}x + {1}", Probability.ALinearRegression(X, Y), Probability.BLinearRegression(X, Y)));
               //Console.WriteLine("press any key to close this window");
               Console.ReadKey();
            }
        public static uint Gcd(uint a,uint b)
        {
           return b==0 ? a: Gcd(b, a % b);
        }
        }
    
}
