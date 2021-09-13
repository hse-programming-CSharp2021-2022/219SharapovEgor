using System;

namespace Task06
{
    class Program
    {
        static decimal BudgetPercent(decimal budget, uint percent)
        {
            decimal ans;

            ans = budget * (percent/100m);

            return ans;
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            decimal budget;
            uint percent;

            do
            {
                do
                {
                    Console.Write("Бюджет: ");
                } while (!decimal.TryParse(Console.ReadLine(), out budget) || budget <= 0);

                do
                {
                    Console.Write("Процент: ");
                } while (!uint.TryParse(Console.ReadLine(), out percent) || percent > 100);


                Console.WriteLine(BudgetPercent(budget, percent).ToString("C",
                    new System.Globalization.CultureInfo("en-US")));

                Console.WriteLine("Для выхода нажмите Escape, чтобы продолжить, нажмите любую другую кнопку!");
                exitKey = Console.ReadKey();
            } while (exitKey.Key != ConsoleKey.Escape);
        }
    }
}