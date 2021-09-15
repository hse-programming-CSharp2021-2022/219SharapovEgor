using System;

namespace Task02
{
    class Program
    {
        static double G(double x, double y)
        {
            if (x < y && x > 0) return x + Math.Sin(y);
            else if (x > y && x < 0) return y - Math.Cos(x);
            else return 0.5 * x * y;
        }
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine()!);
            double y = double.Parse(Console.ReadLine()!);
            Console.WriteLine(G(x, y));
        }
    }
}