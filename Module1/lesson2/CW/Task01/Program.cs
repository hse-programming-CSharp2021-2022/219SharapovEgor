using System;

namespace Task01
{
    class Program
    {
        public static double GetSquare(double r)
        {
            return Math.PI * r * r;
        }
        static void Main(string[] args)
        {
            string r = Console.ReadLine();
            if (!double.TryParse(r,out double data)) Console.WriteLine("Неверный ввод!");
            else Console.WriteLine($"Длина: {2*Math.PI*data:.000}\nПлощадь: {GetSquare(data):.000}");
        }
    }
}