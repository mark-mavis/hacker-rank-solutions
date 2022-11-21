using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMonthPreperationKit
{
    class SubarrayDivision1
    {
        public static int RunImprovedSubarrayDivision(List<int> s, int d, int m)
        {
            int count = 0;
            int tempSum = 0;

            for (int i = 0; i < s.Count; i++)
            {    //Count-1 one to stop the inside loop from accesing
                 //Data that is not part of the List passed.
                if (s[i] > d) continue;     //Position 1 Value check (Less than or equal to d)
                                            //Only makes it past is first position is even possible
                                            // to be equal to d
                if (s[i] == d)
                {
                    count++;
                    if (i == s.Count - 1) break;
                    continue;
                }

                tempSum += s[i];

                for (int j = i; j < s.Count; j++)
                {
                    if (i == j) continue;

                    if (tempSum + s[j] == d)
                    {
                        count++;
                        i = j;
                        break;
                    }
                    else if (tempSum + s[j] < d)
                    {
                        tempSum += s[j];
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                tempSum = 0;
            }
            return count;
        }
        public static int RunSubarrayDivision(List<int> s, int d, int m)
        {
            int tempSum = 0;
            int count = 0;

            for (int i = 0; i < s.Count-(m-1); i++)
            { 
                for(int j = i; j < (i+m); j++)
                {
                    tempSum += s[j];  
                }
                
                if (tempSum == d) {
                    count++;
                }
                tempSum = 0;
            }
            return count;
        }


        public static void Run()
        {
            List<int> arr = new List<int>() {2, 2, 3, 1, 2 };
            Console.WriteLine(RunSubarrayDivision(arr, 4, 2));

            arr = new List<int>() { 1, 1, 1, 1, 2 };
            Console.WriteLine(RunSubarrayDivision(arr, 6, 2));

            arr = new List<int>() { 1, 1, 1, 1, 2, 6 };
            Console.WriteLine(RunSubarrayDivision(arr, 6, 2));

            arr = new List<int>() { 1, 1, 1, 1, 2, 2 };
            Console.WriteLine(RunSubarrayDivision(arr, 6, 2));

            arr = new List<int>() { 1, 2, 1, 3, 2 };
            Console.WriteLine(RunSubarrayDivision(arr, 3, 2));

            arr = new List<int>() { 4 };
            Console.WriteLine(RunSubarrayDivision(arr, 4, 1));

        }
    }
}
