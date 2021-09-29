using System;

namespace HW_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int m;
            double angle, x, sin, sinOld, memb;
            ConsoleKeyInfo exitKey;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                do
                {
                    Console.Write("Введите значение угла в радианах:");
                } while (!double.TryParse(Console.ReadLine(), out angle));
                Console.ResetColor();
                x = angle % (2 * Math.PI);
                for (m = 1, sin = memb = x, sinOld = 0; sin != sinOld; m++)
                {
                    Console.WriteLine($"sin({x}) = {sin} \tmemb = {memb}");
                    sinOld = sin;
                    memb *= -x * x / 2 / m / (2 * m + 1);
                    sin += memb;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Элитный sin({angle}) = {sin}");
                Console.WriteLine($"Плебейский из модуля Math sin({angle}) = {Math.Sin(angle)}");
                Console.ResetColor();
                Console.WriteLine("Нажмите Esc, чтобы выйти или другую клавишу, чтобы продолжить");
                exitKey = Console.ReadKey();
            }while (exitKey.Key != ConsoleKey.Escape);
            
        }
    }
}