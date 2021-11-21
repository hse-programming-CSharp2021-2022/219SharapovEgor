using System;
using System.Net;
using System.Reflection;
using System.Text;

namespace HW_18
{
    class Person
    {
        public Random rnd = new Random();
        public string Name {set;get;}
        public uint Age {set; get;}

        public Person(string name, uint age)
        {
            Name = name;
            Age = age;
        }
        public virtual string Say() => "I am a simple person.";

        public override string ToString()
        {
            return $"{Say()} My name is {Name}, my age is {Age}.";
        }

    }

    class Doctor : Person
    {
        private uint exp;
        public uint Exp
        {
            get
            {
                return exp;
            }
            set
            {
                if (value >= 5 && value <= 20)
                    exp = value;
                else
                {
                    exp = (uint)rnd.Next(5, 21);
                }
            }
        }

        public override string Say()
        {
            return $"I am a doctor. I've studied for {exp} years.";
        } 

        public string Heal(Person p)
        {
           return $"I'm gonna heal: {p}";
        }

        public Doctor(string name, uint age, uint expr) : base(name, age)
        {
            if (expr >= 5 && expr <= 20)
                exp = expr;
            else
            {
                exp = (uint)rnd.Next(5, 21);
            }    
        }
    }

    class Intern : Doctor
    {
        private uint exp;
        public uint Exp
        {
            get => exp;
            set
            {
                if (value >= 1 && value <= 4)
                    exp = value;
                else
                {
                    exp = (uint)rnd.Next(1, 5);
                }
            }
        }   
    
        public override string Say()
        { 
            return $"I am an intern. I've studied for {exp} years.";
        } 

        public Intern(string name, uint age, uint expr) : base(name, age, expr)
        {
            if (expr >= 1 && expr <= 4)
                exp = expr;
            else
            {
                exp = (uint)rnd.Next(1, 4);
            }       
        }
    }

    class Program
    {
        static Random rnd = new Random();
        public static string GenerateName()
        {
            uint n = (uint)rnd.Next(3, 11);
            var s = new StringBuilder((int)n);
            s.Append((char) rnd.Next('A', 'Z' + 1));
            for (var i = 1; i < n; i++)
                s.Append((char) rnd.Next('a', 'z' + 1));
            return s.ToString();
        }
    
        public static void Main(string[] args)
        {
            ConsoleKeyInfo exitKey;
            do
            {
                var dr = new Doctor(GenerateName(), (uint)rnd.Next(18, 61), (uint)rnd.Next(-50, 51));
                var intern = new Intern(GenerateName(), (uint)rnd.Next(18, 61), (uint)rnd.Next(-50, 51));
                Console.Write("Введите число людей: ");
                var n = uint.Parse(Console.ReadLine());
                var persons = new Person[n];

                for (var i = 0; i < n - 1; i++)
                    persons[i] = new Person(GenerateName(), (uint)rnd.Next(120));
            
                persons[n - 1] = new Doctor(GenerateName(), (uint)rnd.Next(18, 61), (uint)rnd.Next(-50, 51));

                for (int i = 0; i < n / 2; i++)
                    Console.WriteLine(dr.Heal(persons[i]));
            
                Console.WriteLine(intern);
            
                for (uint i = n / 2; i < (n % 2 == 0 ? n : n - 1); i++)
                    Console.WriteLine(dr.Heal(persons[i]));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Для выхода нажмите Escape, чтобы повторить, нажмите любую другую кнопку!");
                Console.ResetColor();
                exitKey = Console.ReadKey();
            } while (exitKey.Key != ConsoleKey.Escape);

        }
    }
}