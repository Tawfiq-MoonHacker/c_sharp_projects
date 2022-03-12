using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
           
            int[] list = new int[6];
            Random r = new Random();
            int x;
            for (int i = 0; i < 6000; i++)
            {
                x = r.Next(1, 7);
                ++list[x - 1];
            }
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.ReadLine();

        }
    }
}
