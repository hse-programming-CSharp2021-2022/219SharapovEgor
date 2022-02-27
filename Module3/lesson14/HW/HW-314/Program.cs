using System;
using System.Linq;

namespace HW_314
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var data = new int[n];
            for (var i = 0; i < data.Length; i++) data[i] = new Random().Next(-1000, 1001);
           
            var z1 = data.Select(x => x * x).ToArray();
            Array.ForEach(z1, Console.WriteLine);

            var z2 = data.Where(x => x > 0 && x.ToString().Length == 2).ToArray();
            Array.ForEach(z2, Console.WriteLine);

            var z3 = data.Where(x => x % 2 == 0).OrderByDescending(x => x).ToArray();
            Array.ForEach(z3, Console.WriteLine);

            var z4 = data.GroupBy(x => x.ToString().Length).ToArray();
            Array.ForEach(z4, x =>{Array.ForEach(x.ToArray(), Console.WriteLine);});
        }
    }
}
