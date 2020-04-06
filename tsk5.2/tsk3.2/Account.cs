using System;
namespace Account
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
        public bool Deposit(decimal ammount)
        {
            bool deposited = false;
            if (ammount < 0)
            {
                Console.WriteLine("The deposit ammount must not be negative");
                deposited = false;
            }           
            else if (ammount >= 0)
            {
                this._balance += ammount;
                deposited = true;
            }
            return deposited;
        }

        public bool Withdraw(decimal ammount)
        {
            bool withdraw = false;
            if (ammount < 0)
            {
                Console.WriteLine("The deposit ammount must not be negative");
                withdraw = false;
            }
            else if (ammount > this._balance)
            {
                Console.WriteLine("You can not withdraw more than your balance!");
            }
            else
            {
                this._balance -= ammount;
                withdraw = true;
            }
            return withdraw;
        }

        
    }
}
