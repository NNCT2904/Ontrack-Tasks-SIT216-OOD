using System;
namespace ZooPark
{
    public class Animals
    {
        private string name, diet, location, colour;
        private double weight;
        private int age;

        public Animals(string name, string diet, string location, double weight, int age, string colour)
        {
            this.name =     name;
            this.diet =     diet;
            this.location = location;
            this.weight =   weight;
            this.age =      age;
            this.colour =   colour;
        }

        public virtual void Eat()
        {
            Console.WriteLine("Animal yeet");
        }

        public virtual void Sleep()
        {
            //Code for sleep
        }

        public virtual void MakeNoise()
        {
            Console.WriteLine("Animal scream");
        }

        public virtual void PlayVideoGame()
        {
            Console.WriteLine("Animal Crossing");
        }
    }
}
