﻿using System;

namespace _1._1
{
    class IfStatement
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a number (int)");
            int number = 0;


            //Error handling
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                
                    Console.WriteLine("That's not quite a number. \n\n{0}",e);
                
                }


            if (number == 1)
            {
                Console.WriteLine("One");
            }
            else if (number == 2)
            {
                Console.WriteLine("Two");
            }
            else if (number == 3)
            {
                Console.WriteLine("Three");
            }
            else if (number == 4)
            {
                Console.WriteLine("Four");
            }
            else if (number == 5)
            {
                Console.WriteLine("Five");
            }
            else if (number == 6)
            {
                Console.WriteLine("Six");
            }
            else if (number == 7)
            {
                Console.WriteLine("Seven");
            }
            else if (number == 8)
            {
                Console.WriteLine("Eight");
            }
            else if (number == 9)
            {
                Console.WriteLine("Nine");
            }


        }
    }
}
