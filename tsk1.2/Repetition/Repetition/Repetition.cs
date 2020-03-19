using System;

namespace Repetition
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            //First task!
            int sum = 0;
            double average;
            int upperbound = 100;

            

            //This loop compleate the sum
            for (int number = 1; number <= upperbound; number++)
            {
                sum += number;
            }

            average = (double)sum / upperbound;                     //(double) because there is something to do with double data type
                                                                    //The upperbound is also the total of number


            Console.WriteLine("The total is: {0}",sum);

            Console.WriteLine("The average of numbers: {0}",average);
            */


            /*
            
            //Second task!

            int sum = 0;
            double average;
            int upperbound = 100;
            int number = 1;

            while (number <= upperbound)
            {
                sum += number;
                number++;

                Console.WriteLine("Current number: " + number + "Current sum: " + sum);

                 //The different between for and while loop is you can declare a local initializer for the "for" loop
                 //while you have to declare variable outside the while loop to make it work
                   
                 //for (initializer; condition; update expression)
                 //{
                 //    statements;
                 //}
                 
                 //initializer
                 //while (loop condition)
                 //{
                 //    statements;
                 //    update expression;
                 //}
                 
                 
            }

            average = (double)sum / upperbound; 
            Console.WriteLine("The total is: {0}",sum);
            Console.WriteLine("The average of numbers: {0}",average);
            */


            //Third one!

            int sum = 0;
            double average;
            int upperbound = 100;
            int number = 1;

            do
            {
                sum += number;
                number++;

            } while (number <= 100);


            average = (double)sum / upperbound;
            Console.WriteLine("The total is: {0}", sum);
            Console.WriteLine("The average of numbers: {0}", average);


            /*
             * "For" loop provide an abstract way to create a loop, the statement consumes 
             * initialization, condition and update expression. The condition is checked,
             * then execute the statements, might be execute zero time if the condition is 
             * not met.
             * 
             * the "while" check the conditions first, then execute the statements.
             * 
             * "do while" loop check the condition after executing the statement,
             * therefore the statements are execute at least once, whether the condition is met
             * or not.
             * 
             */
        }
    }
}
