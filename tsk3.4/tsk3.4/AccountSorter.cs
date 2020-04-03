using System;
using System.Collections.Generic;
using System.Linq;

namespace Account
{
    public static class AccountSorter
    {
        public static void Sort(Account[] accounts, int b)
        {
            List<string> result = new List<string>();

            //make list inside list
            List<List<Account>> buckets = new List<List<Account>>();
            int maxKeyValue = (int) accounts.Max(x => x.Balance);


            //Make empty buckets from 0 to b
            for (int i = 0; i < b; i++)
            {
                buckets.Add(new List<Account>());
            }


            //Put accounts to buckets, based on the available balance
            for (int i = 0; i < b; i++)
            {
                //Console.WriteLine((int)Math.Floor(b * accounts[i].Balance() / maxKeyValue));
                buckets[(int)Math.Floor(b * accounts[i].Balance / (maxKeyValue+1))].Add(accounts[i]);
            }


            //Sort each buckets
            for (int i = 0; i < b; i++)
            {
                //buckets[i].Sort();
                buckets[i] = buckets[i].OrderBy(x => x.Balance).ToList();
            }

            //Add the sorted to a list

            for (int i = 0; i < b; i++)
            {
                Console.WriteLine("Bucket " + i);
                foreach (var item in buckets[i])
                {
                    Console.WriteLine($"Account name: {item.Name()} \t\t available balance: {item.Balance}");
                }
                Console.WriteLine();
            }

            //for (int i = 0; i<b; i++)
            //{              
            //    foreach (var item in buckets[i])
            //    {
            //        result.Add(item.Name());
            //    }
            //}


            //result.ForEach(Console.WriteLine);
        }

        public static void Sort(List<Account> accounts, int b)
        {


        }
    }
}
