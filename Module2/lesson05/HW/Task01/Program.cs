using System;

namespace Task01
{
    public class Shape
    { 
        public virtual double Area()
        {
            return 0.0;
        }
        public override string ToString()
        {
            return $"Площадь = {Area():0.000}";
        }
    }
    
    class Circle : Shape
    {
        private double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double Area()
        {
            return 2 * Radius * Math.PI;
        }
    }

    class Cylinder : Shape
    {
        private double Radius { get; }
        private double Height { get; }
        public Cylinder(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }
        public override double Area()
        {
            return 2 * Math.PI* Radius * (Radius + Height);
        }
    }
    
    class Sphere : Shape
    {
        public Sphere(double radius)
        {
            Radius = radius;
        }
        private double Radius { get; }

        public override double Area()
        {
            return 4 * Math.PI * Radius * Radius;
        }
    }
    class Program
    {
        private static void Print(Shape[] shapeArray)
        {
            foreach (var shape in shapeArray)
            {
                if (shape is Circle) Console.WriteLine("Круг");
                else if (shape is Cylinder) Console.WriteLine("Цилиндр");
                else Console.WriteLine("Сфера");
                Console.WriteLine(shape+"\n"); 
            }
        }
        
        static void Main(string[] args)
        {
            Random rnd = new();
            var size1 = rnd.Next(3, 6);
            var size2 = rnd.Next(3, 6);
            var size3 = rnd.Next(3, 6);
            
            Shape[] shapeArray = new Shape[size1 + size2 + size3];
            
            for (var i = 0; i < size1; i++) shapeArray[i] = new Circle(radius: rnd.Next(1, 100) + rnd.NextDouble());
            
            for (var i = size1; i < size1 + size2; i++) shapeArray[i] = new Cylinder(radius: rnd.Next(1, 100) + rnd.NextDouble(), height: rnd.Next(1, 100) + rnd.NextDouble());
            
            for (var i = size2; i < size1 + size2 + size3; i++) shapeArray[i] = new Sphere(radius: rnd.Next(1, 100) + rnd.NextDouble());
            
            Console.WriteLine("Сортировки нет");
            Print(shapeArray);
            Array.Sort(shapeArray, DelegateWork);
            Console.WriteLine("\nСортировано");
            Print(shapeArray);
            
            static int DelegateWork(Shape first, Shape second)
            {
                if (first is Sphere && second is Circle) return 1;
                if (first is Sphere && second is Cylinder) return 1;
                if (first is Sphere && second is Sphere) return 0;
                if (first is Cylinder && second is Circle) return 1;
                if (first is Cylinder && second is Cylinder) return 0;
                if (first is Circle && second is Circle) return 0;
                return -1;
            }
        }
    }
}