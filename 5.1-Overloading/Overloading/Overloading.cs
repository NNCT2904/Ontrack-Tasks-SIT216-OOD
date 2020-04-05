using System;

namespace Overloading
{
    class Overloading
    {
        static void Main(string[] args)
        {
            MethodToBeOverloaded("Thanh Nguyen");
            MethodToBeOverloaded("Thanh Nguyen", 20);
        }

        public static void MethodToBeOverloaded(string name)
        {
            Console.WriteLine($"Name: {name}");
        }

        public static void MethodToBeOverloaded(string name, int age)
        {
            Console.WriteLine($"Name: {name}\nAge: {age}");
        }
    }
}
