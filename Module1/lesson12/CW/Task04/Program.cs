using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        int max=0;
        string ans="";
        string input = Console.ReadLine();
        string pattern = @"\d+";
        foreach (Match match in Regex.Matches(input, pattern))
        {
            if (match.Length > max)
            {
                max = match.Length;
                ans = match.Value;
            }
        }
        Console.WriteLine(ans);
    }
}