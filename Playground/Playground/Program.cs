using System;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static bool check(decimal value)
        {
            bool check;
            if (value > 0)
            {
                check = true;
            }
            else
            {
                check = false;
            }

            return check;
        }
    }
}
