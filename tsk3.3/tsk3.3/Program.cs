using System;

namespace tsk3._3
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] test2dArray = { 2, -4, 5};
            double[] testAnother2DArray = { 3, 5, 7, 2 };
            MyPolynomial poly1 = new MyPolynomial(test2dArray);
            MyPolynomial poly2 = new MyPolynomial(testAnother2DArray);

            //Show the first polynomial
            Console.WriteLine("The 1st polynomial: ");
            poly1.ToString();
            Console.WriteLine($"Degree: {poly1.GetDegree()} \n");

            //Show the second polynomial
            Console.WriteLine("The 2nd polynomial: ");
            poly2.ToString();
            Console.WriteLine($"Degree: {poly2.GetDegree()} \n");

            //Polynomial 1 + polynomial 2
            Console.WriteLine("Polynomial 1 + polynomial 2");
            poly1.Add(poly2);
            Console.WriteLine();

            //Polynomial 1 * polynomial 2
            Console.WriteLine("Polynomial 1 * polynomial 2");
            poly1.Multiply(poly2);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
