using System;

namespace Task01
{
    public class RingIsFoundEventArgs : EventArgs
    {
        public RingIsFoundEventArgs(string s)
        {
            Message = s;
        }

        public String Message { get; set; }
    }

    public class Wizard
    {
        public string Name { get; private set; }

        public delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs a);

        public event RingIsFoundEventHandler RaiseRingIsFoundEvent;

        public Wizard(string s)
        {
            Name = s;
        }

        public Wizard()
        {
        }

        public void SomeThisIsChangedInTheAir()
        {
            Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл! ");
            RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs("Ривендейл"));
        }
    }

    public class Hobbit
    {
        public string Name { get; private set; }

        public Hobbit(string s)
        {
            Name = s;
        }

        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Покидаю Шир! Иду в " + e.Message);
        }
    }

    public class Human
    {
        public string Name { get; private set; }

        public Human(string s)
        {
            Name = s;
        }

        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Волшебник {((Wizard) sender).Name} позвал. Моя цель {e.Message}");
        }
    }

    public class Elf
    {
        public string Name { get; private set; }

        public Elf(string s)
        {
            Name = s;
        }

        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine(
                $"{Name} >> Звёзды светят не так ярко как обычно. Цветы увядают. Листья предсказывают идти в " +
                e.Message);
        }
    }

    public class Dwarf
    {
        public string Name { get; private set; }

        public Dwarf(string s)
        {
            Name = s;
        }

        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Точим топоры, собираем припасы! Выдвигаемся в " + e.Message);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Гендальф");
            Hobbit[] hobbits = new Hobbit[4];
            for (int i = 0; i < hobbits.Length; i++)
            {
                hobbits[i] = new Hobbit($"Хоббит {i}");
                wizard.RaiseRingIsFoundEvent += hobbits[i].RingIsFoundEventHandler;
            }
            Human[] humans = {new Human("Боромир"), new Human("Арагорн")};
            Dwarf dwarf = new Dwarf("Гимли");
            Elf elf = new Elf("Леголас");
            wizard.RaiseRingIsFoundEvent += dwarf.RingIsFoundEventHandler;
            wizard.RaiseRingIsFoundEvent += elf.RingIsFoundEventHandler;
            foreach (Human h in humans)
                wizard.RaiseRingIsFoundEvent += h.RingIsFoundEventHandler;
            wizard.SomeThisIsChangedInTheAir();

        }
    }
}