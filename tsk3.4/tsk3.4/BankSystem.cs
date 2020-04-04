using System;
using System.Collections.Generic;

public enum MenuOptions
{
    Deposit = 1,
    Withdraw = 2,
    Print = 3,
    Quit = 4

}


namespace Account
{
    class BankSystem
    {
        static void Main(string[] args)
        {
            Account ncng = new Account("Thanh Nguyen", 99235);
            Account q = new Account("q", 12);
            Account w = new Account("w", 15);
            Account e = new Account("e", 1);
            Account r = new Account("r", 6);
            Account t = new Account("t", 78);
            Account y = new Account("y", 93);
            Account u = new Account("u", 49);
            Account i = new Account("i", 67);
            Account o = new Account("o", 32);
            Account p = new Account("p", 45);

            List<Account> listAccount = new List<Account> { q, w, e, r, t, y, u, i, o, p };
            Account[] arrayAccount = { q, w, e, r, t, y, u, i, o, p };

            AccountSorter.Sort(listAccount, 10);

            //print out the UI, not for this task
            //UI(ncng);

            Console.ReadLine();
        }

        static void UI(Account account)
        {

            MenuOptions option = ReadUserInput();
            switch (option)
            {
                case MenuOptions.Deposit:
                    {
                        Console.WriteLine(Convert.ToString(option));
                        DoDeposit(account);
                        break;
                    }
                case MenuOptions.Withdraw:
                    {
                        Console.WriteLine(Convert.ToString(option));
                        DoWithdraw(account);
                        break;
                    }
                case MenuOptions.Print:
                    {
                        Console.WriteLine(Convert.ToString(option));
                        DoPrint(account);
                        break;
                    }
                case MenuOptions.Quit:
                    {
                        Console.WriteLine(Convert.ToString(option));
                        break;
                    }
            }
        }

        static MenuOptions ReadUserInput()
        {
            int userInput;

            //Print out the menu options, add more options "MenuOptions" enum above will print more options
            Console.WriteLine("Bank System Options");
            foreach (MenuOptions choices in Enum.GetValues(typeof(MenuOptions)))
            {
                Console.WriteLine("-{0}. {1}", (int)choices, choices);
            }

            //User input validation, stricted to range (1-4)
            do
            {
                userInput = InputToInt(Console.ReadLine());
                if (userInput <= 0 || userInput >= 4)
                {
                    Console.WriteLine("Unknown option, try again!");
                }
            } while (userInput <= 0 || userInput >= 4);

            //Return the option based on the user input, expected 1 to 4
            return (MenuOptions)userInput;
        }

        // These function check the user input
        static int InputToInt(string inputNumberAsString)
        {
            int inputNumber;
            while (!int.TryParse(inputNumberAsString, out inputNumber))
            {
                Console.WriteLine("This is not quite a number");
                inputNumberAsString = Console.ReadLine();
            }
            return inputNumber;

        }
        static decimal InputToDec(string inputNumberAsString)
        {
            decimal inputNumber;
            while (!decimal.TryParse(inputNumberAsString, out inputNumber))
            {
                Console.WriteLine("This is not quite a number");
                inputNumberAsString = Console.ReadLine();
            }
            return inputNumber;

        }

        // Methodd
        static void DoDeposit(Account account)
        {
            Console.WriteLine("Input ammount");
            if (account.Deposit(InputToDec(Console.ReadLine())))
            {
                Console.WriteLine("Deposit sucessful, your new balance is " + account.Balance);
            }
        }
        static void DoWithdraw(Account account)
        {
            Console.WriteLine("Input ammount");
            if (account.Withdraw(InputToDec(Console.ReadLine())))
            {
                Console.WriteLine("Widthdraw sucessful, your new balance is " + account.Balance);
            }
        }
        static void DoPrint(Account account)
        {
            account.Print();
        }
    }
}
