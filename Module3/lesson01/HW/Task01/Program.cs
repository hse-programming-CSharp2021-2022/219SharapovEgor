using System;

namespace Task01
{
    class Program
    {
        
        public delegate int Cast(double x);
        static void Main(string[] args)
        {
            Cast AnonMeth1 = delegate(double d)
            {
                int x = (int)Math.Round(d);
                return (x + 1) & ~1;
            };
            
            Cast AnonMeth2 = delegate(double d)
            {
                return ((int) d).ToString().Length;
            };
            
            Console.WriteLine(AnonMeth1(112.12121));
            Console.WriteLine(AnonMeth2(112.12121));
            for (var i = 0; i < 3; i++)
            {
                var rnd = new Random();
                var x = rnd.NextDouble()*1000;
                Console.WriteLine($"x : {x}\n Anon1: {AnonMeth1(x)}\n Anon2: {AnonMeth2(x)}");
            }

            Cast NewCast = AnonMeth1 + AnonMeth2;
            
            Console.WriteLine(NewCast.Invoke(32.1222));
            
            Cast Lambda1 = (double x) =>((int)Math.Round(x) + 1) & ~1;

            Cast Lambda2 = (double x) => ((int) x).ToString().Length;
            
            NewCast -= Lambda2;
            
            Console.WriteLine(NewCast.Invoke(32.98888));
            
            NewCast -= AnonMeth2;
            
            Console.WriteLine(NewCast.Invoke(32.98888));
            
        }
    }
}