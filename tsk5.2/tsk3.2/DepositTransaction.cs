using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    class DepositTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed, _success, _reversed;

        public DepositTransaction(Account account, decimal amount)
        {
            this._amount = amount;
            this._account = account;
        }
        public bool Executed { get => this._executed; }
        public bool Success { get => this._success; }
        public bool Reversed { get => this._reversed; }
        public void Print()
        {
            Console.WriteLine($"Account name: {this._account.Name}");
            Console.WriteLine($"Amount: {this._amount}");
            Console.Write("Status: ");
            if (this._success == true)
            {
                Console.WriteLine("Sucess!");
            }
            else if (this._success == false)
            {
                Console.WriteLine("Abort");
            }

            Console.WriteLine($"Available fund: {this._account.Balance.ToString("C")}");
        }

        public void Execute()
        {
            if (this._executed == true)
            {
                throw new InvalidOperationException("The transactrion has already been attempted");
            }
            if(this._amount<=0)
            {
                this._executed = false;
                throw new InvalidOperationException("You can not deposit negative!");
            }
            else if (this._amount > 0)
            {
                //Deposit and return true to success
                this._success = this._account.Deposit(_amount);
                this._executed = true;
            }
        }

        public void Rollback()
        {
            if (_reversed == true)
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
            }
        }


    }
}
