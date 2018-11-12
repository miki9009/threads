
using System;
using System.Threading;

class Program
{
    static readonly object _object = new object();
    static int val = 0;
    static void A()
    {
        lock (_object)
        {
            val += 10;
            Thread.Sleep(1000);
        }
    }

    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            new Thread(A).Start();
        }
        new Thread(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("Wartość val: " + val);
        }).Start();
        Console.ReadKey();
    }
}