using System;

namespace Task03

{
    class Program
    {
        static double Total(double k, double r, uint n)
        {
            if (n == 0) return k;
            return Total(k * (1 + r / 100), r, n - 1);
        }

        
        static void Main(string[] args)
        {
            double.TryParse(Console.ReadLine(), out double k);
            double.TryParse(Console.ReadLine(), out double r);
            uint.TryParse(Console.ReadLine(), out uint n);
            Total(k, r, n);
        }
    }
}
