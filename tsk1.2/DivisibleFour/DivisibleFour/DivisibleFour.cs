using System;

namespace DivisibleFour
{
    class DivisibleFour
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a number ");
            string InputNumberAsString = Console.ReadLine();

            int InputNumber = InputValidation(InputNumberAsString);


            if (InputNumber == 1)
            {
                Console.WriteLine("None");
            }
            else if (InputNumber > 1)
            {

                for (int i = 1; i <= InputNumber; i++)
                {
                    //Numbers that are divisible by 4 and not by 5
                    PrintNumber(i);
                }
            }
            else if (InputNumber < 1)
            {

                for (int i = 1; i >= InputNumber; i--)
                {
                    //Numbers that are divisible by 4 and not by 5
                    PrintNumber(i);
                }
            }
            

        }
        //This function print the number that is divisible by 4 but not by 5
        public static void PrintNumber(int i)
        {
            if (i % 4 == 0 && !(i % 5 == 0))
            {
                Console.WriteLine(i);
            }
        }
        //This function validate input, will repeat if user type anything other than number
        public static int InputValidation(string InputNumberAsString)
        {
            int InputNumber;

            while (!int.TryParse(InputNumberAsString, out InputNumber))
            {
                if (!int.TryParse(InputNumberAsString, out InputNumber))
                    Console.WriteLine("This is not quite a number, try again");
                InputNumberAsString = Console.ReadLine();
            };

            return InputNumber;
        }
    }
}
