using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        private static readonly Random Random = new();
        
        static async Task Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();
            
            for (var i = n; i <= k; i += 2)
            {
                await Task.Run(async() =>
                {
                    double integral = await Integral(x => x * x, i, i + 2, Random.Next(0, 100));
                    list.Add(integral);
                }
                    );
            }
            
            Array.ForEach(list.ToArray(), Console.WriteLine);
        }
        
        private static async Task<double> Integral(Func<double, double> functionFunc, int x, int y, int z)
        {
            int work = 0;
            int minValue = x;
            int maxValue = y;
            int value = (int) Math.Max(functionFunc(x), functionFunc(y)) + 1;
            
            for (var i = 0; i < z; i++)
            {
                await Task.Run(() => { if (Random.Next(0, value) <= functionFunc(Random.Next(minValue, maxValue))) work++;});
            }
            return ((double) work / z * (maxValue - minValue) * value);
        }
    }
}