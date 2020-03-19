using System;

namespace MyTime
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTime a = new MyTime(01,10,40);
            a.PreviousSecond();
            //a.SetHour(70);
            Console.WriteLine(Convert.ToString(a.TimeToString()));
        }
    }
}
