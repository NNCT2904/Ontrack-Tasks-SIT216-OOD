using System;

namespace Employee
{
    class EmployeeProgram
    {
        static void Main(string[] args)
        {
            Employee ThanhNguyen = new Employee("Thanh Nguyen", 160000);

            ThanhNguyen.RaiseSalary(20);
            
            Console.WriteLine(
                "Employee name: " + ThanhNguyen.GetEmployeeName() +
                "\nSalary: " + ThanhNguyen.GetCurrentSalary() +
                "\nAnnual Tax: " + ThanhNguyen.Tax(Convert.ToDouble(ThanhNguyen.GetCurrentSalary()))
                );

        }
    }
}
