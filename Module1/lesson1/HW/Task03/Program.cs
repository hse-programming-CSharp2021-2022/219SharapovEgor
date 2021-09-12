using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            string ent = Console.ReadLine();
            int.TryParse(ent, out num);
            char ans = (char) num;
            Console.WriteLine(ans);
        }
    }
}