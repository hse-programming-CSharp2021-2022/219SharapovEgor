using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace CW_11
{
    class Program
    {
        public static void Print(int[] data)
        {
            Array.ForEach(data, i => Console.Write($"{i} "));
        }
        static void Main(string[] args) {
            string path = @"Data.txt";

            // Создаем файл с данными
            if (File.Exists(path)) {
                // Сейчас данные для записи вбиты в коде
                Console.Write("Сколько строк записать в файл: ");
                int n = int.Parse(Console.ReadLine());
                Random rnd = new Random();
                string createText = "";
                
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        createText += $"{rnd.Next(1, 101)} ";
                    }

                    createText += "\n";

                }
                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // Open the file to read from
            if (File.Exists(path)) {
                string readText = File.ReadAllText(path);
                string[] stringValues = readText.Split(' ');
                int[] arr = StringArrayToIntArray(stringValues);
                foreach(int i in arr) {
                    Console.Write(i + " ");
                }

                int[] a = new int[arr.Length];
                int[] b = new int[arr.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0) a[i] = i;
                    else
                    {
                        b[i] = i;
                        arr[i] = 0;
                    }
                }
                int[]aNew = a.Where(s => s != 0).ToArray();
                int[]bNew = b.Where(s => s != 0).ToArray();
                
                Print(arr);
                Print(aNew);
                Print(bNew);
            }
        } // end of Main()
        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str) {
            int[] arr = null;
            if (str.Length != 0) {
                arr = new int[0];
                foreach (string s in str) {
                    int tmp;
                    if (int.TryParse(s, out tmp)) {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }
            return arr;
        } // end of StringToIntArray()
    }
}