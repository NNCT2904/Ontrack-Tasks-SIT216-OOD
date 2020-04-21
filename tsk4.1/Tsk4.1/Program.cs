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
            catch (SystemException exception)
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
                Console.WriteLine($"\nYou are trying to access the position {index.ToString()} of the array that have the length of {testArray.Length}\n" + exception.ToString());
            }
            Console.ReadKey();

            //StackOverflowException
            //This exception can not be caught since .NET Framework 2.0

            //OutOfMemoryException
            //I can't make this exeptions since my computer's memory is just too big

            //InvalidCastExeption
            try
            {
            bool testBool = true;
            DateTime testDateTime = Convert.ToDateTime(testBool);
            }
            catch (InvalidCastException exception)
            {
                Console.WriteLine($"\n{exception.ToString()}\n");
            }
            Console.ReadKey();

            //ArgumentException
            try
            {
                int number = EvenNumberCheck(11);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine($"\n The following error detected: {exception.GetType().ToString()} with message: {exception.Message}\n");
            }
            Console.ReadKey();

            //ArgumentOutOfRangeException
            try
            {
                int age = CheckAdultAge(16);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine($"\n The following error detected: {exception.GetType().ToString()} with message: {exception.Message}\n");
            }
            Console.ReadKey();

            //InvalidOperationException
            try
            {
                Account account = new Account("Sergey", "P", 100);
                account.Withdraw(1000);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("\nThe following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            Console.ReadKey();
        }


        static int CheckAdultAge(int inputAge)
        {
            if (inputAge<18)
            {
                throw new ArgumentOutOfRangeException(inputAge.ToString(),"Too young, come back when you are over 18");
            }
            return inputAge;
        }

        static int EvenNumberCheck(int input)
        {
            if (input%2!=0)
            {
                throw new ArgumentException(string.Format($"{input} is not an even number"));
            }
            return input;
        }
    }
    class Account
    {
        public string _firstName { get; private set; }
        public string _lastName { get; private set; }
        public int _balance { get; private set; }

        public Account(string firstName, string lastName, int balance)
        {
            firstName = _firstName;
            lastName = _lastName;
            balance = _balance;
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
