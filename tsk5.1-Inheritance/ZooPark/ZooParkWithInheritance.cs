using System;

namespace ZooPark
{
    class ZooPark
    {
        static void Main(string[] args)
        {

            Animals baseAnimal = new Animals("Animal Name", "Animal Diet", "Animal Location", 0.0, 0, "Animal Color");
            Animals williamWolf = new Wolf("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            //Animals tonyTiger = new Animals("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White");
            Animals edgarEagle = new Eagle("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black", "Harpy", 98.5);

            Animals tiniTiger = new Tiger("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White", "Siberian", "White");

            tiniTiger.MakeNoise();
            williamWolf.MakeNoise();
            edgarEagle.MakeNoise();
        }
    }
}
