using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    static class Probability
    {    
        public static void probability()
        {
            int size = 0;
            while (size <= 0)
            {
                Console.WriteLine("please entar a positive number:");
                string input = Console.ReadLine();
                int.TryParse(input, out size);
            }
            double[] arr = new double[size];
            double f = 0;
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                double.TryParse(input, out f);
                arr[i] = f;
            }
            double a = average(arr);
            double m = median(arr);
            double v = various(arr);
            double s = Math.Sqrt(v);
            Console.WriteLine("average = {0},mesian = {1},various = {2},standard deviation = {3}", a, m, v, s);
        }
        public static void probability(double[] Arr)
        {
            double a = Arr.Sum();
            a = average(Arr);
            double m = median(Arr);
            double v = various(Arr);
            double s = Math.Sqrt(v);
            Console.WriteLine("average = {0},mesian = {1},various = {2},standard deviation = {3}", a, m, v, s);
        }
        private static double various(double[] arr)
        {
            double result = 0;
            double u = average(arr);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                result += (arr[i] - u) * (arr[i] - u);
            }
            return (result / arr.GetLength(0));
        }
        private static double median(double[] arr)
        {
            Array.Sort(arr);
            int b = arr.GetLength(0); double result = 0;
            if (b % 2 == 0)
            {
                result = (arr[b / 2] + arr[(b - 2) / 2]) / (float)2;
            }
            else result = arr[b / 2];
            return result;
        }

        private static double average(double[] arr)
        {
            double sum = arr.Sum();
            return  sum/= arr.Length;
        }
        public static double BLinearRegression(double[] X, double[] Y)
        {
            return average(Y) - (ALinearRegression(X, Y, average(X), average(Y))* average(X));
        }
        public static double ALinearRegression(double[] X, double[] Y, double AverageX, double AverageY)
        {
            double Sum = 0;
            double SDX = Math.Sqrt(various(X));
            for (int i = 0; i < X.Length; i++)
            {
                X[i] -= AverageX;
                Y[i] -= AverageY;
                Sum += X[i] * Y[i];
            }
            return Sum / SDX;
        }
        public static double Pearson()
        {
            Console.WriteLine("enter the num of Columns:");
            int ColumnsNum = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the num of Roes:");
            int RoesNum = int.Parse(Console.ReadLine());
            double[,] arr = new double[RoesNum, ColumnsNum];
            double[] SumRows = new double[RoesNum];
            double[] ColumnsSum = new double[ColumnsNum];
            for (int i = 0; i < ColumnsNum; i++)
            {
                double SumRow = 0;
                Console.WriteLine("this is column number: {0}", i + 1);
                for (int j = 0; j < RoesNum; j++)
                {
                    double num = 0;
                    Console.WriteLine("enter a number: ");
                    double.TryParse(Console.ReadLine(), out num);
                    SumRow += num;
                    arr[j, i] = num;
                }
                ColumnsSum[i] = SumRow;
            }
            for (int i = 0; i < RoesNum; i++)
            {
                double sum = 0;
                for (int j = 0; j < ColumnsNum; j++)
                {
                    sum += arr[i, j];
                }
                SumRows[i] = sum;
            }
            double[,] EArr = new double[RoesNum, ColumnsNum];
            double returndValue = 0;
            for (int i = 0; i < RoesNum; i++)
            {
                for (int j = 0; j < ColumnsNum; j++)
                {
                    EArr[i, j] = (SumRows[i] * ColumnsSum[j]) / SumRows.Sum();
                    returndValue += Math.Pow(arr[i, j] - EArr[i, j], 2) / EArr[i, j];
                }
            }
            return returndValue;
        }
    }
}
