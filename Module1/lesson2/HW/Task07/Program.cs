using System;

namespace Task07
{
    class Program
    {
        static string GreatNumDelimiter(double num)
        {
            string ans;
            int delimiter = (int) num;
            if (delimiter == num) ans = $"Целая часть: {delimiter}";
            else ans = $"Целая часть: {delimiter}\nДробная часть: {num-delimiter}";
            return ans;
        }
        static string SqrtAndPow(double num)
        {
            string ans;
            if (num < 0) ans = $"Квадрат: {Math.Pow(num, 2)}";
            else ans = $"Корень: {Math.Sqrt(num)}\nКвадрат: {Math.Pow(num, 2)}";
            return ans;
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            double data;
            do
            {
                do {
                    Console.Write("Введите число: ");
                } while (!double.TryParse(Console.ReadLine(), out data));
                
                Console.WriteLine($"{SqrtAndPow(data)}\n{GreatNumDelimiter(data)}");
                
                Console.WriteLine("Для выхода нажмите Escape, чтобы продолжить, нажмите любую другую кнопку!");
                exitKey = Console.ReadKey();   
            } while (exitKey.Key != ConsoleKey.Escape);
        }
    }
}