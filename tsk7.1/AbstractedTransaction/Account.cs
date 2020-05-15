using System;
namespace AbstractedTransaction
{
    public class Account
    {
        private decimal _balance;
        private String _name;
        public Account(String name, decimal balance)
        {
            this._balance = balance;
            this._name = name;
        }

        //Accessor methods
        public void Print()
        {
            Console.WriteLine("Account name: " + this._name);
            Console.WriteLine("Available balance: " + this._balance);
        }
        public String Name { get => _name; }
        public decimal Balance { get => _balance; }

        //Mutator methods
        public bool Deposit(decimal amount)
        {
            bool deposited = false;
            if (amount < 0)
            {
                Console.WriteLine("The deposit amount must not be negative");
                deposited = false;
            }           
            else if (amount >= 0)
            {
                this._balance += amount;
                deposited = true;
            }
            return deposited;
        }

        public bool Withdraw(decimal amount)
        {
            bool withdraw = false;
            if (amount < 0)
            {
                Console.WriteLine("The deposit amount must not be negative");
                withdraw = false;
            }
            else if (amount > this._balance)
            {
                Console.WriteLine("You can not withdraw more than your balance!");
            }
            else
            {
                this._balance -= amount;
                withdraw = true;
            }
            return withdraw;
        }

        
    }
}
