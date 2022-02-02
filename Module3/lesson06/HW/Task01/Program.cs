using System;
using System.Collections.Generic;

namespace Task01
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y) => (X, Y) = (x, y);

        public double Distance(Point p) => Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));

        public override string ToString() => $"Point({X};{Y})";
    }

    class Circle : IComparable
    {
        public Point center { get; set; }
        public double Rad { get; set; }

        public Circle(double x, double y, double radius) => (center, Rad) = (new Point(x, y), radius);

        public override string ToString() => $"Radius length is {Rad} and center of circle is {center}";

        public int CompareTo(object? a)
        {
            if (a != null)
            {
                var x1 = this;
                var x2 = a as Circle;
                if (x1.Rad * x1.center.Distance(new Point(0, 0)) > x2.Rad * x2.center.Distance(new Point(0, 0)))
                    return 1;
                if (x1.Rad * x1.center.Distance(new Point(0, 0)) - x2.Rad * x2.center.Distance(new Point(0, 0)) ==
                    0)
                    return 0;
                return -1;
            }

            return -2;
        }
    }
    
    struct CircleNew
    {
        public PointNew center { get; set; }
        public double Rad { get; set; }

        public CircleNew(double x, double y, double radius) => (center, Rad) = (new PointNew(x, y), radius);

        public override string ToString() => $"Radius length is {Rad} and center of circle is {center}";
    }

    struct PointNew
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointNew(double x, double y) => (X, Y) = (x, y);

        public double Distance(Point p) => Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));

        public override string ToString() => $"Point({X};{Y})";
    }

    class Program
    {
        static void Main()
        {
            var circles = new List<Circle>(15);

            for (int i = 0; i < 15; i++)
            {
                circles.Add(
                    new Circle(new Random(i).Next(), new Random().Next(),
                        new Random(-1).Next() + new Random().NextDouble()));

            }
            
            circles.Sort((x1, x2) => (x1.Rad * x1.center.Distance(new Point(0, 0))).CompareTo(x2.Rad *
                                                                            x2.center.Distance(new Point(0, 0))));
            circles.Sort((circle, circle1) => circle.CompareTo(circle1));
        }
    }
    
}