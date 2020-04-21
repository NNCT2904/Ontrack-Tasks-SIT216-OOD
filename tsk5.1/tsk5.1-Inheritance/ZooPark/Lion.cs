using System;
namespace ZooPark
{
    public class Lion : Feline
    {
        public Lion(string name, string diet, string location, double weight, int age, string colour, string species)
            : base(name, diet, location, weight, age, colour, species)
        {
            
        }

        public override void MakeNoise()
        {
            Console.WriteLine("ROaR");
        }
    }
}
