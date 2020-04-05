using System;
namespace ZooPark
{
    public class Eagle : Animals
    {
        string species;
        double wingSpan;

        public Eagle(string name, string diet, string location, double weight, int age, string colour, string species, double wingSpan)
            : base(name, diet, location, weight, age, colour)
        {
            this.species = species;
            this.wingSpan = wingSpan;
        }

        public void LayEgg()
        {
            //Lay codes
        }

        public void Fly()
        {
            //Code to fly
        }

        public override void Eat()
        {
            Console.WriteLine("1lb of meat");
        }

        public override void MakeNoise()
        {
            Console.WriteLine("KEK");
        }

        public override void PlayVideoGame()
        {
            Console.WriteLine("Nintendo Switch");
        }
    }
}
