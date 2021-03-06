using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"\b[a-zA-Z]{4}\b";
        foreach (Match match in Regex.Matches(input, pattern)) 
        {
            Console.Write($"{match.Value} ");
        }
    }
}