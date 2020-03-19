using System;

namespace CarProgram
{
    class CarProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Journey assumption!");
            Car Car1 = new Car(15, 300, 12);

            Car1.SetTotalDriven(3);

            Console.WriteLine(
                "You have driven (Miles): " + Car1.GetTotalDriven() +
                "\nFuel Consumed (Gallons): " + Car1.FuelUsed()
                );
            Car1.Drive(Convert.ToDouble(Car1.GetTotalDriven()));

        }
    }
}
