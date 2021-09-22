using System;

namespace Task02
{
    class Program
    {
        static void F(double A, double delta)
        {
            double S = 0;
            double work_point = 0+delta;

            while (A > work_point)
            {
                S += (Math.Pow(work_point, 2) + Math.Pow((work_point + delta), 2)) / 2 * (work_point + delta);
                work_point = work_point + delta;
            } 
           Console.WriteLine(S); 
        }
        
        static void Main(string[] args)
        {
            double.TryParse(Console.ReadLine(), out double A);
            double.TryParse(Console.ReadLine(), out double delta);
            F(A, delta);
        }
    }
}