using System;

namespace GuessingNumber
{
    class GuessingNumber
    {
        static void Main(string[] args)
        {
            //USER 1's PART


            //Input the number, "var" because user can input some random unexpected character.
            Console.WriteLine("User 1, input a random number in range 1 and 10!");
            var InputNumberAsString = Console.ReadLine();
            
            int InputNumber;


            //input validation, will repeat if user type anything but number, or the number is out of 1 to 10 range
            while (!int.TryParse(InputNumberAsString, out InputNumber) | InputNumber > 10 | InputNumber < 1)
            {
                if (!int.TryParse(InputNumberAsString, out InputNumber))
                    Console.WriteLine("This is not quite a number");
                else if (InputNumber > 10)
                    Console.WriteLine("This number is too large, try 10 or lower!");
                else if (InputNumber < 1)
                    Console.WriteLine("This number is too small, try 1 or higher!");
                
                InputNumberAsString = Console.ReadLine();
            }
            
            //Keep the number secret
            Console.Clear();            

            //USER 2's PART


            Console.WriteLine("User 2, try to guess the number, from 1 to 10");
            var InputGuessNumberAsString = Console.ReadLine();

            int InputGuessNumber;

            //validate user input will repeat if the user got the wrong number, or anything that is not a number
            while (!int.TryParse(InputGuessNumberAsString, out InputGuessNumber) | InputGuessNumber > InputNumber | InputGuessNumber < InputNumber)
            {
                if (!int.TryParse(InputGuessNumberAsString, out InputGuessNumber))
                    Console.WriteLine("This is not quite a number");
                else if (InputGuessNumber > 10 | InputGuessNumber <1)
                    Console.WriteLine("That number is out of range");
                else if (InputGuessNumber > InputNumber)
                    Console.WriteLine("The number is smaller");
                else if (InputGuessNumber < InputNumber)
                    Console.WriteLine("The number is larger");

                               InputGuessNumberAsString = Console.ReadLine();
            }

            Console.Clear();

            //when the user is correct, print "you are correct" message
            Console.WriteLine("You are correct!");


        }
    }
}
