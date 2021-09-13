using System;
using System.ComponentModel.DataAnnotations;

namespace HW_2
{
    class Program
    {
        static double Polinom(double x)
        {
            double ans = x * (x * (x * (12 * x + 9) - 3) + 2) - 4;
            return ans;
        }
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            double data;
            do
            {
                do {
                    Console.Write("Введите значение x: ");
                } while (!double.TryParse(Console.ReadLine(), out data));
                
                Console.WriteLine($"F({data}) = {Polinom(data)}");
                
                Console.WriteLine("Для выхода нажмите Escape, чтобы продолжить, нажмите любую другую кнопку!");
                exitKey = Console.ReadKey();   
            } while (exitKey.Key != ConsoleKey.Escape);
        }
    }
}