using System;
using System.Threading;

namespace Task01
{
    class BankAccount
    {
        private object thisLock = new object();
        volatile int _accountAmount;
        readonly Random rnd = new Random();
        
        public BankAccount(int sum)
        {
            _accountAmount = sum;
        }

        private int Buy(int sum)
        {
            switch (_accountAmount)
            {
                case < 0:
                    throw new InvalidOperationException($"Ошибка. Отрицательный баланс(");
                case 0:
                    throw new InvalidOperationException($"Ошибка. Баланс равен нулю!");
            }
            
            var l = false;
            Monitor.Enter(thisLock, ref l);
            if (_accountAmount >= sum)
            {
                Console.WriteLine($"Счет: {_accountAmount}");
                Console.WriteLine($"Сумма покупки: {sum}");
                
                _accountAmount -= sum;
                
                Console.WriteLine($"После: {_accountAmount}");
                
                return sum;
            }
            else
            {
                return 0;
            }
        }
        
        public void DoTransactions()
        {
            try
            {
                while (true)
                {
                    Buy(rnd.Next(1, 50));
                    Thread.Sleep(rnd.Next(1, 10));
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}.");
            }
        }
    }

    static class Program
    {
        private static void Main()
        {
            var threads = new Thread[10];
            var dep = new BankAccount(1000);
            
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(dep.DoTransactions);
            }
            
            foreach (var thread in threads)
            {
                thread.Start();
            }
        }
    }
}