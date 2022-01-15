using System;
using System.Collections.Generic;

namespace Task02
{
    public delegate double DelegateConvertTemperature(double x);

    class TemperatureConverterlmp
    {
        public double CtoF(double temperature) => (double) 9 / 5 * temperature + 32;
        public double FtoC(double temperature) => (double) 5 / 9 * (temperature - 32);
    }

    class StaticTempConverters
    {
        public static double CtoK(double temperature) => temperature + 273.15;
        public static double KtoC(double temperature) =>  temperature - 273.15;

        public static double CtoR(double temperature) => (temperature + 273.15) * (double) 9/5;
        public static double RtoC(double temperature) => (temperature - 491.67) * (double) 5/9;

        public static double CtoRé(double temperature) => temperature * (double) 4 / 5;
        public static double RétoC(double temperature) => temperature * (double) 5 / 4;
        
    }
    
    class Program
    {
        
        static void Main(string[] args)
        {
            DelegateConvertTemperature Del1 = new TemperatureConverterlmp().CtoF;
            DelegateConvertTemperature Del2 = new TemperatureConverterlmp().FtoC;

            Console.WriteLine($"Delegate 1: {Del1(123.21)}\nDelegate 2: {Del2(76.92)}");

            List<DelegateConvertTemperature> delegateConvertTemperatures = new List<DelegateConvertTemperature>();
            
            delegateConvertTemperatures.Add(Del1);
            delegateConvertTemperatures.Add(Del2);

            delegateConvertTemperatures.Add(StaticTempConverters.CtoK);
            delegateConvertTemperatures.Add(StaticTempConverters.CtoR);
            delegateConvertTemperatures.Add(StaticTempConverters.CtoRé);

            string x;
            double data;
            Console.WriteLine("Введите значение температуры в градусах Цельсия:");
            x = Console.ReadLine();
            data = double.Parse(x);
            Console.WriteLine("|F|\t|K|\t|R|\t|Ré|\n" +
                              $"{delegateConvertTemperatures[0].Invoke(data)}\t" +
                              $"{delegateConvertTemperatures[2].Invoke(data)}" +
                              $"\t{delegateConvertTemperatures[3].Invoke(data)}\t" +
                              $"{delegateConvertTemperatures[4].Invoke(data)}");

        }
    }
}