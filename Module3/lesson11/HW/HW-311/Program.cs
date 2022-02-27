using System;
using System.IO;

namespace HW_311
{

    /*
    В первом проекте, создать бинарный файл Numbers
    и записать в него средствами класса BinaryWriter 10 целых чисел,
    случайно выбранных из интервала [1;100].Во втором проекте вывести на экран числа
    из файла Numbers, а затем заменять в этом файле на введенное пользователем целое
    значение число, ближайшее по значению к тому, которое ввел пользователь,
    и вновь выводить числа из файла на экран.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            using (BinaryWriter writer = new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                    writer.Write(random.Next(1, 101));
            }

            int[] data = new int[10];

            using (BinaryReader reader = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                {
                    data[i] = reader.ReadInt32();
                    Console.WriteLine(data[i]);
                }
                int n = int.Parse(Console.ReadLine());
                int min = -1, res = -1;
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        res = 0;
                        min = Math.Abs(n - data[i]);
                    }
                    else
                    {
                        min = Math.Min(Math.Abs(n - data[i]), min);
                        res = i;
                    }
                }
                data[res] = n;
            }
            using (BinaryWriter writer = new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                    writer.Write(data[i]);
            }
            using (BinaryReader reader = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                {
                    data[i] = reader.ReadInt32();
                    Console.Write(data[i] + " ");
                }
            }
        }
    }
}
