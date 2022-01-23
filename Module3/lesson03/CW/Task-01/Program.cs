using System;
using System.Drawing;

namespace Task_01
{
    public delegate void SquareSizeChanced(double data);

    class Square
    {
        private double x_l;
        private double y_l;
        private double x_r;
        private double y_r;
        public event SquareSizeChanced OnSizeChanced;

        
        public (double, double) UpperLeft
        {
            get
            {
                return (x_l, y_l);
            }
            private set
            {
                x_l = value.Item1;
                y_l = value.Item2;
                OnSizeChanced?.Invoke(Size());
            }
        }
        
        
        public (double, double) DownRight
        {
            get
            {
                return (x_r, y_r);
            }
            set
            {
                x_r = value.Item1;
                y_r = value.Item2;
                OnSizeChanced?.Invoke(Size());
            }
        }

        public Square(double x_l, double y_l, double x_r, double y_r)
        {
            UpperLeft = (x_l, y_l);
            DownRight = (x_r, y_r);
        }

        private double Size() => Math.Sqrt(Math.Pow(x_r-x_l,2)+Math.Pow(y_r-y_l,2)) * 1/Math.Sqrt(2);
    }
    class Program
    {
        static void SquareConsoleInfo(double data)
        {
            Console.WriteLine(data.ToString("f3"));
        }
        static void Main(string[] args)
        {
            var x_l = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var y_l = double.Parse(Console.ReadLine());
            var x_r = double.Parse(Console.ReadLine());
            var y_r = double.Parse(Console.ReadLine());
            var S = new Square(x_l, y_l, x_r, y_r);
            S.OnSizeChanced += SquareConsoleInfo;
            var input = Console.ReadLine();
            while (input != "-")
            {
                input = Console.ReadLine();
                x_r = double.Parse(input);
                input = Console.ReadLine();
                y_r = double.Parse(input);
                S.DownRight = (x_r, y_r);
            }
        }
    }
}