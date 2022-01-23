using System;

namespace CW_2
{
    class Program
    {
        public delegate int Cast(double x);
        static void Main(string[] args)
        {
            Cast AnonMet = delegate(double d)
            {
                int x = (int)Math.Round(d);
                return (x + 1) & ~1;
            };
            
            Cast LamdaExp = (double x) => ((int) x).ToString().Length;
            
            for (var i = 0; i < 4; i++)
            {
                var rnd = new Random();
                var x = rnd.NextDouble()*1000;
                Console.WriteLine($"x : {x}\n Anon: {AnonMet(x)}\n Lamda: {LamdaExp(x)}");
            }
            var rndi = new Random();
            Cast UniCast = AnonMet;
            UniCast += LamdaExp;
            var  a = rndi.NextDouble()*1000; 
            Console.WriteLine("Input: " + a);
            Console.WriteLine("C0: " + UniCast.Invoke(a));
            UniCast -= (double x) => ((int) x).ToString().Length;
            Console.WriteLine($"Uni: {UniCast.Invoke(a)}");
            UniCast -= LamdaExp;
            Console.WriteLine($"Uni: {UniCast.Invoke(a)}");
        }
    }
}