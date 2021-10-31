using System;

namespace Task02
{
    class Program
    {

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x = 0, double y = 0)
            {
                X = x;
                Y = y;
            }

            public double R
            {
                get
                {
                    return Math.Sqrt(X * X + Y * Y);
                }
            }

            public double F
            {
                get
                {
                    return Math.Atan2(Y, X);
                }
            }

            public override string ToString()
            {
                return $"x = {X}\ty = {Y}\nr = {R}\tf = {F}\n-----------------------";
            }
        }

        public static Point MaximumPoint(Point pointOne, Point pointTwo, Point pointThree)
        {
            if (pointOne.R > Math.Max(pointTwo.R, pointThree.R))
            {
                return pointOne;
            }
            if (pointTwo.R > Math.Max(pointOne.R, pointThree.R))
            {
                return pointTwo;
            }
            return pointThree;
        }
        
        public static Point MidPoint(Point pointOne, Point pointTwo, Point pointThree)
        {
            if (pointOne != MaximumPoint(pointOne, pointTwo, pointThree) && pointOne != MinimalPoint(pointOne,
                pointTwo, pointThree))
            {
                return pointOne;
            }
            if (pointTwo != MaximumPoint(pointOne, pointTwo, pointThree) && pointTwo != MinimalPoint(pointOne,
                pointTwo, pointThree))
            {
                return pointTwo;
            }
            return pointThree;
        }
        
        public static Point MinimalPoint(Point pointOne, Point pointTwo, Point pointThree)
        {
            if (pointOne.R < Math.Min(pointTwo.R, pointThree.R))
            {
                return pointOne;
            }
            if (pointTwo.R < Math.Min(pointOne.R, pointThree.R))
            {
                return pointTwo;
            }
            return pointThree;
        }

        static void Main()
        {
            Point firstPoint, secondPoint, thridPoint;
            firstPoint = new Point(1, -1);
            Console.WriteLine("Первая созданная точка");
            Console.WriteLine(firstPoint);
            secondPoint = new Point(10, 12);
            Console.WriteLine("Вторая созданная точка");
            Console.WriteLine(secondPoint);
            double x = 0, y = 0;
            do
            {
                Console.Write("Введите x = ");
                double.TryParse(Console.ReadLine(), out x);
                Console.Write("Введите y = ");
                double.TryParse(Console.ReadLine(), out y);
                thridPoint = new Point(x, y);

                Console.WriteLine(MinimalPoint(firstPoint, secondPoint, thridPoint));
                Console.WriteLine(MidPoint(firstPoint, secondPoint, thridPoint));
                Console.WriteLine(MaximumPoint(firstPoint, secondPoint, thridPoint));

            } while (x != 0 | y != 0);
            Console.WriteLine("Работа завершена!");
        }
    }
}