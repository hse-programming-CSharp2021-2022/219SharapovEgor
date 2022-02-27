using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task01
{
    class Program
    {
        static void Print(IEnumerable<int> data)
        {
            foreach (var o in data)
            {
                Console.Write(o + " ");
            }
            Console.WriteLine();
        }
        
        static void Print(IEnumerable<IGrouping<int, int>> data)
        {
            foreach (var o in data)
            {
                Console.Write(o + " ");
            }
            Console.WriteLine();
        }

        
        static void Main(string[] args)
        {
            var rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            var data = new int [n];
            Array.ForEach(data, i => i = rnd.Next(-10000, 10001));

            var z1_1 = from i1 in data
                                    select int.Parse(i1.ToString()[^1].ToString());
            
            var z1_2 = data.Select(i1 => int.Parse((i1.ToString())[^1].ToString()));
            
            Print(z1_1);
            Print(z1_2);

            var z2_1 = from i2 in data
                group i2 by int.Parse(i2.ToString()[^1].ToString())
                into newG
                select newG;

            var z2_2 = data.GroupBy(i2 => int.Parse(i2.ToString()[^1].ToString())).Select(newG => newG);

            Print(z2_1);
            Print(z2_2);

            var z3_1 = from i3 in data
                where (i3 % 2) == 0
                select i3;
            var z3_2 = data.Where(i3 => (i3 % 2) == 0);
            
            Print(z3_1);
            Console.WriteLine(z3_1.Count());
            
            Print(z3_2);
            Console.WriteLine(z3_1.Count());

            var z4_1 = (from i4 in data
                where i4 % 2 == 0
                select i4).Sum();
            
            var z4_2 = (data.Where(i4 => i4 % 2 == 0)).Sum();
            
            Console.WriteLine(z4_1);
            Console.WriteLine(z4_2);

            var z5_1 = from i5 in data
                orderby (int) (i5 / Math.Pow(10, (int) Math.Log10(i5))),
                    Math.Abs(i5) % 10
                select i5;

            var z5_2 = data.OrderBy(i5 => (int) (i5 / Math.Pow(10, (int) Math.Log10(i5))))
                .ThenBy(i5 => Math.Abs(i5) % 10);
            
            Print(z5_1);
            Print(z5_2);
        }
    }
}