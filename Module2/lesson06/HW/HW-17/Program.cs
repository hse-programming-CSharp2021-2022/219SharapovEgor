using System;
using System.IO;
using System.Text;

namespace HW17
{
    class Program
    {
        

        static void Main(string[] args)
        {
            try
            {
                int[] list = new int[0];
                list[100] = -2;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Индекс вылетел за пределы массива(((");
            }
            
            try
            {
                int a = 100;
                int b = 0;
                Console.WriteLine(a / b);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Поймал за руку, как дешёвку на делении на нуль!");
            }

            try
            {
                using (StreamReader sr = new StreamReader("Я люблю пельмени")) { }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Такого файла нет, и быть не может!");
            }
            
            try
            {
                string d = null;
                string[] data = d.Split();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Подана пустая строка, она не может быть null");
            }
            
            try
            {
                using (StreamReader sr = new StreamReader(".txt"))
                {
                    using (StreamWriter sw = new StreamWriter(".txt"))
                    {
                    }
                }
            }
            catch(IOException)
            {
                Console.WriteLine("Невозможно использовать файл, когда он используется другим процессом.");
            }
            
            try
            {
                int[] arr = new int[1];
                arr[0] = int.Parse("Ауф");
            }
            catch (FormatException)
            {
                Console.WriteLine("Невозможно преобразовать к числу!");
            }
            
            try
            {
                Console.WriteLine("-".Substring(330));
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Пытаемся получить строку большего размера из строки меньшего!");
            }
            
            try
            {
                object t = "Пельмень";
                int x = (int)t;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Неверное приведение типов!!!");
            }
            
            try
            {
                StringBuilder stringBuilder = new StringBuilder(15, 15);
                stringBuilder.Append("ваввававаавав");
                stringBuilder.Insert(0, "аваавваввава ", 1);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Слишком много памяти...");
            }
            
            try
            {
                string op = null;
                Console.WriteLine("в".IndexOf(op));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Аргумент не должен быть Null!!!!");
            }
        }
    }
}