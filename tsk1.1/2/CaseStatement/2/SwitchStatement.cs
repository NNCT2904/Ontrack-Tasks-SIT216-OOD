using System;

namespace _2
{
    class SwitchStatement
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number (int): ");
            int number=0;



            //Error handling
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("that's not quite a number. \n\n{0}", e);
            }

            switch (number)
            {
                case 1: Console.WriteLine("One"); break;
                case 2: Console.WriteLine("Two"); break;
                case 3: Console.WriteLine("Three"); break;
                case 4: Console.WriteLine("Four"); break;
                case 5: Console.WriteLine("Five"); break;
                case 6: Console.WriteLine("Six"); break;
                case 7: Console.WriteLine("Seven"); break;
                case 8: Console.WriteLine("Eight"); break;
                case 9: Console.WriteLine("Nine"); break;
                default: Console.WriteLine("Error, you may only enter an integer from 1 to 9."); break;

            }

            Console.ReadLine();





        }
    }
}

