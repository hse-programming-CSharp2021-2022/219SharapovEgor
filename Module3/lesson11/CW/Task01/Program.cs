using System;
using System.IO;
using System.Text;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("1.txt"))
            {
                using (FileStream data = new FileStream("1.txt", FileMode.Open))
                {
                    byte[] b = new byte[1024];
                    data.Read(b, (int)data.Length-1, (int)data.Length);
                    
                    char fo = (char)((Convert.ToChar(b[0]))+1);
                    byte[] info = new UTF8Encoding(true).GetBytes("\n"+fo);
                    
                    data.Write(info, 0, info.Length);
                }
            }
            else
            {
                using (FileStream data = new FileStream("1.txt", FileMode.Create))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("A");
                    data.Write(info, 0, info.Length);
                }
            }

        }
    }
}