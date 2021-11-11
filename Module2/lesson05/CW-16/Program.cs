using System;

namespace CW_16
{
    abstract class Animal
    {
        protected abstract string name
        {
            get;
            set;
        }
        
        protected abstract int age
        {
            get;
            set;
        }
        
        public virtual string AnimalSound()
        {
            return null;
        }
        public virtual string AnimalInfo()
        {
            return $"Кличка {name}\nВозраст: {age}";
        }

    }
    
    class Dog:Animal
    {
        protected override string name { get; set; }
        protected override  int age { get; set; }
        
        public string dogType { get; set; }
        
        public bool isTrained { get; set; }

        public Dog(string name, int age, string dogType, bool isTrained)
        {
            this.name = name;
            this.age = age;
            this.dogType = dogType;
            this.isTrained = isTrained;
        }
        
        public override string AnimalSound()
        {
            return "Gav Gav BROOOOOO";
        }
        
        public override string AnimalInfo()
        {
            return $"Кличка: {name}\nВозраст: {age}\nПорода: {dogType}\nТренирована: {isTrained}";
        }
    }
    
    class Cow:Animal
    {
        protected override  string name { get; set; }
        protected override  int age { get; set; }
        
        public double milkInDay { get; set; }

        public Cow(string name, int age, double milkInDay)
        {
            this.name = name;
            this.age = age;
            this.milkInDay = milkInDay;
        }
        
        public override string AnimalSound()
        {
            return "Muuuuuuuuuuuuuuuuuuuuuuu";
        }
        
        public override string AnimalInfo()
        {
            return $"Кличка: {name}\nВозраст: {age}\nМолока за день: {milkInDay}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var coolCow = new Cow("КоРво Атанно", 7, 4.3);
            var coolDog = new Dog("Пёс по всем признакам", 4, "улица его родитель", false);
            
            Console.WriteLine($"{coolDog.AnimalInfo()}\n{coolDog.AnimalSound()}\n{coolCow.AnimalInfo()}\nЗвук: {coolCow.AnimalSound()}");
        }
    }
}