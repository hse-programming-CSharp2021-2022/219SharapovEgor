using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;

abstract class Person
{
    protected string Name { get; }
    
    protected string Pocket { get; set; }

    public abstract void Receive(string present);

    protected Person(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("parameter 'string name' is empty");
        Name = name;
    }

    public override string ToString()
    {
        return $"Name is {Name}";
    }
}

class SnowMaiden : Person
{
    public SnowMaiden(string name) : base(name) { }

    public override void Receive(string present)
    {
        if (!string.IsNullOrEmpty(Pocket))
        {
            throw new ArgumentException("Pocket of maiden is full.");
        }

        Pocket = present;
    }

    public string[] CreatePresents(int amount)
    {
        var presents = new string[amount];
        for (var i = 0; i < presents.Length; i++)
        {
            var syms = new string[3];
            for (var j = 0; j < 2; j++)
            {
                var r = new Random();
                var sym = (char) r.Next(0, 127);
                syms[j] = sym.ToString();
            }

            presents[i] = syms[0] + syms[1] + syms[2] + syms[1] + syms[0];
        }

        return presents;
    }
}

class Santa : Person
{
    public List<string> sack;

    public Santa(string name) : base(name)
    {
        sack = new List<string>();
    }

    public override void Receive(string present)
    {
        if (!string.IsNullOrEmpty(Pocket))
        {
            throw new ArgumentException("Pocket of Santa is full.");
        }

        Pocket = present;
    }
    
    public void Request(SnowMaiden maiden, int amount)
    {
        var presents = maiden.CreatePresents(amount);
        foreach (var present in presents)
        {
            sack.Add(present);
        }
    }

    public void Give(Person person)
    {
        if (sack.Count == 0)
        {
            throw new Exception("Lack of presents in sack.");
        }
        var r = new Random();
        var indOfPresent = r.Next(0, sack.Count);
        person.Receive(sack[indOfPresent]);
        sack.RemoveAt(indOfPresent);
    }
}

class Child : Person
{
    public Child(string name) : base(name) { }

    private string additionalPocket;
    
    public override void Receive(string present)
    {
        if (!string.IsNullOrEmpty(Pocket) && !string.IsNullOrEmpty(additionalPocket))
        {
            throw new ArgumentException($"Pockets of child {Name} are full.");
        }

        if (!string.IsNullOrEmpty(Pocket))
        {
            additionalPocket = present;
            return;
        }

        Pocket = present;
    }
}

class Program
{
    private static void Main()
    {
        ConsoleKeyInfo exitKey;
        do
        {
            Santa santaMan = new Santa("Hilarious Santa");
            SnowMaiden snowMaiden = new SnowMaiden("Snow Maiden");
            var personsList = new List<Person>(12);
            personsList.Add(santaMan);
            personsList.Add(snowMaiden);
            for (int i = 0; i < 10; i++)
            {
                personsList.Add(new Child($"Child {i + 1}"));
            }
            bool check = true;
            bool isDeleted = false;
            while (true)
            {
                var r = new Random();
                if (r.Next(1, 11) == 1)
                {
                    try
                    {
                        santaMan.Give(santaMan);
                        Console.WriteLine(santaMan);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        if (check)
                            santaMan.Request(snowMaiden, r.Next(1, 5));
                        if (isDeleted)
                            break;
                        goto Label;
                    }
                }
                else
                {
                    var personOfList = r.Next(1, personsList.Count);
                    try
                    {
                        santaMan.Give(personsList[personOfList]);
                        Console.WriteLine(personsList[personOfList]);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        personsList.RemoveAt(personOfList);
                        if (personOfList == 1 && !isDeleted)
                        {
                            check = false;
                            isDeleted = true;
                        }
                    }
                    catch
                    {
                        if (check)
                            santaMan.Request(snowMaiden, r.Next(1, 5));
                        if (isDeleted)
                            break;
                        goto Label;
                    }
                }

                if (check)
                    santaMan.Request(snowMaiden, r.Next(1, 5));
                Label:
                if (santaMan.sack.Count == 0)
                {
                    break;
                }

                if (personsList.Count == 1)
                {
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Для выхода нажмите Escape, чтобы повторить, нажмите любую другую кнопку!");
            Console.ResetColor();
            exitKey = Console.ReadKey();
        } while (exitKey.Key != ConsoleKey.Escape);
        
    }
}
