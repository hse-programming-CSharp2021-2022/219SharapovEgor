using System;

namespace Task02
{
    class Program
    {
            public class ConsolePlate
            {
                char _plateChar; 
                ConsoleColor _plateColor = ConsoleColor.White;
                private ConsoleColor _backColor = ConsoleColor.Black;
                
        
                public ConsolePlate()  
                {
                    _plateChar = 'A';
                }
                public ConsolePlate(char plateChar, ConsoleColor plateColor, ConsoleColor backColor)
                {
                    if (plateColor == backColor)
                    {
                        Console.WriteLine("Cовпадение цветов невозможно!");
                        return;
                    }
                    PlateChar = plateChar;
                    PlateColor = plateColor;
                    BackColor = backColor;
                }
                public char PlateChar
                {
                    set
                    {
                        if (value >= 65 || value <= 90) 
                            _plateChar = value;
                        else
                            _plateChar = 'A';
                    }
                    get { return _plateChar; }
                }
                public ConsoleColor PlateColor
                {
                    set
                    {
                        _plateColor = value;
                    }
                    get
                    {
                        return _plateColor;
                    }
                }
        
                public ConsoleColor BackColor
                {
                    get
                    {
                        return _backColor;
                    }
                    set
                    {
                        _backColor = value;
                    }
                }
        
            }
        static void Main( )
        {
            ConsolePlate firstSymbol = new ConsolePlate('X', ConsoleColor.White, ConsoleColor.Red);
            ConsolePlate secondSymbol = new ConsolePlate('O', ConsoleColor.White, ConsoleColor.Magenta);
            int numWork;
            string data;
            do
            {
                data = Console.ReadLine();
            }while (!int.TryParse(data, out numWork) || numWork < 2 || numWork > 35);
            
            for (int i = 0; i < numWork; i++)
            {
                for (int j = 0; j < numWork; j++)
                {
                    if (i % 2 != 0)
                    {
                        if (j % 2 != 0)
                        {
                            Console.ForegroundColor = firstSymbol.PlateColor;
                            Console.BackgroundColor = firstSymbol.BackColor;
                            Console.Write(firstSymbol.PlateChar);
                        }
                        else if (j % 2 == 0)
                        {
                            Console.ForegroundColor = secondSymbol.PlateColor;
                            Console.BackgroundColor = secondSymbol.BackColor;
                            Console.Write(secondSymbol.PlateChar);
                        }

                    }
                    else if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            Console.ForegroundColor = firstSymbol.PlateColor;
                            Console.BackgroundColor = firstSymbol.BackColor;
                            Console.Write(firstSymbol.PlateChar);
                        }
                        else if (j % 2 != 0)
                        {
                            Console.ForegroundColor = secondSymbol.PlateColor;
                            Console.BackgroundColor = secondSymbol.BackColor;
                            Console.Write(secondSymbol.PlateChar);
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}