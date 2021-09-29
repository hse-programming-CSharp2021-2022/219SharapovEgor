using System;

namespace Task01
{
    class Program
    {
        static void Print(char[] data)
        {
            foreach (var v in data)
            {
                Console.Write(v+" ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            char[] data = new char[k];
            Random rnd = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (char) rnd.Next('A', 'Z' + 1);
            }
            Print(data);
            char[] data_new1 = new char[k];
            Array.Copy(data, data_new1, k);
            Array.Sort(data_new1);
            Print(data_new1);
            Array.Reverse(data_new1);
            Print(data_new1);
            
        }
    }
}