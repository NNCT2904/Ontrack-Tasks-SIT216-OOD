﻿using System;
namespace ZooPark
{
    public class Tiger : Feline
    {
        private string  colourStripes;
        public Tiger(string name, string diet, string location, double weight, int age, string colour, string species, string colourStripes)
            : base(name, diet, location, weight, age, colour, species)
        {
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

        public override void PlayVideoGame()
        {
            Console.WriteLine("PC MASTERRACE");
        }
    }
}
