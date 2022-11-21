using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class WarmUpsEasy
    {
        public static List<int> CompareTriplets(List<int> a, List<int> b)
        {
            int bobPoints = 0;
            int alicePoints = 0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < a.Count; j++)
                {
                    if (a[j] > b[j]) alicePoints++;
                    else if (a[j] < b[j]) bobPoints++;
                    else
                    {
                        continue;
                    }
                }
            }
            return new List<int>() { alicePoints, bobPoints };
        }
        public static int DiagonalDifference(List<List<int>> arr)
        {
            int right_diag = 0;
            int left_diag = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    left_diag += arr[i][i];
                    right_diag += arr[i][arr.Count - 1 - i];
                }
            }
            return Math.Abs(right_diag - left_diag);

        }
        public static void PlusMinus(List<int> arr)
        {
            double positiveCount = 0;
            double negativeCount = 0;
            double zeroCount = 0;

            foreach (int val in arr)
            {
                if (val > 0)
                {
                    positiveCount++;
                }
                else if (val < 0)
                {
                    negativeCount++;
                }
                else
                {
                    zeroCount++;
                }
            }

            double positiveRatio = positiveCount / (double)arr.Count;
            double negativeRatio = negativeCount / (double)arr.Count;
            double zeroRatio = zeroCount / (double)arr.Count;

            Console.WriteLine(positiveRatio.ToString("N6"));
            Console.WriteLine(negativeRatio.ToString("N6"));
            Console.WriteLine(zeroRatio.ToString("N6"));
        }
        public static void Staircase(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (j >= n - 1 - i)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        public static void MinMaxSum(int[] arr)
        {
            if (arr.Count() < 1000000000)
            {
                double minVal = arr[0];
                double maxVal = arr[0];
                double totalSum = 0;

                foreach (double val in arr)
                {
                    if (val < minVal) minVal = val;
                    if (val > maxVal) maxVal = val;
                    totalSum += val;
                }
                Console.WriteLine((totalSum - maxVal) + " " + (totalSum - minVal));
            }
        }
        public static int BirthdayCakeCandles(List<int> candles)
        {
            int Max = candles.Max();
            int MaxCount = 0;
            for (int i = 0; i < candles.Count; i++)
            {
                if (candles[i] == Max) MaxCount++;
            }
            return MaxCount;

        }
        public static string TimeConversion(string s)
        {
            char[] delimitedChars = { ':', ' ', '\t' };
            string[] time = s.Split(delimitedChars);    //Split the Time String into elements in an array based on the delimiter charicter array above
            string meridien = time[2].Substring(2, 2).ToLower();
            int hourVal = Int32.Parse(time[0]);

            //if( hourVal < 0 || hourVal > 12 ) break;
            if (meridien == "am")
            {
                if (hourVal == 12) return "00" + ":" + time[1] + ":" + time[2].Substring(0, 2); // If time is AM and 12
                return hourVal.ToString("00") + ":" + time[1] + ":" + time[2].Substring(0, 2);  // If time is AM and <12
            }
            else
            {                   
                if (hourVal == 12)
                {    // If time is PM and 12
                    return time[0] + ":" + time[1] + ":" + time[2].Substring(0, 2);  
                }

                // If time is PM and <12
                return (hourVal + 12).ToString("00") + ":" + time[1] + ":" + time[2].Substring(0, 2);   
            }
        }
        
    }

    class WarmUpEasyManager
    {
        public static void Run()
        {
            //List<int> a = new List<int>() { 5, 6, 7 };
            //List<int> b = new List<int>() { 3, 6, 10 };

            //List<int> c = WarmUpsEasy.CompareTriplets(a, b);

            //List<List<int>> arr = new List<List<int>>()
            //{
            //    new List<int>(){11, 2, 4 },
            //    new List<int>() {4, 5, 6 },
            //    new List<int>(){10, 8, -12}
            //};

            //WarmUpsEasy.DiagonalDifference(arr);

            //WarmUpsEasy.PlusMinus(new List<int>() { 1, 1, 0, -1, -1 });

            //WarmUpsEasy.Staircase(6);

            //WarmUpsEasy.MinMaxSum(new int[] { 256741038, 623958417, 467905213, 714532089, 938071625 });

            //List<int> candles = new List<int>() { 3, 2, 1, 3 };
            //Console.WriteLine(WarmUpsEasy.BirthdayCakeCandles(candles));

            Console.WriteLine(WarmUpsEasy.TimeConversion("12:00:00AM"));




        }
    }
}
