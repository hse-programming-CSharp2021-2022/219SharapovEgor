using System;

namespace CW_5
{
    class Program
    {
        static void Sums(uint number, out uint sumEven, out uint sumOdd)
        {
            sumEven = 0;
            sumOdd = 0;
            int a = number.ToString().Length;
            for (int i = 0; i < a+1 ; i++)
            {
                if (number <= 0) break;
                if (i % 2 == 0)
                {
                    sumEven += number % 10;
                    number /= 10;
                }
                else 
                {
                    sumOdd += number % 10;
                    number /= 10;
                    
                }

            }
        }
        static void Main(string[] args)
        {
            uint.TryParse(Console.ReadLine(), out uint num);
            Sums(num, out uint sum_1, out uint sum_2);
            Console.WriteLine($"{sum_1} {sum_2}");
        }
    }
}