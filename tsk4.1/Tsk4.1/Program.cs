using System;

namespace Tsk4._1
{
    class Program
    {
        public static void Main()
        {
            //NullReferenceException
            try
            {
                Account nullAccount = null;
                nullAccount.Withdraw(3000);
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine("There is a null value that is being used as reference!\n" + exception.ToString());
            }
            Console.ReadKey();


            //IndexOutOfRangeException
            int[] testArray = new int[6];
            int index = 9;
            try
            {

                testArray[index] = 50;
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine($"You are trying to access the position {index.ToString()} of the array that have the length of {testArray.Length}\n" + exception.ToString());
            }
            Console.ReadKey();

            //StackOverflowException
            //This exception can not be caught since .NET Framework 2.0

            //

            //InvalidOperationException
            try
            {
                Account account = new Account("Sergey", "P", 100);
                account.Withdraw(1000);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            Console.ReadKey();
        }
    }
    class Account
    {
        public string _firstName { get; private set; }
        public string _lastName { get; private set; }
        public int _balance { get; private set; }

        public Account(string _firstName, string _lastName, int balance)
        {
            _firstName = _firstName;
            _lastName = _lastName;
            _balance = balance;
        }

        public void Withdraw(int amount)
        {
            if (amount > this._balance)
            {
                throw new InvalidOperationException("Insufficient fund");
            }
            _balance -= amount;
        }
    }


}
