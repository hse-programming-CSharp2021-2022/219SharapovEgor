using System;

namespace Task01
{//Task01
    public delegate void CoordChanged(Dot x);
    public class Dot
    {
        public Random rnd = new Random();
        public double X
        {
            get;
            set;
        }
        
        public double Y
        {
            get;
            set;
        }

        public Dot(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void DotFlow()
        {
            for (int i = 0; i < 10; i++)
            {
                X = rnd.Next(-10, 10) + rnd.NextDouble();
                Y = rnd.Next(-10, 10) + rnd.NextDouble();
            }
            if (X < 0 && Y < 0)
            {
                OnCoordChanged(new Dot(X, Y));
            }
        }

        public event CoordChanged OnCoordChanged;
    }
    class Program
    {
        public static void PrintInfo(Dot A)
        {
            Console.WriteLine($"X: {A.X} Y:{A.Y}");
        }
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            Dot D = new Dot(x, y);
            D.OnCoordChanged += PrintInfo;
            D.DotFlow();
        }
    }
}