using System;

namespace HW_6
{
    class Program
    {
        static void Compress(int[] data)
        {
            int k = 0;
            int h = 0;
            for (int i = 0; i < data.Length-h-1; i++)
            {
                if ((data[i] + data[i + 1]) % 3 == 0)
                {
                    data[i] = data[i] * data[i + 1];
                    h += 1;
                    int j = 1;
                    while (i + j < data.Length - 1)
                    {
                        data[i + j] = data[i + j + 1];
                        j += 1;
                    }
                    k += 1;
                }
            }

            for (int i = 0; i < data.Length - h; i++)
            {
                Console.Write(data[i] +" ");
            }
            Console.WriteLine($"\nРазмер массива сокращён на: {h}");

        }

        static void Main(string[] args)
        {
            int[] data = {1, 2, 3, 4, 5, 6, 7, 8};
            Compress(data);
        }

    }

}
    
