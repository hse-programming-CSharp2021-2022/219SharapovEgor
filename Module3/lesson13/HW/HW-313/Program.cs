using System;
using System.Collections;

namespace HW_313
{

    /*
     * Сделать задание к задаче 3 (стр. 8, презентация 3_07а)
     */

    class Fibbonacci : IEnumerable
    {
        int f0 = 1, f1 = 1;
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; ++i)
            {
                yield return f0;
                int c = f0;
                f0 = f1;
                f1 += c;
            }
        }
        public IEnumerable NameEnumerator(int n)
        {
            int f0 = 1, f1 = 1;
            for (int i = 0; i < n; ++i)
            {
                yield return f0;
                int c = f0;
                f0 = f1;
                f1 += c;
            }
        }
    }
    class TriangleNums : IEnumerable
    {
        int num = 1;
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; ++i)
            {
                yield return num;
                num += i + 2;
            }
        }
        public IEnumerable NameEnumerator(int num)
        {
            for (int i = 0; i < num; ++i)
            {
                yield return this.num;
                this.num += i + 2;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            var fibbonacci = new Fibbonacci();
            var triangleNums = new TriangleNums();
            var dataArray = new int[10];

            var workingIndex = 0;
            foreach (var item in fibbonacci.NameEnumerator(10))
            {
                Console.WriteLine(item);
                dataArray[workingIndex++] = (int)item;
            }

            Console.WriteLine("------------------------");

            workingIndex = 0;
            foreach (var item in triangleNums.NameEnumerator(10))
            {
                Console.WriteLine(item);
                dataArray[workingIndex++] += (int)item;
            }

            Console.WriteLine("------------------------");

            foreach (var item in dataArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
