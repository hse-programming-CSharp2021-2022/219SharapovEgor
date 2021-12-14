using System;
using System.Threading.Channels;

namespace CW
{
    class Program
    {
        static void Main(string[] args)
        {
            var prog1 = new ArithmeticProgression(2, 10);
            var prog2 = new ArithmeticProgression(3, 10);
            var prog3 = new ArithmeticProgression(4, 10);
            Console.WriteLine(prog1[3]);
            Console.WriteLine(prog1[5]);
            Console.WriteLine(prog2[3]);
            Console.WriteLine(prog2[5]);
            Console.WriteLine(prog3[3]);
            Console.WriteLine(prog3[5]);
            Console.WriteLine(ArithmeticProgression.Count);
        }
    }

    class ArithmeticProgression
    {
        public int A0 { get; private set; }
        public int D { get; set; }

        public static int Count = 0;

        static ArithmeticProgression()
        {
            Console.WriteLine("");
        }
        
        public ArithmeticProgression(int A0, int D)
        {
            (this.A0, this.D) = (A0, D);
            Count++;
        }
        
        public ArithmeticProgression() : this(0,0) { }

        public int this[int index]
        {
            get
            {
                return A0 + D * (index);
            }
        }

        ~ArithmeticProgression()
        {
            Console.WriteLine("Destructor!");
        }
    }
}