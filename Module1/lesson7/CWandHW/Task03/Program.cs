using System;
using System.Linq;

namespace Task03
{
    class Program
    {
        static void XorFind(int[] data)
        {
            data = data.Distinct().ToArray();
            Array.Sort(data);
            int dataXor = data[0];
            int xorFloat = 1;
            for (int i = 0; i < data.Length; i++)
                dataXor ^= data[i];
            for (int i = 0; i < data.Length+2; i++)
                xorFloat ^= i;
            Console.WriteLine($"Отсутствует элемент равный: {dataXor ^ xorFloat}");
        }
        static void Main(string[] args)
        {
            int[] data = new int[10000]; 
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i+1;
            }
            Random rnd = new Random();
            int escape = rnd.Next(0, data.Length+1);
            int generate;
            if (rnd.Next(0, 2) == 1) generate = rnd.Next(1, escape);
            else generate = rnd.Next(escape + 1, data.Length+1);
            Console.WriteLine($"На место [{escape}] раньше содержавшее {escape+1} будет поставлено число {generate}");
            data[escape] = data[generate];
            XorFind(data);
        }
    }
}