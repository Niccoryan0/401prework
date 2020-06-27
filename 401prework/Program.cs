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
            string options = "0.Exit Program\n1. Array Max Result\n2. Leap Year Calculator\n3. Perfect Sequence\n4. Sum of Rows";
            Console.WriteLine(options);
            int choice = int.Parse(Console.ReadLine());
            while (choice != 0)
            {
                UserChoice(choice);
                Console.WriteLine("\n\nPlease choose another option:");
                Console.WriteLine(options);
                choice = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Thanks for visiting. Press any button to close.");
            Console.ReadLine();
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
            if (arr.Sum() == arr.Aggregate(1, (x1, x2) => x1 * x2))
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

        

    }
}
