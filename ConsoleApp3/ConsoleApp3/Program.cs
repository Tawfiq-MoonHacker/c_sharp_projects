using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string c = "you";
            Console.WriteLine(c.Length);
            string s = c.Substring(0, 2);
            Console.WriteLine(s);
            string c1 = "you";
            Console.WriteLine(string.Concat(c1, s));
            Console.Read();
        }
    }
}
