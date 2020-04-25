using System;
using System.Collections.Generic;
using System.Text;

namespace polymorphism
{
    class Bird
    {
        public string name { get; set; }

        public Bird()
        {

        }

        public void Fly()
        {
            Console.WriteLine("Fap, Fap, Fap");
        }

        public override string ToString()
        {
            return "A bird called "+name;
        }
    }
}
