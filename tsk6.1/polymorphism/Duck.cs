using System;
using System.Collections.Generic;
using System.Text;

namespace polymorphism
{
    class Duck : Bird
    {
        public double size { set; get; }
        public string kind { set; get; }

        public override string ToString()
        {
            return $"A duck name {base.name} is a {size} inch {kind}";
        }
    }
}
