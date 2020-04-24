using System;
namespace ZooPark
{
    public class Eagle : Bird
    {
        string species;

        public Eagle(string name, string diet, string location, double weight, int age, string colour, string species, double wingSpan)
            : base(name, diet, location, weight, age, colour, species, wingSpan)
        {
            this.species = species;
        }

        public override void LayEggs()
        {
            Console.WriteLine("Eagle lays eggs");
        }

        public override void Fly()
        {
            Console.WriteLine("Eagle Flies");
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
