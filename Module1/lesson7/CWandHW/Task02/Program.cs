using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[99];
            Random rnd = new Random();
            int[] raw = new int[100];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = i+1;
            }
            Array.Sort(raw, (i, i1) => rnd.Next(-1,2));
            int sum = 0;
            Array.Resize(ref raw, data.Length);
            foreach (var i in raw) sum += i;
            Console.WriteLine(sum);
            Console.WriteLine(5050 - sum);
            
        }
        
    }
}