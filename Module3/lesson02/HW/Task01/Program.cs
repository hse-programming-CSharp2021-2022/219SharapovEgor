using System;
using System.Collections.Generic;

namespace Task01
{
    class Plant
    {
        private double growth;
        private double photosensiuvity;
        private double frostresistance; 
        
        public double Growth
        {
            get => growth;
            private set => growth = value;
        }
        
        public double Photosensiuvity
        {
            get => photosensiuvity;
            private set
            {
                if(value  >= 0 && value <= 100)
                    photosensiuvity = value;
                else
                {
                    photosensiuvity = 0;
                }
            }
        }

        public double Frostresistance
        {
            get => frostresistance; 
            set
            {
                if(value  >= 0 && value <= 100)
                    frostresistance = value;
                else
                {
                    frostresistance = 0;
                }
            }
        }

        public Plant(double growth, double photosensiuvity, double frostresistance)
        {
            Growth = growth;
            Photosensiuvity = photosensiuvity;
            Frostresistance = frostresistance;
        }

        public override string ToString()
        {
            return $"growth: {Growth} photosensivity: {Photosensiuvity} frostresistance: {Frostresistance}";
        }
        
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            Console.WriteLine("Введите число необходимых растений:");
            int n = int.Parse(Console.ReadLine());
            Plant[] Plants = new Plant[n];

            for (int i = 0; i < n; i++)
            {
                Plants[i] = new Plant((double) rnd.Next(25,101), (double) rnd.Next(0,101), (double) rnd.Next(0,81));
            }
            
            Array.ForEach(Plants, plant => Console.WriteLine(plant));
            Console.WriteLine("---------------------------");
            Array.Sort(Plants, delegate(Plant plant, Plant plant1) { return plant.Growth > plant1.Growth ? -1 : 1; });
            Array.ForEach(Plants, plant => Console.WriteLine(plant));
            Console.WriteLine("---------------------------");
            Array.Sort(Plants, (plant, plant1) => plant.Growth < plant1.Growth ? -1 : 1);
            Array.ForEach(Plants, plant => Console.WriteLine(plant));
            Console.WriteLine("---------------------------");
            Array.Sort(Plants, Comparison);
            Array.ForEach(Plants, plant => Console.WriteLine(plant));
            Console.WriteLine("---------------------------");
            Array.ConvertAll(Plants, plant => plant.Frostresistance = (plant.Frostresistance % 2 == (0) )? plant.Frostresistance / 3 : plant.Frostresistance / 2);
            Array.ForEach(Plants, plant => Console.WriteLine(plant));
            Console.WriteLine("---------------------------");

        }

        private static int Comparison(Plant x, Plant y)
        {
            int a = (int) x.Photosensiuvity & 1;
            int b = (int) y.Photosensiuvity & 1;

            return (a == b) ? x.Photosensiuvity.CompareTo(y.Photosensiuvity) : a.CompareTo(b);
        }
    }
}