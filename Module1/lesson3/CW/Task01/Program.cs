using System;

namespace CW_3
{
    class Program
    {


        static bool Function1(bool p, bool q)
        {
            return !(p && q) && !(p || !q);
        }

        static void Function2(bool p, bool q, out bool ans)
        {
            ans = !(p && q) && !(p || !q);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("p q F");
            for (int p = 0; p < 2; p++)
            {
                for (int q = 0; q < 2; q++)
                {
                    Console.WriteLine(
                        $"{p} {q} {Convert.ToInt32(Function1(Convert.ToBoolean(p), Convert.ToBoolean(q)))}");
                }
            }
        }
    }
}