using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters;

namespace AbstractedTransaction
{
    public class Bank
    {
        private List<Transaction> _transactions = new List<Transaction>();
        private List<Account> _accounts = new List<Account>();
        public Bank()
        {
        }

        public List<Transaction> Transactions { get => this._transactions; }

        public void AddAccount(Account account)
        {
            this._accounts.Add(account);
        }

        public Account Search(string name)
        {
            foreach (var account in this._accounts)
            {
                if (account.Name == name)
                {
                    return account;
                }
            }
            //Return null if can not find any account
            return null;
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            this._transactions.Add(transaction);
        }

        public void RollbackTransaction(Transaction transaction)
        {
            transaction.Rollback();
            this._transactions.Add(transaction);
        }

        public void PrintTransactionHistory()
        {
            for (int i = 0; i< this._transactions.Count; i++)
            {
                Console.WriteLine($"\nIndex {i}:");
                Console.WriteLine($"At {this._transactions[i].DateStamp}");
                Console.WriteLine($"Type: {this._transactions[i].Type}");
                Console.WriteLine("Detail: "); 
                this._transactions[i].Print();

                Console.WriteLine("--------------");
            }
        }
    }
}
