using System;

namespace Task02
{
    class Program
    {
        static void PrintStolbik(string data)
        {
            char[] list = data.ToCharArray();
            for (int i = 0; i < list.Length; i++) Console.WriteLine(list[i]);
        }
        
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            PrintStolbik(data);
        }
    }
}