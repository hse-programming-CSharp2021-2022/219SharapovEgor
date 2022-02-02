using System;
using System.Collections.Generic;

namespace Task01
{


    interface IJumpable
    {
        public void Jump();
    }

    interface IRunable
    {
        public void Run();
    }
    
    abstract class Animal
    {
        public int age;

        public Animal(int age)
        {
            this.age = age;
        }
    }

    class AnimalCompare: IComparer<Animal>
    {
        public int Compare(Animal a, Animal b)
        {
            return a.age.CompareTo(b.age);
        }
    }

    class Cockroach: Animal, IRunable
    {
        public int speed;

        public Cockroach(int age ,int speed): base(age)
        {
            this.speed = speed;
        }

        public void Run()
        {
            Console.WriteLine($"Я весёлый таракан, я бегу, бегу, бегу со скоростью {speed} и мне {age} лет!");
        }
        

        
    }
    
    class CockroachCompare: IComparer<Cockroach>
    {
        public int Compare(Cockroach a, Cockroach b)
        {
            return a.speed.CompareTo(b.speed);
        }
    }

    class Kangaroo: Animal, IJumpable
    {
        public int lengthOfJump;
        
        public Kangaroo(int age ,int lengthOfJump): base(age)
        {
            this.lengthOfJump = lengthOfJump;
        }

        public void Jump()
        {
            Console.WriteLine($"Я кенгуру и я умею прыгать на {lengthOfJump} см и мне {age} лет!");
        }

    }
    
    class KangCompare: IComparer<Kangaroo>
    {
        public int Compare(Kangaroo a, Kangaroo b)
        {
            return a.lengthOfJump.CompareTo(b.lengthOfJump);
        }
    }
    
    class Cheetah: Animal, IJumpable, IRunable
    {
        public int lengthOfJump;
        public int speed;
        
        public Cheetah(int age, int lengthOfJump, int speed): base(age)
        {
            this.lengthOfJump = lengthOfJump;
            this.speed = speed;
        }

        public void Run()
        {
            Console.WriteLine($"Я гепардик! Я бегаю со скоростью {speed} см и мне {age} лет!");
        }
        public void Jump()
        {
            Console.WriteLine($"Я гепардик! Я умею прыгать на {lengthOfJump} см и мне {age} лет!");
        }
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Animal[] animals = new Animal[10];

            for (int i = 0; i < animals.Length; i++)
            {
                if (i%3 == 0)
                {
                    animals[i] = new Cheetah(rnd.Next(1, 15), rnd.Next(150, 250), rnd.Next(100, 200));
                }
                else if (i % 2 == 0)
                {
                    animals[i] = new Kangaroo(rnd.Next(1, 25), rnd.Next(200, 300));
                }
                else
                {
                    animals[i] = new Cockroach(rnd.Next(0, 3), rnd.Next(100000, 1000000));
                }
            }
            
            ForEachAnimal(animals);

            List<IJumpable> IJump = new List<IJumpable>();
            
            List<IRunable> IRun = new List<IRunable>();

            for (int i = 0; i < animals.Length; i++)
            {
                if (animals[i] is IRunable)
                {
                    IRun.Add((IRunable)animals[i]);
                }
                if (animals[i] is IJumpable)
                {
                    IJump.Add((IJumpable)animals[i]);
                }
            }

            foreach (var animal in IJump)
            {
                animal.Jump();
            }

            foreach (var animal in IRun)
            {
                animal.Run();
            }
            foreach (var animal in animals)
            {
                string type = String.Empty;
                if (animal is Cockroach)
                {
                    type = "Таракашка";
                }
                if (animal is Kangaroo)
                {
                    type = "Кенгуру";
                }
                if (animal is Cheetah)
                {
                    type = "Гепард";
                }

                Console.WriteLine($"Я {type} мне {animal.age}!");
            }
            Console.WriteLine("Сортировка!___________________________________");
            Array.Sort(animals, new AnimalCompare());
            
            foreach (var animal in animals)
            {
                string type = String.Empty;
                if (animal is Cockroach)
                {
                    type = "Таракашка";
                }
                if (animal is Kangaroo)
                {
                    type = "Кенгуру";
                }
                if (animal is Cheetah)
                {
                    type = "Гепард";
                }

                Console.WriteLine($"Я {type} мне {animal.age}!");
            }

            List<Cockroach> cockroaches = new List<Cockroach>();
            for (var i = 0; i < animals.Length; i++)
            {
                if (animals[i] is Cockroach)
                {
                    cockroaches.Add((Cockroach)animals[i]);
                }
            }

            Cockroach[] cockrochess = cockroaches.ToArray();
            Array.Sort(cockrochess, new CockroachCompare());
            Console.WriteLine($"Я самый быстрый таракан, бегаю со скоростью {cockrochess[0].speed}");
            
            foreach (var animal in cockrochess)
            {
                animal.Run();
            }
            
            List<Kangaroo> kangaroos = new List<Kangaroo>();
            for (var i = 0; i < animals.Length; i++)
            {
                if (animals[i] is Kangaroo)
                {
                    kangaroos.Add((Kangaroo)animals[i]);
                }
            }

            Kangaroo[] kangaroosss = kangaroos.ToArray();
            Array.Sort(kangaroosss, new KangCompare());
            
            foreach (var animal in kangaroosss)
            {
                animal.Jump();
            }
        }

        private static void ForEachAnimal(Animal[] animals)
        {
            foreach (var animal in animals)
            {
                string type = String.Empty;
                if (animal is Cockroach)
                {
                    type = "Таракашка";
                }

                if (animal is Kangaroo)
                {
                    type = "Кенгуру";
                }

                if (animal is Cheetah)
                {
                    type = "Гепард";
                }

                Console.WriteLine($"Я {type}!");
            }
        }
    }
}