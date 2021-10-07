using System;
using static System.Globalization.NumberStyles;

namespace Task021
{
    class Program
    {
        private static string ConvertHex2Bin(string hexString)
        {
            int value = int.Parse(hexString, HexNumber);
            return Convert.ToString(value, 2);
        }
        
        static void Main()
        {
            Console.WriteLine($"{ConvertHex2Bin("AF7")} {ConvertHex2Bin("A1")} {ConvertHex2Bin("44")}");
        }
    }
}