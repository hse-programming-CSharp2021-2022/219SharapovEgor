using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            double S1 = 0;
            double S2;
            double n = 1;
            do
            {
                S2 = S1;
                S1 += 1 / (n * (n + 1) * (n + 2));
                n += 1;
            } while (S1 != S2);
            Console.WriteLine(S1);
            
            
            float S1_f = 0;
            float S2_f;
            float n_f = 1;
            do
            {
                S2_f = S1_f;
                S1_f += 1 / (n_f * (n_f + 1) * (n_f + 2));
                n_f += 1;
            } while (S1_f != S2_f);
            Console.WriteLine(S1_f);
        }
    }
}