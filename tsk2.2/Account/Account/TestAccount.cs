using System;

namespace Account
{
    class Program
    {
        static void Main(string[] args)
        {
            Account ncng = new Account("Thanh Nguyen", 99235);
            ncng.Deposit(200);
            ncng.Withdraw(10);            
            ncng.Print();
        }
    }
}
