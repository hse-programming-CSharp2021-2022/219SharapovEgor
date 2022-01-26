using System;

namespace Task01
{
    interface IFunction   
    {
        double Function(double x);
    }
    
    public delegate double calculate(double x);
    class F:IFunction    
    {
        calculate calculate;
        public F(calculate data) => calculate = data;
        public double Function(double x)
        {
            return calculate(x);
        }
    }
    
    class G    {
        F firstFunc;
        F secondFunc;
        public G(F funcOne ,F funcTwo)
        {
            firstFunc = funcOne;
            secondFunc = funcTwo;
        }
        public double GF(double x0)
        {
            return firstFunc.Function(secondFunc.Function(x0));
        }
    }
    
    class Program    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            do
            {
                try
                {
                    G g = new G(new F(x => x * x + 4), new F(x => Math.Sin(x)));
                    for(double i = 0; i <= Math.PI; i += Math.PI / 16)
                    {
                        Console.Write($"{g.GF(i):F4}\t");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Произошла ошибка: {e}");
                }
                Console.WriteLine();
                Console.WriteLine("Если хотите выйти, нажмите - Esc, иначе нажмите любую другую кнопку!");
                exitKey = Console.ReadKey();
            } while (exitKey.Key != ConsoleKey.Escape);

        }
    }
}