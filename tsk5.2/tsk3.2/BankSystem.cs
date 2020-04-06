using System;

public enum MenuOptions
{
    Deposit = 1,
    Withdraw = 2,
    Print = 3,
    Quit = 4
}

namespace Account
{
    internal class BankSystem
    {
        private static void Main(string[] args)
        {
            Account ncng = new Account("Thanh Nguyen", 99235);

            //print out the UI
            MenuOptions option = ReadUserInput();
            switch (option)
            {
                case MenuOptions.Deposit:
                    {
                        Console.WriteLine(Convert.ToString(option));
                        DoDeposit(ncng);
                        break;
                    }
                case MenuOptions.Withdraw:
                    {
                        Console.WriteLine(Convert.ToString(option));
                        DoWithdraw(ncng);
                        break;
                    }
                case MenuOptions.Print:
                    {
                        Console.WriteLine(Convert.ToString(option));
                        DoPrint(ncng);
                        break;
                    }
                case MenuOptions.Quit:
                    {
                        Console.WriteLine(Convert.ToString(option));
                        break;
                    }
            }
        }

        private static MenuOptions ReadUserInput()
        {
            int userInput;

            //Print out the menu options, add more options "MenuOptions" enum above will print more options
            Console.WriteLine("Bank System Options");
            foreach (MenuOptions choices in Enum.GetValues(typeof(MenuOptions)))
            {
                Console.WriteLine("-{0}. {1}", (int)choices, choices);
            }
            Console.Write("Select one option: ");

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
        private static int InputToInt(string inputNumberAsString)
        {
            int inputNumber;
            while (!int.TryParse(inputNumberAsString, out inputNumber))
            {
                Console.WriteLine("This is not quite a number");
                inputNumberAsString = Console.ReadLine();
            }
            return inputNumber;
        }

        private static decimal InputToDec(string inputNumberAsString)
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
        private static void DoDeposit(Account account)
        {
            Console.WriteLine("Input amount");
            if (account.Deposit(InputToDec(Console.ReadLine())))
            {
                Console.WriteLine("Deposit sucessful, your new balance is " + account.Balance);
            }
        }

        private static void DoWithdraw(Account account)
        {
            Console.WriteLine("Input amount to withdraw: ");
            decimal amount = InputToDec(Console.ReadLine());
            WithdrawTransaction currentTransaction = new WithdrawTransaction(account, amount);

            //Ask user to proceed, and veryfy user input.
            Console.WriteLine("Proceed? Y/N");
            string proceed;
            do
            {
                proceed = Console.ReadLine().ToLower();
                switch (proceed)
                {
                    case "y":
                        {
                            currentTransaction.Execute();
                            break;
                        }
                    case "n":
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown option, please try again");
                            proceed = Console.ReadLine().ToLower();
                            break;
                        }
                }
            } while (proceed != "y" && proceed != "n" && string.IsNullOrEmpty(proceed));

            //Ask user, then verify user input
            Console.WriteLine("Print transaction details? Y/N");
            string print;
            do
            {
                print = Console.ReadLine().ToLower();
                switch (proceed)
                {
                    case "y":
                        {
                            currentTransaction.Print();
                            break;
                        }
                    case "n":
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown option, please try again");
                            print = Console.ReadLine().ToLower();
                            break;
                        }
                }
            } while (print != "y" && print != "n" && string.IsNullOrEmpty(print));

            Console.ReadLine();

        }

        private static void DoPrint(Account account)
        {
            account.Print();
        }
    }
}