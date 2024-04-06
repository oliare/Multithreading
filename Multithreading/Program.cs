using System;
using System.Threading;

namespace Multithreading
{
    internal class Program
    {
        class Configuator
        {
            public string Name { get; set; }
            public int Number { get; set; }
            public int Delay { get; set; }
        }
        static void Main(string[] args)
        {
            Thread a = new Thread(() => Fibonacci(new Configuator { Name = "Fibonacci", Number = 15, Delay = 50 }));
            Thread b = new Thread(() => Factorial(new Configuator { Name = "Factorial", Number = 10, Delay = 50 }));
            Thread c = new Thread(() => IsPrime(new Configuator { Name = "Prime", Number = 36, Delay = 50 }));

            a.Start();
            b.Start();
            c.Start();
        }

        static void Fibonacci(Configuator conf)
        {
            int a = 0, b = 1;
            for (int i = 0; i < conf.Number; i++)
            {
                Console.WriteLine($"{conf.Name}: {a}");
                int res = a + b;
                a = b;
                b = res;
                Thread.Sleep(conf.Delay);
            }

        }

        static void Factorial(Configuator conf)
        {
            int res = 1;
            for (int i = 2; i <= conf.Number; i++)
            {
                res *= i;
                Console.WriteLine($"{conf.Name} of {i}: {res}");
                Thread.Sleep(conf.Delay);
            }
        }
        static void IsPrime(Configuator conf)
        {
            for (int i = 2; i <= conf.Number; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine($"{conf.Name}: {i} ");
                }
                Thread.Sleep(conf.Delay);
            }
        }
    }
}
