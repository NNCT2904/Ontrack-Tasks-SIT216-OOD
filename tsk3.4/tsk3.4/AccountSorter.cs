using System;
using System.Collections.Generic;

namespace Account
{
    public static class AccountSorter
    {
        public static void Sort(Account[] accounts, int b)
        {
            List<string> result = new List<string>();

            //make list inside list
            List<List<Account>> buckets = new List<List<Account>>();
            decimal maxKeyValue = 100;

            //Make empty buckets from 0 to b
            for (int i = 0; i < b; i++)
            {
                buckets.Add(new List<Account>());
            }

            
            //Put accounts to buckets, based on the available balance
            for (int i = 0; i < b; i++)
            {
                //Console.WriteLine((int)Math.Floor(b * accounts[i].Balance() / maxKeyValue));
                buckets[(int)Math.Floor(b * accounts[i].Balance() / maxKeyValue)].Add(accounts[i]);
            }


            //Sort each buckets
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j< buckets[i].Count; j++)
                {
                    //sort algorithm.
                }
            }

            //Add the sorted to a list

            for (int i = 0; i < b; i++)
            {
                Console.WriteLine("Bucket " + i);
                foreach (var item in buckets[i])
                {
                    Console.Write(item.Name());
                }
                Console.WriteLine();
            }

            for (int i = 0; i<b; i++)
            {              
                foreach (var item in buckets[i])
                {
                    result.Add(item.Name());
                }
            }
            

            //result.ForEach(Console.WriteLine);
        }

        public static void Sort(List<Account> accounts, int b)
        {


        }
    }
}
