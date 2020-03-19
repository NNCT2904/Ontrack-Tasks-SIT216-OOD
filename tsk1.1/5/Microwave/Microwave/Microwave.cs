using System;


namespace Microwave
{
    class Microwave
    {
 
        static void Main(string[] args)
        {
            int NumberOfItem;
            int TimePerItem;
            int RecommenedCookTime = 0;

            do              //Check the number of item in the microway, must be 1, 2 or 3, otherwise repeat
            {
                Console.WriteLine("How many item are there?");
                NumberOfItem = Convert.ToInt32(Console.ReadLine());


                if (NumberOfItem < 0)
                    Console.WriteLine("How can you even cook minus?");
                else if (NumberOfItem == 0)
                    Console.WriteLine("You cook nothing ? Gordon Ramsay will be angry, try again!");
                else if (NumberOfItem == 1)
                    Console.WriteLine("One item in the microwave");
                else if (NumberOfItem == 2)
                    Console.WriteLine("Two items in the microwave");
                else if (NumberOfItem == 3)
                    Console.WriteLine("Three items in the microwave");
                else if (NumberOfItem > 3)
                    Console.WriteLine("More than three items in Microwave is not recommened, please try again");



            } while (NumberOfItem > 3 | NumberOfItem <= 0);

                        //How long will ONE item be cooked?
            Console.WriteLine("How long will you cook 1 item? (in second)");
            TimePerItem = Convert.ToInt32(Console.ReadLine());


                        //Calculations 
                        //1 item => cook as one item
                        //2 item => 1.5 * time
                        //3 item => 2 * time
            if (NumberOfItem == 1)
                RecommenedCookTime = Convert.ToInt32(TimePerItem);
            if (NumberOfItem == 2)
                RecommenedCookTime = Convert.ToInt32((int)Math.Round(TimePerItem * 1.5));
            if (NumberOfItem == 3)
                RecommenedCookTime = Convert.ToInt32( TimePerItem * 2);
                        
                        //Print the recommened cooking time
            Console.WriteLine("The recommended cook time is {0} seconds!", RecommenedCookTime);

        }


    }
}
