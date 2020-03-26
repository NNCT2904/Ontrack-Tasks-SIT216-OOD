using System;
using System.Collections.Generic;

namespace _3._4
{
    class Program
    {
        
        static void Main(string[] args)
        {

            //Testing
            int[] test = new int[6] { 2, 4, 5, 9, 6, 3 };
            BucketSort(5, test);


        }
        public static void BucketSort(int b, int[] array)
        {
            List<double> result = new List<double>();
            //list inside list
            List<List<double>> buckets = new List<List<double>>();
            double maxKeyValue = 10;

            //Initialize empty buckets from 0 to b
            for (int i = 0; i < b; i++)
            {
                buckets.Add(new List<double>());
            }

            for (int i = 0; i < array.Length; i++)
            {
                buckets[(int)Math.Floor(b * array[i] / maxKeyValue)].Add(array[i]);
            }

            for (int i = 0; i < b; i++)
            {
                buckets[i].Sort();
            }
            //add those sorted items to one final list!
            for (int i = 0; i < b; i++)
            {
                foreach (var item in buckets[i])
                {
                    result.Add(item);
                }
            }

            //if you want to check for each item in the bucket list
            for (int i = 0; i < b; i++)
            {
                foreach (var item in buckets[i])
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }

            result.ForEach(Console.Write);

        }
    }
}
