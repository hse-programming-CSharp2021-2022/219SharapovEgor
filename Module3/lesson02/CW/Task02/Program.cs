using System;
using System.Text.RegularExpressions;

namespace Task02
{
    public delegate string ConvertRule(string str);

    class Program
    {

        public static string RemoveDigits(string str)
        {
            return Regex.Replace(str, "[0-9]", "", RegexOptions.IgnoreCase);
        }

        public static string RemoveSpaces(string str)
        {
            return str.Replace(" ", "");
        }
        
        static void Main(string[] args)
        {
            string[] data = new[] {"ssss12_21", "111    23 siera"};

            ConvertRule Ans = RemoveDigits;
            Ans += RemoveSpaces;

            for (int i = 0; i < data.Length; i++)
            {
                foreach (ConvertRule a in Ans.GetInvocationList())
                {
                    Console.WriteLine(a(data[i]));
                }
            }

        }
    }
}