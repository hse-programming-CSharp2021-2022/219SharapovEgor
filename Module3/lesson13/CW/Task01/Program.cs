using System;
using System.Collections;
using System.Collections.Generic;

namespace Task01
{
    class Fibbonacci
    {
        private int _lastElement = 1;
        private int _beforeLastElement;

        public IEnumerable NextMember(int endPosition)
        {
            var member = new List<object>();
            for (var i = 0; i < endPosition; i++)
            {
                var value = _lastElement + _beforeLastElement;
                _lastElement = _beforeLastElement;
                _beforeLastElement = value;
                member.Add(value);
            }

            return member;
        }
    }

    static class Program
    {
        private static void Main(string[] args)
        {
            foreach (var number in (new Fibbonacci()).NextMember(15))
            {
                Console.WriteLine(number);
            }
        }
    }
}