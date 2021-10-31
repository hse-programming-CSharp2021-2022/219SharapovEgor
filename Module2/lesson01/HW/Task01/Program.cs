using System;

namespace HW_13
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
        public static void Print(RegularPolygon[] arrOfPolygons, double min, double max)
        {
            foreach (var item in arrOfPolygons)
            {
                if (item.Square() == max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    item.PolygonData();
                    Console.ResetColor();
                }
                else if (item.Square() == min)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    item.PolygonData();
                    Console.ResetColor();
                }
                else
                    item.PolygonData();
            }
        }
        static void Main()
        {
            do
            {
                Console.Write("Введите кол-во многоугольников: ");
                int numOfPolygons = int.Parse(Console.ReadLine() ?? string.Empty);
                RegularPolygon[] arrOfPolygonObject = new RegularPolygon[numOfPolygons];
                double minValue = double.MaxValue;
                double maxValue = 0;
                for (int i = 0; i < numOfPolygons; i++)
                {
                    Console.Write($"Введите количество сторон: ");
                    int numSides = int.Parse(Console.ReadLine() ?? string.Empty);
                    Console.Write($"Введите радиус: ");
                    int radius = int.Parse(Console.ReadLine() ?? string.Empty);
                    arrOfPolygonObject[i] = new RegularPolygon(numSides, radius);
                    if (arrOfPolygonObject[i].Square() <= minValue)
                    {
                        minValue = arrOfPolygonObject[i].Square();
                    }

                    if (arrOfPolygonObject[i].Square() >= maxValue)
                    {
                        maxValue = arrOfPolygonObject[i].Square();
                    }
                }
                Print(arrOfPolygonObject, minValue, maxValue);
                Console.WriteLine("Нажмите ESC, чтобы выйти!");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}