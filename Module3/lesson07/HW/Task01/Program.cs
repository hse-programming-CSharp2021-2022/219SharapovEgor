using System;
using System.Text;

public struct Person : IComparable<Person>
{
    
    private string name;
    private string surname;
    private int age;
    
    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Имя должно содержать символы!");
            name = value;
        }
    }

    public string Surname
    {
        get => surname;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Фамилия должна содержать символы!");
            surname = value;
        }
    }
    
    public int Age
    {
        get => age;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException( "", "Возраст не должен быть отрицательным!");
            age = value;
        }
    }



    public Person(string name, string surname, int age)
    {
        this.name = "No";
        this.surname = "Name";
        this.age = 0;
        
        Name = name;
        Surname = surname;
        Age = age;
    }

    public int CompareTo(Person person)
    {
        if (Age > person.Age) return 1;
        else if(Age == person.Age) return 0;
        else return -1;
    }
    
    public override string ToString() => $"Имя - {Name} \nФамилия - {Surname} \nВозраст - {Age}";
}

class Program
{
    static void Main()
    {
        int.TryParse(Console.ReadLine(), out var num);
        var persons = new Person[num];
        
        for (var i = 0; i < num; i++)
        {
            Random random = new();
            
            var controlNum = random.Next(3, 10);
            var stringBuilder = new StringBuilder("");
            stringBuilder.Append((char) random.Next(65, 91));
            
            for (var j = 0; j < controlNum - 1; j++)
            {
                stringBuilder.Append((char) random.Next(97, 123));
            }
            
            var surname = stringBuilder.ToString();

            controlNum = random.Next(3, 9);
            stringBuilder = new StringBuilder("");
            stringBuilder.Append((char) random.Next(65, 91));
            
            for (var j = 0; j < controlNum - 1; j++)
            {
                stringBuilder.Append((char) random.Next(97, 123));
            }
            
            var name = stringBuilder.ToString();
            
            persons[i] = new Person(name, surname, random.Next(1, 101));
        }
        
        Array.ForEach(persons,x => Console.WriteLine(x));
        Array.Sort(persons);
        Array.ForEach(persons,x => Console.WriteLine(x));
        
    }
}