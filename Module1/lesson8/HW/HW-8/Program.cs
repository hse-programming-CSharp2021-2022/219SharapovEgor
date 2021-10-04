using System;
using static System.Console;

namespace Task01
{
    class Program
    {
        static void PrintMatrix(int[,] matrix)
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine("\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Write("|");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                    {
                        Write("{0,-10:D}", matrix[i, j]);
                    }
                    else
                    {
                        Write("{0,-10:D} ", matrix[i, j]);
                    }
                }
                Write("|");
                WriteLine();
            }
            WriteLine("\n");
            ResetColor();
        }
        
        static void Snake(ref int[,] data, int size, out int control, out int number)
        {
            control = 0;
            number = 1;
            data[size / 2, size / 2] = size * size;
            for (var i = 0; i < size / 2; i++)
            {
                for (var j = 0; j < size - control; j++)
                {
                    data[i, i + j] = number++;
                }

                for (var j = i + 1; j < size - i; j++)
                {
                    data[j, size - i - 1] = number++;
                }

                for (var j = i + 1; j < size - i; j++)
                {
                    data[size - i - 1, size - j - 1] = number++;
                }

                for (var j = i + 1; j < size - i - 1; j++)
                {
                    data[size - j - 1, i] = number++;
                }

                control += 2;
            }
        }
        
        static void Main(string[] args)
        {
            Write("Введите размер матрицы: ");
            int size = Convert.ToInt32(ReadLine());
            int[,] data = new int[size, size];
            Snake(ref data, size, out _, out _);
            PrintMatrix(data);
        }
        
    }
}