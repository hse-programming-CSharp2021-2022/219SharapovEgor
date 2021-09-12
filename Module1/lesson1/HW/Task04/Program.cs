using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            double U;
            double R;
            string ent1 = Console.ReadLine();
            string ent2 = Console.ReadLine();
            if (!double.TryParse(ent1, out U) || !double.TryParse(ent2, out R))
            {
                Console.WriteLine("Некоректный ввод!");
            }
            else
            {
                Console.WriteLine($"Cила тока: {U/R}\nМощность: {U*U/R}");
            }
        }
    }
}
