using System;
using System.Collections.Generic;

namespace Account
{
    public class Bank
    {
        private List<Account> _accounts = new List<Account>();
        public Bank()
        {
        }

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

        public void ExecuteTransaction(WithdrawTransaction transaction)
        {
            transaction.Execute();
        }

        public void ExecuteTransaction(DepositTransaction transaction)
        {
            transaction.Execute();
        }

        public void ExecuteTransaction(TransferTransaction transaction)
        {
            transaction.Execute();
        }
    }
}
