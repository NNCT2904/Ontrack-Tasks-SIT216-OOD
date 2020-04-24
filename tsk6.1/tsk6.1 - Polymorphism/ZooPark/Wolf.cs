using System;
namespace ZooPark
{
    public class Wolf : Animals
    {
        public Wolf(string name, string diet, string location, double weight, int age, string colour)
            : base(name, diet, location, weight, age, colour)
        {
        }

        public override void Eat()
        {
            Console.WriteLine("10lb of meat");
        }

        public override void MakeNoise()
        {
            Console.WriteLine("COOF COOF");
        }

        public override void PlayVideoGame()
        {
            Console.WriteLine("PS4");
        }
    }
}
