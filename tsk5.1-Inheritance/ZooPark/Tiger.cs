using System;
namespace ZooPark
{
    public class Tiger : Animals
    {
        private string species, colourStripes;
        public Tiger(string name, string diet, string location, double weight, int age, string colour, string species, string colourStripes)
            : base(name, diet, location, weight, age, colour)
        {
            this.species = species;
            this.colourStripes = colourStripes;
        }

        public override void Eat()
        {
            Console.WriteLine("Chicken fried for tonight, 20lb should be fine");
        }

        public override void MakeNoise()
        {
            Console.WriteLine("REEEEEEE");
        }
    }
}
