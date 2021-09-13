using System;

namespace Task03
{
    class Program /*
     А ШО ТАКОЕ КОМПЛЕКСНЫЕ КОРНИ??????????
     */
    {
        static string QuadraticEquation(double a, double b, double c)
        {
            string ans;
            double D = Math.Pow(b, 2) - 4 * a * c;
            ans = (D == 0)
                ? ($"{-b / (2 * a)}")
                : ((D > 0) ? ($"{(-b + Math.Sqrt(D)) / (2 * a)} {(-b - Math.Sqrt(D)) / (2 * a)}") : ("Не имеет корней"));
            return ans;
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            double a, b, c;
            do
            {
                do
                {
                    Console.Write("A: ");
                } while (!double.TryParse(Console.ReadLine(), out a));

                do
                {
                    Console.Write("B: ");
                } while (!double.TryParse(Console.ReadLine(), out b));

                do
                {
                    Console.Write("C: ");
                } while (!double.TryParse(Console.ReadLine(), out c));
                
                Console.WriteLine(QuadraticEquation(a, b, c));

                Console.WriteLine("Для выхода нажмите Escape, чтобы продолжить, нажмите любую другую кнопку!");
                exitKey = Console.ReadKey();
            } while (exitKey.Key != ConsoleKey.Escape);
        }
    }
}