using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите предложение:");
            string data = Console.ReadLine();
            string[] str = data.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            // Задача 1
            foreach (var word in str)
            {
                Console.Write($"{word} ");
            }
            Console.WriteLine();
            
            // Задача 2
            int ans1 = 0;
            foreach (var v in str)
            {
                if (v.ToCharArray().Length == 4)
                {
                    ans1 += 1;
                }
            }
            Console.WriteLine($"Колличество слов размера 4: {ans1}");
            
            // Задача 3

            char[] gl = "ауоыиэяюёе".ToCharArray();
            int ans2 = 0;
            foreach (var v in str)
            {
                foreach (var letter in gl)
                {
                    if (v[0].ToString().ToLower().ToCharArray()[0] == letter)
                    {
                        ans2 += 1;
                    }
                }
            }
            Console.WriteLine($"Колличество слов с гласной буквы: {ans2}");
            
        }
    }
}