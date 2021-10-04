using System;
using System.Xml;

namespace CW_8
{
    class Program
    {
        static int Sum(int num)
        {
            int sum = 0;

            for (int i = 0; i < num.ToString().Length; i++)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }
        
        static void Print(int[] data)
        {
            Array.ForEach(data, el => Console.Write(el + " "));
            Console.WriteLine(" ");
        }

        static int Com1(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 0) return 0;
            else if (x % 2 != 0 && y % 2 == 0) return 1;
            else return -1;
        }
        
        static int Com2(int x, int y)
        {
            if (x.ToString().Length == y.ToString().Length) return 0;
            else if (x.ToString().Length < y.ToString().Length) return 1;
            else return -1;
        }
        
        static int Com3(int x, int y)
        {
            if (Sum(x) == Sum(y)) return 0;
            else if (Sum(x) < Sum(y)) return 1;
            else return -1;
        }
        
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            var rnd = new Random();

            int[] data = new int[size];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rnd.Next(1, 1001);
            }
            Print(data);
            Array.Sort(data, Com1);
            Print(data);
            Array.Sort(data, Com2);
            Print(data);
            Array.Sort(data, Com3);
            Print(data);
        }
    }
}