using System;

namespace DoCasting
{
    class DoCasting
    {
        static void Main(string[] args)
        {
            int sum = 17;
            int count = 5;
            int IntAverage = sum / count;

            Console.WriteLine(IntAverage);              //The result is 3, which is wrong
            /*
            double DoubleAverage = sum / count;
            Console.WriteLine(DoubleAverage);           //Build error 
            */

            double DoubleAverage = (double)sum / count;
            Console.WriteLine(DoubleAverage);           //The result is 3.4, correct
        }
    }
}
