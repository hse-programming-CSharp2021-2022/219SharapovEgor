using System;

namespace Task02
{
    class Program
    {
        static void Print(double[] data)
        {
            Array.ForEach(data, el => Console.Write(el + " "));
            Console.WriteLine(" ");
        }
        static void Print(int[] data)
        {
            Array.ForEach(data, el => Console.Write(el + " "));
            Console.WriteLine(" ");
        }
        
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            var rnd = new Random();

            double[] data = new double[size];
            int[] dataC = new int[size];
            double[] dataD = new double[size];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (rnd.Next(-10, 10) + rnd.NextDouble());
            }
            Print(data);
            for (int i = 0; i < data.Length; i++)
            {
                dataC[i] = (int) data[i];
                dataD[i] = data[i] - (int) data[i];
            }
            Print(dataC);
            Print(dataD);
        }
    }
}