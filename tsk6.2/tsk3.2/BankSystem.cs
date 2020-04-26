using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public enum MenuOptions
{
    [Display(Name = "Add new Account")]
    AddNewAccount = 1,
    Deposit = 2,
    Withdraw = 3,
    Transfer = 4,
    Print = 5,
    Quit = 6
}

namespace Account
{
    internal class BankSystem
    {
        private static void Main(string[] args)
        {
            Bank nBank = new Bank();
            Account ncng = new Account("Thanh Nguyen", 99235);
            Account dumyAccount = new Account("Dummy Account", 0);
            nBank.AddAccount(ncng);
            nBank.AddAccount(dumyAccount);

            while (true)
            {
                Console.Clear();
                //print out the UI
                MenuOptions option = ReadUserInput();
                switch (option)
                {
                    case MenuOptions.AddNewAccount:
                        {
                            AddNewAccount(nBank);
                            break;
                        }
                    case MenuOptions.Deposit:
                        {
                            DoDeposit(nBank);
                            break;
                        }
                    case MenuOptions.Withdraw:
                        {
                            DoWithdraw(nBank);
                            break;
                        }
                    case MenuOptions.Print:
                        {
                            DoPrint(nBank);
                            break;
                        }
                    case MenuOptions.Transfer:
                        {
                            DoTransfer(nBank);
                            break;
                        }
                    case MenuOptions.Quit:
                        {
                            return;
                        }
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
                Console.WriteLine("-{0}. {1}", (int)choices, GetMenuOptionDisplay(choices));
            }
            Console.Write("Select one option: ");

            //User input validation, stricted to range of the item in MenuOptions
            do
            {
                userInput = InputToInt(Console.ReadLine());
                if (userInput <= 0 || userInput > Enum.GetValues(typeof(MenuOptions)).Length)
                {
                    Console.WriteLine("Unknown option, try again!");
                }
            } while (userInput <= 0 || userInput > Enum.GetValues(typeof(MenuOptions)).Length);

            //Return the option based on the user input, expected Number of options in Menu
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

        private static bool YNQuestion(string message)
        {
            Console.WriteLine(message);
            string proceed;
            do
            {
                proceed = Console.ReadLine().ToLower();
                switch (proceed)
                {
                    case "y":
                        {
                            return true;
                        }
                    case "n":
                        {
                            return false;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown option, please try again");
                            proceed = Console.ReadLine().ToLower();
                            break;
                        }
                }
            } while (proceed != "y" && proceed != "n" && string.IsNullOrEmpty(proceed));
            return false;
        }

        private static Account FindAccount(Bank bank)
        {
            Console.WriteLine("Input an account name");
            Account search = bank.Search(Console.ReadLine());
            if (search != null)
            {
                Console.WriteLine("Search result:");
                search.Print();
            }
            else
            {
                Console.WriteLine("No search result!");
            }
            return search;
        }

        // Methodd
        private static void AddNewAccount(Bank bank)
        {
            Console.WriteLine("Input your new account name");
            string accountName = Console.ReadLine();
            Console.WriteLine("Input starting balance");
            decimal accountBalance = InputToDec(Console.ReadLine());

            bank.AddAccount(new Account(accountName, accountBalance));
        }

        private static void DoDeposit(Bank bank)
        {
            //Search for an account
            Account account = FindAccount(bank);
            //Take actions if the account is detected
            if (account != null)
            {
                Console.WriteLine("Input amount");
                decimal amount = InputToDec(Console.ReadLine());
                DepositTransaction currentTransaction = new DepositTransaction(account, amount);


                //Ask user to proceed, take action
                if (YNQuestion("Proceed? Y/N"))
                {
                    bank.ExecuteTransaction(currentTransaction);
                }
                else
                {
                    Console.WriteLine("Transaction cancelled");
                }

                //Ask user, then verify user input

                if (YNQuestion("Print transaction details? Y/N"))
                {
                    currentTransaction.Print();
                }
            }
            else
            {
                Console.WriteLine("Deposit canceled!");
            }

            Console.ReadLine();
        }

        private static void DoWithdraw(Bank bank)
        {
            //Search for an account
            Account account = FindAccount(bank);
            //Take actions if the account is detected
            if (account != null)
            {
                Console.WriteLine("Input amount");
                decimal amount = InputToDec(Console.ReadLine());
                WithdrawTransaction currentTransaction = new WithdrawTransaction(account, amount);


                //Ask user to proceed, take action
                if (YNQuestion("Proceed? Y/N"))
                {
                    bank.ExecuteTransaction(currentTransaction);
                }
                else
                {
                    Console.WriteLine("Transaction cancelled");
                }

                //Ask user, then verify user input

                if (YNQuestion("Print transaction details? Y/N"))
                {
                    currentTransaction.Print();
                }
            }
            else
            {
                Console.WriteLine("Withdraw canceled!");
            }

            Console.ReadLine();

        }

        private static void DoTransfer(Bank bank)
        {
            //Search for an account to withdraw
            Console.WriteLine("From account:");
            Account fromAccount = FindAccount(bank);
            if (fromAccount == null)
            {
                Console.WriteLine("Transfer canceled!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("To account:");
            Account toAccount = FindAccount(bank);
            //Take actions if the account is detected
            if (fromAccount != null && toAccount!= null)
            {
                Console.WriteLine("Input amount");
                decimal amount = InputToDec(Console.ReadLine());
                TransferTransaction currentTransaction = new TransferTransaction(fromAccount, toAccount, amount);


                //Ask user to proceed, take action
                if (YNQuestion("Proceed? Y/N"))
                {
                    bank.ExecuteTransaction(currentTransaction);
                }
                else
                {
                    Console.WriteLine("Transaction cancelled");
                }

                //Ask user, then verify user input

                if (YNQuestion("Print transaction details? Y/N"))
                {
                    currentTransaction.Print();
                }
            }
            else
            {
                Console.WriteLine("Transfer canceled!");
            }

            Console.ReadLine();
        }

        private static void DoPrint(Bank bank)
        {
            Account account = FindAccount(bank);
            if (account != null)
            {
                account.Print();
            }
            Console.ReadLine();
        }

        private static string GetMenuOptionDisplay(MenuOptions option)
        {
            var fieldInfo = option.GetType().GetField(option.ToString());

            DisplayAttribute[] descriptionAttribute = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            //If there is an Display attribute then return it, else retuen the option in string.
            return (descriptionAttribute.Length > 0) ? descriptionAttribute[0].Name : option.ToString();
        }
    }
}