using System;

namespace Task01
{
    class Program
    {
        static bool Shift(ref char ch)
        {
            
            try
            {
                ch = Convert.ToChar(Console.ReadKey().KeyChar);
            }
            catch
            {
                return false;
            }
            if (Convert.ToInt32(ch) < 97 || Convert.ToInt32(ch) > 118) return false;
            Console.WriteLine($" Ответ: {Convert.ToChar(Convert.ToInt32(ch)+4)}\n");
            return true;
        }
        
        static void Main(string[] args)
        {
            //Бесконечное общение)
            do
            {
                char ch = ' ';
                bool now = Shift(ref ch);
                
                if (now == false) Console.WriteLine(" Невозможно сдвинуть на 4!");
            } while (true);

        }
    }
}