using System;

namespace Task03
{
    class Program
    {
        static void MasterNum(uint a, uint b, out uint nod, out uint nok)
        {
            uint num_a = a;
            uint num_b = b;
            while (a != 0 && b !=0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
                
            }

            nod = a + b;
            
            nok = Math.Min(num_a, num_b);

            do
            {
                if (nok % num_a == 0 && nok % num_b == 0)
                {
                    break;
                }

                nok += 1;
            } while (true);
            
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            string str;
            uint a;
            uint b;
            do
            {
                do
                {
                    str = Console.ReadLine();
                } while (!uint.TryParse(str, out a));
                do
                {
                    str = Console.ReadLine();
                } while (!uint.TryParse(str, out b));
                MasterNum(a, b, out uint nod, out uint nok);
                
                Console.WriteLine($"НОД: {nod} | Нок: {nok}");
                Console.WriteLine("Чтобы выйти - нажмите Esc!");                
                exitKey = Console.ReadKey();
                Console.WriteLine("Продолжаем!");
            } while (exitKey.Key != ConsoleKey.Escape);;
        }
    }
}