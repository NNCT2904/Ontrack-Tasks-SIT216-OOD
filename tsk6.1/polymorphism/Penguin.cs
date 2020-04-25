using System;
using System.Collections.Generic;
using System.Text;

namespace polymorphism
{
    class Penguin : Bird
    {
        public double size { get; set; }
        public string kind { get; set; }

        public override string ToString()
        {
            return $"A penguin name {base.name} is a {size} inch {kind}";
        }
    }
}
