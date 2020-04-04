using System;
using System.Collections.Generic;
using System.Linq;

namespace Account
{
    public static class AccountSorter
    {
        public static void Sort(Account[] accounts, int b)
        {
            List<Account> result = new List<Account>();

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
                foreach (var item in buckets[i])
                {
                    result.Add(item);
                }
            }

            //Print the list
            foreach (var item in result)
            {
                Console.WriteLine($"Account name: {item.Name()} \t\t available balance:  {item.Balance.ToString("C")}");
            }
            
        }

        public static void Sort(List<Account> accounts, int b)
        {
            Account[] convertToList = accounts.ToArray();

            Sort(convertToList, b);
        }
    }
}
