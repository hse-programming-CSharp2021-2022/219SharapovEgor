using System;

namespace Task01
{
    class Program
    {
        static bool G(double x, double y)
        {
            if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) <= 2 && x >= 0 && x <= Math.Sqrt(2) && y <= Math.Sqrt(2) &&
                y >= -2) return true;
            else return false;

        }
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine()!);
            double y = double.Parse(Console.ReadLine()!);
            bool gg = G(x, y);
            Console.WriteLine(gg);
        }
    }
}