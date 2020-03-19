using System;
using System.Collections.Generic;
using System.Text;

namespace MobileProgram
{
    class Mobile
    {
        private String AccType, Device, Number;
        private double Balance;

        //VARIABLES
        private const double CALL_COST = 0.245;
        private const double TEXT_COST = 0.078;


        public Mobile(String AccType, String Device, String Number)
        {
            this.AccType = AccType;
            this.Device = Device;
            this.Number = Number;
            this.Balance = 0.0;
        }

        //Accessor Methods
        public String GetAccType()
        {
            return this.AccType;
        }
        public String GetDevice()
        {
            return this.Device;
        }
        public String GetNumber()
        {
            return this.Number;
        }
        public String GetBalance()
        {
            //Returns the balance as a currency through the
            //ToString method and the parameter ""
            return this.Balance.ToString("C");
        }

        //Mutator Methods
        public void SetAccType (String AccType)
        {
            this.AccType = AccType;
        }
        public void SetDevice(String Device)
        {
            this.Device = Device;
        }
        public void SetNumber(String Number)
        {
            this.Number = Number;
        }
        public void SetBalance(double Balance)
        {
            this.Balance = Balance;
        }

        //Methods
        public void AddCredit(double Ammount)
        {
            this.Balance += Ammount;
            Console.WriteLine("Credit added successfully. New balance is " + GetBalance());
        }
        public void MakeCall(int Minutes)
        {
            double Cost = Minutes * CALL_COST;
            this.Balance -= Cost;
            Console.WriteLine("Call made. New balance: " + GetBalance());
        }
        public void SendText(int NumTexts)
        {
            double Cost = NumTexts * TEXT_COST;
            this.Balance -= Cost;
            Console.WriteLine("Text sent. New Balance: " + GetBalance());

        }
    }
}
