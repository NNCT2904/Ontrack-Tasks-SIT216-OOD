using System;
namespace tsk3._3
{
    public class MyPolynomial
    {
        private double degree;
        private double[] _coeffs;

        public MyPolynomial(double[] coeffs)
        {
            this._coeffs = coeffs;
            this.degree = coeffs.Length;
        }

        public int GetDegree() => (int)this.degree;

        public string ToString()
        {
            string result = "({0}*x^{1})";
            result = string.Format(result, this._coeffs[this._coeffs.Length - 1], this._coeffs.Length -1);
            for (int i = (this._coeffs.Length - 2); i >= 0; i--)
            {
                result = string.Concat(result, " + (" + this._coeffs[i] + "*x^" + (i) + ")");
            }
            Console.WriteLine(result);
            return result;
        }

        public double Evaluate(double x)
        {
            double result = 0;

            for (int i = (_coeffs.Length - 1); i >= 0; i--)
            {
                result += _coeffs[i] * Math.Pow(x, (i + 1));
            }
            Console.WriteLine($"Evaluation at x= {x}: {result}");
            return result;
        }

        public MyPolynomial Add(MyPolynomial another)
        {
            //Find the size of the new polynomial, this way I dont have to do 2 if statements
            int size = (int)Max(this._coeffs.Length, another._coeffs.Length);
            double[] array = new double[size];
            MyPolynomial result = new MyPolynomial(array);

            //Put the original array in
            for (int i = this._coeffs.Length - 1; i >= 0; i--)
            {
                array[i] = this._coeffs[i];
            }

            //Then add another array
            for (int i = another._coeffs.Length - 1; i >= 0; i--)
            {
                array[i] += another._coeffs[i];
            }


            //Transfer the array to result
            for (int i = (result._coeffs.Length - 1); i >= 0; i--)
            {
                result._coeffs[i] = array[i];
            }

            string resultAnother = "({0}*x^{1})";
            resultAnother = string.Format(resultAnother, result._coeffs[result._coeffs.Length - 1], result._coeffs.Length -1);
            for (int i = (result._coeffs.Length - 2); i >= 0; i--)
            {
                resultAnother = string.Concat(resultAnother, " + (" + result._coeffs[i] + "*x^" + (i) + ")");
            }
            Console.WriteLine(resultAnother);

            return result;
        }

        public MyPolynomial Multiply(MyPolynomial another)
        {
            //Find the size of the new polynomial
            int size = this._coeffs.Length + another._coeffs.Length - 1;
            double[] array = new double[size];
            MyPolynomial result = new MyPolynomial(array);

            //Multiply each of them
            for (int i = this._coeffs.Length - 1; i >= 0; i--)
            {
                //Mutyply the current position array
                //With a line of another 
                for (int j = another._coeffs.Length - 1; j >= 0; j--)
                {
                    array[i+j] += this._coeffs[i] * another._coeffs[j];
                }
            }



            //Transfer the array to result
            for (int i = (result._coeffs.Length - 1); i >= 0; i--)
            {
                result._coeffs[i] = array[i];
            }

            string resultAnother = "({0}*x^{1})";
            resultAnother = string.Format(resultAnother, result._coeffs[result._coeffs.Length - 1], result._coeffs.Length -1);
            for (int i = (result._coeffs.Length - 2); i >= 0; i--)
            {
                resultAnother = string.Concat(resultAnother, " + (" + result._coeffs[i] + "*x^" + (i) + ")");
            }
            Console.WriteLine(resultAnother);

            return result;
        }

        public double Max(double a, double b)
        {
            return (a > b) ? a : b;
        }
    }
}
