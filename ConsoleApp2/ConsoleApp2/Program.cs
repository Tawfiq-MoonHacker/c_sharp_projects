using System;

namespace ConsoleApp2
{
    class Program
    {
        public static double multiplication(double x ,double y)
        {
            return x * y;
        }
        public static double division(double x,double y)
        {
            try
            {
                return x / y;
            }
            catch(Exception e)
            {
                return -1;
            }
        }
        public static double addition(double x,double y)
        {
            return x + y;
        }
        public static double substraction(double x,double y)
        {
            return x - y;
        }
        static void Main(string[] args)
        {
            int Redoing;
            do
            {
                Console.WriteLine("enter two numbers for doing arithmetic operation: ");
                try
                {
                    double x = Convert.ToDouble(Console.ReadLine());
                    double y = Convert.ToDouble(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("please don't enter a null value or other data types");
                    double x = Convert.ToDouble(Console.ReadLine());
                    double y = Convert.ToDouble(Console.ReadLine());
                }

                Console.WriteLine("what operation do you want:");
                Console.WriteLine("1. addition" + "\n" + "2.substraction" + "\n" + "3.multiplication" + "\n" + "4.division");
                int operation = Int16.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        Console.WriteLine(addition(x, y));
                        break;
                    case 2:
                        Console.WriteLine(substraction(x, y));
                        break;
                    case 3:
                        Console.WriteLine(multiplication(x, y));
                        break;
                    case 4:
                        Console.WriteLine(division(x, y));
                        break;
                }
                Console.WriteLine("press 1 to redo an arthemetic operation or press 0 to exit");
                Redoing = Int16.Parse(Console.ReadLine());
                if (Redoing == 0)
                {
                    Console.WriteLine("the program ended");
                    break;
                }
            }while (Redoing == 1) ;


        }
    }
}
