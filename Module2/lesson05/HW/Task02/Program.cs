using System;

namespace HW1
{

    public class Cinderella
    {
        public string info = "";
        public override string ToString()
        {
            return info;
        }
    }
    abstract class Something : Cinderella { }

    class Ashes : Something
    {
        private Random rand = new Random();
        private double Volume => rand.Next(0,2) + rand.NextDouble();
        new string info = "Ashes";
        public override string ToString()
        {
            return info + $" Volume = {Volume}";
        }
    }
    
    class Lentil : Something
    {
        private Random rand = new Random();
        private double Weight => rand.Next(0,3) + rand.NextDouble();
        new string info = "Lentil";
        public override string ToString()
        {
            return info + $" Weight = {Weight}";
        }
    }
    
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var rand = new Random();
            var N = int.Parse(Console.ReadLine());
            Cinderella element;
            var arrayCinderella = new Cinderella[N];
            for (int i = 0; i < N; i++)
            {
                if (rand.Next(0, 2) == 1)
                {
                    element = new Lentil();
                }
                else
                {
                    element = new Ashes();
                }

                arrayCinderella[i] = element;
            }
            Array.Sort(arrayCinderella, DelegateWork);
            foreach (var item in arrayCinderella)
            {
                if (item is Ashes)
                    Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------");
            foreach (var item in arrayCinderella)
            {
                if (item is Lentil)
                {
                    Console.WriteLine(item); 
                } 
            }
            
            static int DelegateWork(Cinderella first, Cinderella second)
            {
                if (first is Lentil && second is Ashes) return 1;
                if (first is Ashes  && second is Lentil) return 0;
                return -1;
            }
        }
    }
}