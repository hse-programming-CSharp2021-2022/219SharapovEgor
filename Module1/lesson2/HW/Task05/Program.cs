using System;

namespace Task05
{
    class Program
        /*
         Программа лишь проверяет существование треугольника, я не понимаю, что выводить с точностью до 3 знаков(((
         */
    {
        static string TriangleInequality(double a, double b, double c)
        {
            string ans;
            ans = (a <= b + c)
                ? ((b <= c + a)
                    ? ((c <= b + a) ? ("Треугольник существует!") : ("Треугольник не существует!"))
                    : ("Треугольник не существует!"))
                : ("Треугольник не существует!");
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


                Console.WriteLine(TriangleInequality(a, b, c));

                Console.WriteLine("Для выхода нажмите Escape, чтобы продолжить, нажмите любую другую кнопку!");
                exitKey = Console.ReadKey();
            } while (exitKey.Key != ConsoleKey.Escape);
        }
    }
}