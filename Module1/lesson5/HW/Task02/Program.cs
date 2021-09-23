using System;

namespace Task02
{
    class Program
    {
        static double Factorial(int value)
        {
            int ans = 1;
            for (int i = 1; i <= value; i++)
            {
                ans *= i;
            }
            return ans;
        }

        static double S1(double x)
        {
            double data1 = x*x;
            double data2 = data1;
            int i = 2;

            do
            {
                if (i % 2 == 0)
                {
                    data1 -= (Math.Pow(2, i + 1) * Math.Pow(x, i + 2)) / Factorial(i + 2);
                    data2 = data1;
                    data2 += (Math.Pow(2, i + 3) * Math.Pow(x, i + 4)) / Factorial(i + 4);
                }
                else
                {
                    data1 += (Math.Pow(2, i + 1) * Math.Pow(x, i + 2)) / Factorial(i + 2);
                    data2 = data1;
                    data2 -= (Math.Pow(2, i + 3) * Math.Pow(x, i + 4)) / Factorial(i + 4);
                }

                if (Double.IsNaN(data1) == true) return data1;
                if (Double.IsNaN(data1) == true) return data2;
                i += 1;
            } while (data1 != data2 && Double.IsNaN(data1) == false && Double.IsNaN(data2) == false && data1 != Double.NegativeInfinity && data2 != Double.NegativeInfinity
            && data1 != Double.PositiveInfinity && data2 != Double.PositiveInfinity);

            return data1;
        } 
        static double S2(double x)
        {
            double data1 = 1;
            double data2 = data1;
            int i = 1;

            do
            {

                data1 += (Math.Pow(x,i)) / Factorial(i);
                data2 = data1;
                data2 += Math.Pow(x, i + 1)/ Factorial(i + 1);
                if (Double.IsNaN(data1) == true) return data1;
                if (Double.IsNaN(data1) == true) return data2;
                i += 1;
            } while (data1 != data2 && Double.IsNaN(data1) == false && Double.IsNaN(data2) == false && data1 != Double.NegativeInfinity && data2 != Double.NegativeInfinity
                     && data1 != Double.PositiveInfinity && data2 != Double.PositiveInfinity);

            return data1;
        }
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            string str;
            double x;
            do
            {
                do
                {
                    str = Console.ReadLine();
                } while (!double.TryParse(str, out x));

                Console.WriteLine($"{S1(x)} | {S2(x)}");
                Console.WriteLine("Чтобы выйти - нажмите Esc!");                
                exitKey = Console.ReadKey();
                Console.WriteLine("Продолжаем!");
            } while (exitKey.Key != ConsoleKey.Escape);;
        }
    }
}