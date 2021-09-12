using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            double catet1;
            double catet2;
            string ent1 = Console.ReadLine();
            string ent2 = Console.ReadLine();
            if (!double.TryParse(ent1, out catet1) || !double.TryParse(ent2, out catet2))
            {
                Console.WriteLine("Некорректный ввод!");
            }
            else
            {
                if (catet1 <= 0 || catet2 <= 0) Console.WriteLine("Некорректный ввод!");
                else
                {
                    double ans = Math.Sqrt(Math.Pow(catet1, 2) + Math.Pow(catet2, 2));
                    Console.WriteLine(ans);
                }
            }
        }
    }
}