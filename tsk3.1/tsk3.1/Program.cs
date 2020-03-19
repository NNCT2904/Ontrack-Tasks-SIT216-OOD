using System;
using System.Collections.Generic;

namespace tsk3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1

            //double[] myArray = new double[10];

            //myArray[0] = 1.0;
            //myArray[1] = 1.1;
            //myArray[2] = 1.2;
            //myArray[3] = 1.3;
            //myArray[4] = 1.4;
            //myArray[5] = 1.5;
            //myArray[6] = 1.6;
            //myArray[7] = 1.7;
            //myArray[8] = 1.8;
            //myArray[9] = 1.9;

            //Console.WriteLine("The element at index 0 in the array is " + myArray[0]);
            //Console.WriteLine("The element at index 1 in the array is " + myArray[1]);
            //Console.WriteLine("The element at index 2 in the array is " + myArray[2]);
            //Console.WriteLine("The element at index 3 in the array is " + myArray[3]);
            //Console.WriteLine("The element at index 4 in the array is " + myArray[4]);
            //Console.WriteLine("The element at index 5 in the array is " + myArray[5]);
            //Console.WriteLine("The element at index 6 in the array is " + myArray[6]);
            //Console.WriteLine("The element at index 7 in the array is " + myArray[7]);
            //Console.WriteLine("The element at index 8 in the array is " + myArray[8]);
            //Console.WriteLine("The element at index 9 in the array is " + myArray[9]);

            //2
            //int[] myArray = new int[10];

            //for (int i=0; i<10; i++)
            //{
            //    myArray[i] = i;
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("The element at position " + i + " in the array is " + myArray[i]);
            //}

            //3
            //int[] studentArray = { 87, 68, 94, 100, 83, 78, 85, 91, 76, 87 };
            //int total = 0;

            //for (int i = 0; i < studentArray.Length; i++)
            //{
            //    total += studentArray[i];
            //}
            //Console.WriteLine("The total marks for the student is: " + total);
            //Console.WriteLine("This consisted of " + studentArray.Length + " marks");
            //Console.WriteLine("Therefore the average mark is " + ((double)total / studentArray.Length));

            //4
            //String[] studentNames = new String[6];

            //for (int i = 0; i < studentNames.Length; i++)
            //{
            //    Console.WriteLine("Input the name for the student " + (i+1));
            //    studentNames[i] = Console.ReadLine();
            //}
            //for (int i = 0; i < studentNames.Length; i++)
            //{
            //    Console.WriteLine("The student at position " + (i+1) + " is " + studentNames[i]);

            //}


            //5
            //double[] array = new double[10];
            //int currentSize = 0;
            //double currentLargest, currentSmallest;

            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine("Input value to array at position " + i);
            //    array[i] = ValidatingUserInput(Console.ReadLine());
            //}

            ////find the largest
            //currentLargest = array[0];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (array[i] > currentLargest)
            //    {
            //        currentLargest = array[i];
            //    }
            //}
            ////find the smallest
            //currentSmallest = array[0];
            //for (int i =0; i < array.Length; i++)
            //{
            //    if (array[i] < currentSmallest)
            //    {
            //        currentSmallest = array[i];
            //    }
            //}

            //Console.WriteLine("The largest number in the array is "+currentLargest);
            //Console.WriteLine("The smallest number in the array is "+currentSmallest);


            //6

            //int[,] myArray = new int[3, 4]
            //{
            //    {1, 2, 3, 4 },
            //    {1, 1, 1, 1 },
            //    {2, 2, 2, 2 }
            //};

            //for (int i = 0; i < myArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < myArray.GetLength(1); j++)
            //    {
            //        Console.Write(myArray[i, j]+"\t");
            //    }
            //    Console.WriteLine();
            //}


            
            //List<String> myStudentList = new List<string>();
            //Random randomValue = new Random();
            //int randomNumber = randomValue.Next(1, 12);

            //Console.WriteLine("You need to add " + randomNumber + " students to your class list");
            //for (int i = 0; i < randomNumber; i++)
            //{
            //    Console.WriteLine("Please enter the name of student " + (i + 1) + ": ");
            //    myStudentList.Add(Console.ReadLine());
            //    Console.WriteLine();
            //}
            //for (int i = 0; i< randomNumber; i++)
            //{
            //    Console.WriteLine(myStudentList[i]);
            //}
            


            //7

            int[] testArray = { 10, 12, 44, 13, 15 };
            FuncOne(testArray);

            List<double> testList = new List<double> { 12, 432, 123, 72, 1, 0, 456 };
            FuncTwo(testList);

            int[,] test2dArray = new int[3, 4]
            {
                {9, 2, 3, 4 },
                {1, 12, 2, 1 },
                {2, 4, 0, -9 }
            };
            FucThree(test2dArray);



            Console.ReadLine();
        }

        public static void FuncOne(int[] inputArray)
        {
            int returnValue = 0;
            
            if (inputArray.Length > 10)
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (inputArray[i]%2 == 0)
                    {
                        returnValue += 1;
                    }
                }
                        Console.WriteLine("There are " + returnValue + " even numbers");
            }
            else if (inputArray.Length <=10)
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (inputArray[i] % 2 != 0)
                    {
                        returnValue += inputArray[i];
                    }
                }
            Console.WriteLine("The sum of odds number in array is " + returnValue);
            }
        }

        public static void FuncTwo(List<double> inputList)
        {
            double sum = 0;
            
            for (int i = 0; i < inputList.Count; i++)
            {
                sum += inputList[i];
            }
            double avg = sum / inputList.Count;
            Console.WriteLine("The average of numbers in the list is: "+avg);
        }

        public static void FucThree(int[,] inputArray)
        {
            int[] testArray = new int[(inputArray.GetLength(0)*inputArray.GetLength(1))];
            int counterForTestArray = 0;
            for (int i = 0; i < inputArray.GetLength(0); i++)
            {
                for (int j = 0; j < inputArray.GetLength(1); j++)
                {
                    if (inputArray[i,j]%3 == 0)
                    {
                        testArray[counterForTestArray] = inputArray[i, j];
                        counterForTestArray++;
                    }
                }               
            }
            for (int i =0; i<testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);
            }
        }

        public static double ValidatingUserInput(String inputNumberAsString)
        {
            double inputNumber;
            while (!double.TryParse(inputNumberAsString, out inputNumber))
            {               
                Console.WriteLine("This is not quite a number");
                inputNumberAsString = Console.ReadLine();
            }
            return inputNumber;
        }
    }
}
