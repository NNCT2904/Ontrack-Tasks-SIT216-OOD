using System;
using System.Collections.Generic;

namespace polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bird> birds = new List<Bird>();

            Bird bird1 = new Bird();
            Bird bird2 = new Bird();
            Penguin penguin1 = new Penguin();
            Penguin penguin2 = new Penguin();
            Duck duck1 = new Duck();
            Duck duck2 = new Duck();

            bird1.name = "Feathers";
            bird2.name = "Polly";
            penguin1.name = "Happy Feet";
            penguin2.name = "Gloria";
            duck1.name = "Daffy";
            duck2.name = "Donald";

            duck1.size = 15;
            duck2.size = 20;

            duck1.kind = "Mallard";
            duck2.kind = "Decoy";

            birds.Add(bird1);
            birds.Add(bird2);
            birds.Add(penguin1);
            birds.Add(penguin2);
            birds.Add(duck1);
            birds.Add(duck2);
            birds.Add(new Bird { name = "Special Bird" });

            foreach(Bird bird in birds)
            {
                Console.WriteLine(bird);
            }

            

            Console.ReadKey();
        }
    }
}
