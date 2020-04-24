using System;
namespace ZooPark
{
    public class Penguin : Bird
    {
        public Penguin(string name, string diet, string location, double weight, int age, string colour, string species, double wingSpan)
            : base(name, diet, location, weight, age, colour, species, wingSpan)
        {
        }
    }
}
