using System;

namespace MobileProgram
{
    class MobileProgram
    {
        static void Main(string[] args)
        {
            //1
            Mobile JimMobile = new Mobile("Monthly", "Samsung Galaxy S6", "07712223344");
            JimMobile.SetAccType("PAYG");
            JimMobile.SetDevice("iPhone 6S");
            JimMobile.SetNumber("07713334466");
            JimMobile.SetBalance(15.60);

            Console.WriteLine(
                "Account Type: " + JimMobile.GetAccType() + 
                "\nMobile Number: " + JimMobile.GetNumber() + 
                "\nDevice: " + JimMobile.GetDevice() +
                "\nBalance: " + JimMobile.GetBalance()
                );

            Console.WriteLine();
            JimMobile.AddCredit(10.0);
            JimMobile.MakeCall(5);
            JimMobile.SendText(2);


            //2
            Console.WriteLine();
            Mobile DellG7 = new Mobile("PAYG", "Dell G7 7588", "0444555666");
            DellG7.AddCredit(1238471.0);
            DellG7.MakeCall(60);
            DellG7.SendText(325);

            Console.ReadLine();

            
        }
    }
}
