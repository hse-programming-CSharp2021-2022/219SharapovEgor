using System;

namespace Task04
{
    class Program
    {
        static void PrintNums(string data)
        {
            char[] list = data.ToCharArray();
            for (int i = 0; i < list.Length; i++) Console.WriteLine(list[list.Length - (i+1)]);
        }
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            uint data;
            string control;
            do
            {
                do {
                    Console.Write("Введите натуральное четырёхзначное число: ");
                    control = Console.ReadLine();
                    
                } while (!uint.TryParse(control, out data) || control.Length != 4);

                
                PrintNums(control);

                Console.WriteLine("Для выхода нажмите Escape, чтобы продолжить, нажмите любую другую кнопку!");
                exitKey = Console.ReadKey();
            } while (exitKey.Key != ConsoleKey.Escape);
            
        }
    }
}