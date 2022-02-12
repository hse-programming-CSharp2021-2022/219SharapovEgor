
using System;

class Stack<T>
{
    T value;
    Stack<T> pred;
    public int Size { get; set; }
    public bool IsEmpty { get; set; }
    public Stack(T value, Stack<T> pred)
    {
        this.value = value;
        this.pred = pred;
        IsEmpty = false;
        if(pred != null)
            Size = pred.Size + 1;
        else
            Size = 1;
    }
    public Stack()
    {
        IsEmpty = true;
    }
    public Stack<T> Push(T newValue)
    {
        return new Stack<T>(newValue, this);
    }
    public T Pop()
    {
        if (IsEmpty)
        {
            throw new ArgumentException();
        }
        T ans = value;
        value = pred.value;
        if (pred != null)
            pred = pred.pred;
        else
            IsEmpty = false;
        return ans;
    }
    public T Top()
    {
        return value;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var data = new Stack<int>();
        
        data.Push(10);
        data.Push(9);
        data.Push(8);
        
        Console.WriteLine(data.Top());
        Console.WriteLine(data.Pop());
        Console.WriteLine(data.Top());
    }
}