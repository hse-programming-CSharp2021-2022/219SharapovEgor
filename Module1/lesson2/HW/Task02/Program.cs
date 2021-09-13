using System;

namespace HW_2
{
    class Program
    {
        static uint MaxNum(uint data)
        {
            uint ans;
            char[] raw1 = data.ToString().ToCharArray();
            int[] raw2 = {int.Parse(raw1[0].ToString()), int.Parse(raw1[1].ToString()), int.Parse(raw1[2].ToString())};
            Array.Sort(raw2);
            ans = uint.Parse($"{raw2[2]}{raw2[1]}{raw2[0]}");
            return ans;
        }
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            uint data;
            string control;
            do
            {
                do {
                    Console.Write("Введите натуральное трёхзначное число: ");
                    control = Console.ReadLine();
                    
                } while (!uint.TryParse(control, out data) || control.Length != 3);
                
                Console.WriteLine(MaxNum(data));
                
                Console.WriteLine("Для выхода нажмите Escape, чтобы продолжить, нажмите любую другую кнопку!");
                exitKey = Console.ReadKey();   
            } while (exitKey.Key != ConsoleKey.Escape);
        }
    }
}