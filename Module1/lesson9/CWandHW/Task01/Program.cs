using System;
using System.Text;

namespace CW_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string let = "AEIOUYaeiouy";
            string check = "Let it be; All you need id Love; Dizzy Miss Lizzy";
            StringMonster(check, let);
        }
        
        static void StringMonster(string str, string let)
        {
            StringBuilder sB = new StringBuilder();
            string[] workFlo = str.Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < workFlo.Length; i++)
            {
                workFlo[i].Trim();
                string[] stringWords = workFlo[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < stringWords.Length; j++)
                {
                    string save = stringWords[j].ToUpper();
                    sB.Append(save[0]);
                    save = save.ToLower();
                    for (int k = 1; k < save.Length; k++)
                    {
                        if (let.Contains(save[i]))
                        {
                            sB.Append(save[i]);
                            break;
                        }
                    }
                }
                sB.Append('\n');
            }

            Console.WriteLine(sB.ToString());
        }
    }
}