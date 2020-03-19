using System;
using System.Collections.Generic;
using System.Text;

namespace Employee
{
    class Employee
    {
        private String EmployeeName;
        private double CurrentSalary;



        public Employee(string EmployeeName, double CurrentSalary)
        {
            this.EmployeeName = EmployeeName;
            this.CurrentSalary = CurrentSalary;
        }

        //Accessor Methods
        public String GetEmployeeName()
        {
            return this.EmployeeName;
        }
        public String GetCurrentSalary()
        {
            return this.CurrentSalary.ToString();
        }
        public String Tax(double CurrentSalary)
        {
            double AnualTax = 0;
            int AnnualPay = (int)CurrentSalary * 12;

            if (AnnualPay > 0 && AnnualPay <= 18200)
            {
                AnualTax = 0;
            }
            else if (AnnualPay >= 18201 && AnnualPay <= 37000)
            {
                AnualTax = (int)AnnualPay * 19 / 100;
            }
            else if (AnnualPay >= 37001 && AnnualPay <= 90000)
            {
                AnualTax = 3572 + (int)AnnualPay * 32.5 / 100;
            }
            else if (AnnualPay >= 90001 && AnnualPay <= 180000)
            {
                AnualTax = 20797 + (int)AnnualPay * 37 / 100;
            }
            else if (AnnualPay >= 180000)
            {
                AnualTax = 54096 + (int)AnnualPay * 45 / 100;
            }

            return AnualTax.ToString();
        }
        //Mutator Methods
        public void RaiseSalary(double Percentage)
        {
            this.CurrentSalary = CurrentSalary + CurrentSalary * Percentage / 100;
            Console.WriteLine("The new salary is: " + GetCurrentSalary());
        }


    }
}
