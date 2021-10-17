using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Print(IEnumerable<int> inum)
    {
        foreach (var i in inum)
            Console.Write(i + " ");
        Console.WriteLine();
    }
    
    static void Print(int[] inum)
    {
        foreach (var i in inum)
            Console.Write(i + " ");
        Console.WriteLine();
    }
    
    static void Print(int inum)
    {
        Console.WriteLine($"{inum}\n");
    }
    
    
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int[] arr = new int[size];
        Random rnd = new Random();
        for (int i = 0; i < arr.Length; i++)
            arr[i] = rnd.Next(1, 10001);
        var call1 = from t in arr where t >= 10 && t < 100 && t % 3 == 0 select t;
        var call2 = from t in arr where Polindrome(t) orderby t select t;
        var call3 = arr.OrderBy(t=>DigitSum(t)).ThenBy(t=>t);
        var call4 = arr.Where(t => DigitCount(t)==4).Sum(t=>t);
        var call5 = arr.Where(t => DigitCount(t) == 2).Min(t => t);
        var call6 = from t in arr select DigitMax(t);
        
        Print(arr);
        Print(call1);
        Print(call2);
        Print(call2);
        Print(call3);
        Print(call4);
        Print(call5);
        Print(call6);
    }
    
    static bool Polindrome(int n)
    {
        string s = n.ToString();
        for (int i = 0; i < s.Length / 2; i++)
            if (s[i] != s[s.Length - i - 1])
                return false;
        return true;
    }
    
    static int DigitSum(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }

    static int DigitCount(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count++;
            n /= 10;
        }
        return count;
    }

    static int DigitMax(int n)
    {
        int max = 0;
        while (n > 0)
        {
            if (n % 10 > max) max = n % 10;
            n /= 10;
        }
        return max;
    }
    
}
