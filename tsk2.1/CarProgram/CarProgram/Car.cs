using System;
using System.Collections.Generic;
using System.Text;

namespace CarProgram
{
    class Car
    {
        private double FuelEfficiency, Fuel = 0, Driven = 0;


        //VARIABLES
        private const double COST_PER_LITRE = 1.38;

        public Car(double FuelEfficiency, double Fuel, double Driven)
        {
            //Miles per Gallon
            this.FuelEfficiency = FuelEfficiency;
            //Fuel in litre
            this.Fuel = Fuel;
            //Distance in Miles
            this.Driven = Driven;
        }

        //Accessor Methods
        public String GetFuelEfficiency()
        {
            return this.FuelEfficiency.ToString();
        }
        public string GetFuel()
        {
            return this.Fuel.ToString();
        }
        public string GetTotalDriven()
        {
            return this.Driven.ToString();
        }
        public string PrintFuelCost()
        {
            return COST_PER_LITRE.ToString("C");
        }

        //Mutator methods
        public void SetTotalDriven(double DrivenInMiles)
        {
            this.Driven += DrivenInMiles;
        }
        public void AddFuel(double FuelInLitre)
        {
            this.Fuel += FuelInLitre;
        }
        

        //Calculations
        public double CalcCost(double Fuel)
        {
            double Cost = Fuel * COST_PER_LITRE;
            return Cost;
        }
        public double ConvertToLitre(double Gallons)
        {
            double Litre = Gallons * 4.546;
            return Litre;
        }
        public double FuelUsed()
        {
            double GallonUsed = this.Driven / this.FuelEfficiency;
            return GallonUsed;
        }

        public void Drive(double Driven)
        {
            SetTotalDriven(Driven);
            double GallonUsed = FuelUsed();
            double LitreUsed = ConvertToLitre(GallonUsed);
            double TotalCost = CalcCost(LitreUsed);

            Console.WriteLine("The total cost is: " + TotalCost.ToString("C"));
        }
    }
}
