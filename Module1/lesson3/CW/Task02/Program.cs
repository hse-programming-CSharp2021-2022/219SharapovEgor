using System;

namespace Task02
{
    class Program
    {
        static void Function1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine((i+1)*(i+1));
            }

        }
        static void Function2()
        {
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine((i+1)*(i+1));
                i++;
            }

        }
        static void Function3()
        {
            int i = 0;
            do
            {
                Console.WriteLine((i + 1) * (i + 1));
                i++;
            } while (i < 10);

        }
        
        static void Main(string[] args)
        {
            Function1();
            Function2();
            Function3();
        }
    }
}