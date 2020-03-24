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
        public void Deposit(decimal Ammount)
        {
            this._balance += Ammount;
        }

        public void Withdraw(decimal Ammount)
        {
            this._balance -= Ammount;
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
    }
}
