using System;

public enum MenuOptions
{
    Deposit     = 1,
    Withdraw    = 2,
    Print       = 3,
    Quit        = 4

}


namespace Account
{
    class BankSystem
    {
        static void Main(string[] args)
        {
            Account ncng = new Account("Thanh Nguyen", 99235);
            ncng.Deposit(200);
            ncng.Withdraw(10);
            ncng.Print();
            MenuOptions option = ReadUserInput();


            
            switch (option)
            {
                case MenuOptions.Deposit:
                    {
                        Console.WriteLine(Convert.ToString(option)); ;
                        break;
                    }
                case MenuOptions.Withdraw:
                    {
                        Console.WriteLine(Convert.ToString(option)); ;
                        break;
                    }
                case MenuOptions.Print:
                    {
                        Console.WriteLine(Convert.ToString(option)); ;
                        break;
                    }
                case MenuOptions.Quit:
                    {
                        Console.WriteLine(Convert.ToString(option)); ;
                        break;
                    }
            }
            
            Console.ReadLine();
        }
        static MenuOptions ReadUserInput()
        {
            int userInput;
            //MenuOptions options = MenuOptions.Deposit;

            


            Console.WriteLine("Bank System Options");
            foreach (MenuOptions choices in Enum.GetValues(typeof(MenuOptions)))
            {
                Console.WriteLine("-{0}. {1}", (int)choices, choices);
            }

            do
            {
                userInput = InputToInt(Console.ReadLine()); 
                if (userInput <=0 || userInput >=4)
                {
                    Console.WriteLine("Unknown option, try again!");
                }
            } while (userInput<=0||userInput>=4);

            
            return (MenuOptions)userInput;            
        }

        // This function check the user input
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
    }
}
