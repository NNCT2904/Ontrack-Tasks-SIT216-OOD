﻿using System;

namespace Account
{
    public class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed, _success, _reversed;

        public WithdrawTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public bool Executed { get => this._executed; }
        public bool Success { get => this._success; }
        public bool Reversed { get => this._reversed; }

        public void Print()
        {
            Console.WriteLine($"Account name: {this._account.Name}");
            Console.WriteLine($"Amount to withdraw: {this._amount.ToString("C")}");
            Console.Write("Status: ");
            if (this._success == true)
            {
                Console.WriteLine("Sucess!");
            }
            else if (this._success == false)
            {
                Console.WriteLine("Abort");
            }
            
            Console.WriteLine($"Available fund: {this._account.Balance.ToString("C")}\n");
        }

        public void Execute()
        {
            if (this._executed == true)
            {
                throw new InvalidOperationException("The transactrion has already been attempted");
            }
            else if (this._account.Balance < this._amount)
            {
                this._executed = false;
                throw new InvalidOperationException("Insufficient fund!");
            }
            else if (this._executed == false  && this._account.Balance >= this._amount)
            {
                this._success = this._account.Withdraw(_amount);
                this._executed = true;
            }
        }

        public void Rollback()
        {
            if (this._reversed == true)
            {
                throw new InvalidOperationException("The transaction has already revered");
            }
            else if (this._executed == false)
            {
                throw new InvalidOperationException("The transaction has not been executed");
            }
            else if (this._executed == true && this._reversed == false)
            {
                this._account.Deposit(_amount);
                this._reversed = true;
            }
        }
    }
}