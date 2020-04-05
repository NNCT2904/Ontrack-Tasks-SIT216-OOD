using System;
namespace ZooPark
{
    public class Bird : Animals
    {
        string species;
        double wingSpan;
        public Bird(string name, string diet, string location, double weight, int age, string colour, string species, double wingSpan)
            : base(name, diet, location, weight, age, colour)
        {
            this.species = species;
            this.wingSpan = wingSpan;
        }

        public virtual void LayEggs()
        {
            // Lay codes
            //I mean lay eggs
            Console.WriteLine("Bird lays eggs");
        }

        public virtual void Fly()
        {
            Console.WriteLine("Bird flies");
        }

        public override void Sleep()
        {
            Console.WriteLine("Bird sleeps");
        }
    }
}
