using System;
namespace Task01
{
    public class Data : EventArgs
    {
        public Data(string str)
        {
            s = str;
        }
        public string s { get; set; }
    }
    public class UIString
    {
        string str = "Default text";
        public string Str { get { return str; } private set { str = value; } }

        public void NewStringValueHappenedHandler(object sender, Data e)
        {
            Str = e.s;
        }
    }
    class ConsoleUI
    {
        UIString s = new UIString(); // специальная строка
        public UIString S { get { return s; } set { s = value; } }
        public void GetStringFromUI()
        {
            Console.Write("Введите новое значение строки: ");
            string str = Console.ReadLine();
            NewStringValueHappened?.Invoke(this, new Data(str));
            RefreshUI();
            
        }
        public void CreateUI()
        {
            RefreshUI();
            NewStringValueHappened += s.NewStringValueHappenedHandler;
        }
        public void RefreshUI()
        {      // обновление строки     
            Console.Clear();
            Console.WriteLine("Текст строки: " + s.Str);
        }
        
        public event EventHandler<Data> NewStringValueHappened;
        
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            ConsoleUI c = new ConsoleUI();
            c.CreateUI(); // запускаем выполнение объекта класса ConsoleUI
            do
            {
                c.GetStringFromUI();  // изменяем значение строки
                Console.WriteLine("Чтобы закончить эксперименты, нажмите ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}