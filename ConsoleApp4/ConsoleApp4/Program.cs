using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s = "hello there";
            string [] p = s.Split(' ');
            int charcount = 0;
            Console.WriteLine("CHAR count: " + s.Length);
            Console.WriteLine("Counting words" + (p.Length-1));


            Console.Read();

        }
    }
}
