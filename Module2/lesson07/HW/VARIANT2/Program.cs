using System;
using System.Text;

namespace VARIANT2
{
    class Creature
    {
        public static Random rnd = new Random();
        public string Name { get;}
        
        public double Speed { get;}
        
        public Creature(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }

        public virtual string Run()
        {
            return $"I am running with a speed of {Math.Round(Speed, 1)}.";
        }

        public override string ToString()
        {
            return $"{Run()} My name is {Name}.";
        }
    }
    class Dwarf:Creature
    {
        private int strenght;
        
        public int Strength 
        {            
            get
            {
                return strenght;
            }
            set
            {
                if (value >= 1 && value <= 20)
                    strenght = value;
                else
                {
                    strenght = rnd.Next(1, 21);
                }
            }
            
        }
        
        public Dwarf(string name, double speed, int strength) : base(name, speed)
        {
            Strength = strength;
        }

        public override string Run()
        {
            return $"I am running with a speed of {Math.Round(Speed, 1)}. My strength is {Strength}.";
        }

        public static void MakeNewStaff()
        {
            Console.WriteLine("I've created a new staff!");
        }
        
        public override string ToString()
        {
            return $"{Run()} My name is {Name}.";
        }
    }
    class Elf:Creature
    {
        private uint age;

        private double GetElfSpeed()
        {
            return Math.Round(Speed + Age / 77, 1);
        }
        public uint Age { get; }

        public Elf(string name, double speed) : base(name, speed)
        {
            Age = (uint) rnd.Next(100, 201);
        }
        
        public override string Run()
        {
            return $"I am running with a speed of {GetElfSpeed()}. My age is {Age}.";
        }
        
        public override string ToString()
        {
            return $"{Run()} My name is {Name}.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = Creature.rnd;

            string GenerateName()
            {
                uint n = (uint)rnd.Next(3, 11);
                var s = new StringBuilder((int)n);
                s.Append((char) rnd.Next('A', 'Z' + 1));
                for (var i = 1; i < n; i++)
                    s.Append((char) rnd.Next('a', 'z' + 1));
                return s.ToString();
            }
            
            ConsoleKeyInfo exitKey;
            do
            {
                uint n;
                do
                {
                    Console.Write("Введите число существ (не больше 100): ");
                } while (!uint.TryParse(Console.ReadLine(), out n) || n > 100);

                var creatures = new Creature[n];

                for (var i = 0; i < creatures.Length; i++)
                {
                    double chance = rnd.NextDouble();

                    if (chance <=  0.2)
                    {
                        creatures[i] = new Creature(GenerateName(), rnd.Next(10, 18) + rnd.NextDouble());
                    }
                    else if (chance <= 0.6)
                    {
                        creatures[i] = new Dwarf(GenerateName(), rnd.Next(10, 18) + rnd.NextDouble(), rnd.Next(-50, 50));
                    }
                    else if (chance <= 1)
                    {
                        creatures[i] = new Elf(GenerateName(), rnd.Next(10, 18) + rnd.NextDouble());
                    }
                }

                for (int i = 0; i < creatures.Length; i++)
                {
                    if (creatures[i] is Dwarf)
                    {
                        Console.WriteLine(creatures[i]);
                        Dwarf.MakeNewStaff();
                    }
                    else
                    {
                        Console.WriteLine(creatures[i]);
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Для выхода нажмите Escape, чтобы повторить, нажмите любую другую кнопку!");
                Console.ResetColor();
                exitKey = Console.ReadKey();
            } while (exitKey.Key != ConsoleKey.Escape);
        }
    }
}