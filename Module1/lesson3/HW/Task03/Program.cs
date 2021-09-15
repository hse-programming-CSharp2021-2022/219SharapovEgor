using System;

namespace Task03
{
    class Program
    {
        static double G(double x)
        {
            if (x <= 0.5) return Math.Sin(Math.PI / 2);
            else return Math.Sin((Math.PI * (x - 1)) / 2);
        }

        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine()!);
            Console.WriteLine(G(x));
        }
    }
}