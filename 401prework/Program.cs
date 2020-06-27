using System;
using System.Collections.Generic;
using System.Linq;

namespace _401prework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, and welcome to my 401 ASP.NET prework. Please choose from the options below.");
            string options = "0. Exit Program\n1. Array Max Result\n2. Leap Year Calculator\n3. Perfect Sequence\n4. Sum of Rows";
            Console.WriteLine(options);
            int choice = int.Parse(Console.ReadLine());
            while (choice != 0)
            {
                UserChoice(choice);
                Console.WriteLine("\n\nPlease choose another option:");
                Console.WriteLine(options);
                choice = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Thanks for visiting!");
        }


        static void UserChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    HandleArrayMaxResult();
                    break;
                case 2:
                    HandleLeapYearCalc();
                    break;
                case 3:
                    HandlePerfectSequence();
                    break;
                case 4:
                    HandleSumOfRows();
                    break;
            }
        }

        public static int ArrayMaxResult(int[] arr, int choice)
        {
            int result = 0;
            foreach (int num in arr)
            {
                if (num == choice)
                {
                    result += num;
                }
            }
            return result;
        }

        public static void HandleArrayMaxResult()
        {
            Console.WriteLine("\n\nPlease enter 5 numbers between 1 and 10, one number at a time.");
            int[] maxArr = new int[5];
            for (int i = 0; i < maxArr.Length; i++)
            {
                maxArr[i] = int.Parse(Console.ReadLine());
                while (maxArr[i] < 1 || maxArr[i] > 10)
                {
                    Console.WriteLine("Oops, that number's out of bounds, choose a new one!");
                    maxArr[i] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine($"You chose: {string.Join(", ", maxArr)}");
            Console.WriteLine("Now choose one number from the list you entered.");
            int maxChoice = int.Parse(Console.ReadLine());
            int maxResult = ArrayMaxResult(maxArr, maxChoice);
            Console.WriteLine($"Your score is: {maxResult}");
        }

        public static string LeapYearCalculator(int year)
        {
            // DateTime.IsLeapYear(year) will only work for 4 digit years
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                return $"Yep, {year} is a leap year!";
            }
            return $"Nope, {year} is not a leap year.";
        }

        public static void HandleLeapYearCalc()
        {
            Console.WriteLine("\n\nWhat year would you like to know about?");
            int year = int.Parse(Console.ReadLine());
            string leapResult = LeapYearCalculator(year);
            Console.WriteLine(leapResult);
        }

        public static string PerfectSequence(List<int> arr)
        {
            if (arr.Sum() == arr.Aggregate(1, (x, y) => x * y))
            {
                return "Yes, it's a perfect sequence.";
            }
            return "No, it's not a perfect seqeuence.";

            /* 
             * Without LINQ:
             * int product = 1;
             * int sum = 0;
             * foreach(int num in arr)
             * {
             *      product *= num;
             *      sum += num;
             * }
             * if (product == num)
             * {
             *      return "Yes";
             * }
             * return "No";
             */
        }

        public static void HandlePerfectSequence()
        {
            Console.WriteLine("\n\nEnter the (positive) numbers you would like to test for being a perfect sequence one at a time.\nPress enter with no input when finished.");
            List<int> perfArr = new List<int>();
            string choice = Console.ReadLine();
            while (choice != "")
            {
                perfArr.Add(int.Parse(choice));
                choice = Console.ReadLine();
            }
            string perfResult = PerfectSequence(perfArr);
            Console.WriteLine(perfResult);
        }

        /*
         * Problem 4: Sum of Rows
           Problem Statement
            Given a matrix of integers. Return the sum of each row in a single dimensional array.

            Input Format
            a multidimensional array with the dimensions of m x n (m = rows, n = columns).

            duplicate integers are possible.
            Negative numbers are possible
            both m and n can vary in length
            The user should specify the length and the width of the array within the console. To populate the numbers, you may randomly generate them, or have the user input one by one.

            The method should take in the multidimensional array and return the single dimensional array with the sums

            Sample Input
            int[,] myArray = new int[3, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 } };
            ^^ The actual input would just be myArray, but the above code shows the pre-initialization before the method is called.

            Sample Output
            {15,40,65} <-- an integer array

            HINTS
            for loops are your best friend
            GetLength() is a method you should look into
            i.e. in the array above myArray.GetLength(0) is equal to 3
            myArray.GetLength(1) is equal to 5
         */

        public static void SumOfRows(int[,] arr)
        {
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);
            int[] result = new int[m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Random rand = new Random();
                    arr[i, j] = rand.Next(100);
                }
            }
            Console.WriteLine("Your randomly generated matrix is:");
            for (int i = 0; i < m; i++)
            {
                Console.Write("{");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j]);
                    result[i] += arr[i, j];
                    if (j != n-1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("}");
                Console.WriteLine("");
            }
            Console.WriteLine($"The sum of the rows are: {{{string.Join(", ", result)}}}");
        }

        public static void HandleSumOfRows()
        {
            Console.WriteLine("\n\nPlease enter the number of rows you would like first, and then the number of columns.\nI.e. 2 then 3 for a matrix with 2 rows and 3 columns in each row.");
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[m, n];
            SumOfRows(arr);
        }
    }
}
