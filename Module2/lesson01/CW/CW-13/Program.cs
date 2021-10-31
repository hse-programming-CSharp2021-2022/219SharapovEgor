using System;

namespace CW_13
{
    class RegularPolygon
    {
        private int numSides;
        private int radius;

        public RegularPolygon(int numSides = 0, int radius = 0)
        {
            NumSides = numSides;
            Radius = radius;
        }
        
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
            
        }
        public int NumSides
        {
            get
            {
                return numSides;
            }
            set
            {
                numSides = value;
            }
            
        }

        public double Perimeter()
        {
            return 2 * (Radius / (Math.Cos(Math.PI / NumSides)))*(Math.Sin(Math.PI/NumSides));
        }

        public double Square()
        {
            return 0.5 * Perimeter() * (Radius / (Math.Cos(Math.PI / NumSides)));
        }
        
        public void PolygonData()
        {
            Console.WriteLine($"Радиус: {this.Radius}\n" +
                              $"Колличество сторон: {this.NumSides}\n" +
                              $"Периметр: {this.Perimeter()}\n" +
                              $"Площадь: {this.Square()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var coolMan = new RegularPolygon(3, 4);
            coolMan.PolygonData();
        }
    }
}