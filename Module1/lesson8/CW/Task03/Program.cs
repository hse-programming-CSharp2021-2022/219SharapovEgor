using System;

namespace Task03
{
    class Program
    {
        static int Com(int[] x, int[]  y)
        {
            if (x.Length == y.Length) return 0;
            else if (x.Length < y.Length) return 1;
            else return -1;
        }
        static void Print(int[][] data)
        {
            Console.WriteLine("-----------------");
            for (int i = 0; i < data.Length; i++, Console.WriteLine())
            {
                Console.WriteLine("");
                {
                    for (int j = 0; j < data[i].Length; j++)
                    {
                        Console.Write(data[i][j] + " ");
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("-----------------");

        }
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            var rnd = new Random();

            int[][] data = new int[size][];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new int[rnd.Next(5, 16)];
                for (int j = 0; j < data[i].Length; j++)
                {
                    data[i][j] = rnd.Next(-10, 11);
                }
            }

            Print(data);
            
            for (int i = 0; i < data.Length; i++)
            {
                Array.Sort(data[i]);
                Array.Reverse(data[i]);
            }
            Print(data);
            
            Array.Sort(data, Com);
            
            Print(data);

        }
    }
}