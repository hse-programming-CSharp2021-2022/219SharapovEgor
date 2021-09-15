using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            
            Console.WriteLine(Math.Min(x%100, Math.Min(y%100, z%100)));
        }
    }
}