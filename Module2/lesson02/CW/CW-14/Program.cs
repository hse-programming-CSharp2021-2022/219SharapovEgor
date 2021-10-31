using System;

namespace CW_14
{
    class MyComplex    {
        
        private double _re, _im;
        public double Real
        {
            get
            {
                return _re;
            }
            set
            {
                _re = value;
            }
            
        }
        public double Imagine
        {
            get
            {
                return _im;
            }
            set
            {
                _im = value;
            }
            
        }

        public MyComplex(double xre = 0f, double xim = 0f)
        {
            Real = xre; Imagine = xim;
        }

        public static MyComplex operator ++(MyComplex mc)
        {
            return new MyComplex(mc.Real++, mc.Imagine++);
        }
        
        public static MyComplex operator --(MyComplex mc)
        {
            return new MyComplex(mc.Real-1, mc.Imagine-1);
        }

        public double Mod()
        {
            return Math.Abs(_re*_re+_im*_im);
        }
        
        static public bool operator true(MyComplex f)  
        {
            if (f.Mod() > 1.0) return true;
            return false;
        }
        
        static public bool operator false(MyComplex f)  
        {
            if (f.Mod() <= 1.0) return true;
            return false;
        } 
        
        static public MyComplex operator +(MyComplex a, MyComplex b)  
        {
            return new MyComplex(a.Real+b.Real, a.Imagine + b.Imagine);
        } 
        
        static public MyComplex operator -(MyComplex a, MyComplex b)  
        {
            return new MyComplex(a.Real-b.Real, a.Imagine - b.Imagine);
        } 
        
        static public MyComplex operator *(MyComplex a, MyComplex b)  
        {
            return new MyComplex(a.Real*b.Real - a.Imagine - b.Imagine, a.Imagine * b.Real + a.Real*b.Imagine);
        } 
        
        static public MyComplex operator /(MyComplex a, MyComplex b)  
        {
            return new MyComplex((a.Real*b.Real + a.Imagine*b.Imagine)/(b.Real*b.Real+b.Imagine*b.Imagine),
                (a.Imagine*b.Real + a.Real*b.Imagine)/(b.Real*b.Real+b.Imagine*b.Imagine));
        } 
        
        public override string ToString()
        {
            return $"{Real} + {Imagine}i";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var q = new MyComplex(1f, 2f);
            var c = new MyComplex(3f, 4f);
            Console.WriteLine(q + c);
            Console.WriteLine(q - c);
            Console.WriteLine(q * c);
            Console.WriteLine(q / c);
        }
    }
}
