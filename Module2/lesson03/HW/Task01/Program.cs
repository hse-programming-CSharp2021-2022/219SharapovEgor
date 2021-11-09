using System;

namespace Task01
{
    class VideoFile
    {
        private string string_name {get;}

        private int int_duration {get;}

        private int int_quality {get;}

        public VideoFile(string name, int duration, int quality)
        {
            string_name = name;
            int_duration = duration;
            int_quality = quality;
        }

        public int Size()
        {
            return int_duration * int_quality;
        }

        public string GetInfo()
        {
            return $"Файл: {string_name}\nРазмер: {Size()}\nКачество: {int_quality}\nДлительность: {int_duration}\n";
        }


    }
    class Program
    {
        static void Main()
        {
            do
            {
                var rnd = new Random();
                var mainVideoFile = new VideoFile("main", rnd.Next(60, 361), rnd.Next(100, 1001));
                var array = new VideoFile[rnd.Next(5, 16)];
                for (int i = 0; i < array.Length; i++)
                {
                    int duration = rnd.Next(60, 361);
                    int qualityFile = rnd.Next(100, 1001);
                    string nameFile = "";
                    for (int j = 1; j < rnd.Next(3, 10); j++) nameFile += (char)rnd.Next('a', 'z');
                    array[i] = new VideoFile(nameFile, duration, qualityFile);
                }
                for (int i = 0; i < array.Length; i++) 
                    if (array[i].Size() > mainVideoFile.Size())
                        Console.WriteLine($"{array[i].GetInfo()}");
                Console.WriteLine("Нажмите ESC, чтобы выйти!");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}