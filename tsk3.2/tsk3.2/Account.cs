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


        //Mutator methods
        public bool Deposit(decimal Ammount)
        {
            bool deposited = false;
            if (Ammount < 0)
            {
                Console.WriteLine("The deposit ammount must not be negative");
                deposited = false;
            }
            else if (Ammount >= 0)
            {
                this._balance += Ammount;
                deposited = true;
            }
            return deposited;
        }

        public bool Withdraw(decimal Ammount)
        {
            bool withdraw = false;
            if (Ammount < 0)
            {
                Console.WriteLine("The deposit ammount must not be negative");
                withdraw = false;
            }
            else if (Ammount >= 0)
            {
                this._balance -= Ammount;
                withdraw = true;
            }
            return withdraw;
        }

        //Accessor methods
        public void Print()
        {
            Console.WriteLine("Account name: " + this._name);
            Console.WriteLine("Available balance: " + this._balance);
        }
        public String Name()
        {
            return this._name;
        }
        public Decimal Balance()
        {
            return this._balance;
        }
    }
}
