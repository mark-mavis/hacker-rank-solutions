using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Numerics;
using System.Globalization;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Transactions;

namespace Algorithms.Result
{
    public class Result
    {
        public static BigInteger big;
        public static int BetweenTwoSets(List<int> a, List<int> b)
        {
            int minVal = a.Max();
            int maxVal = b.Min();

            List<int> possibleN = new List<int>();

            //Handling Possible Int Range
            for (int i = minVal; i <= maxVal; i++)
            {
                bool a_arr = true;
                bool b_arr = true;

                for (int arr_a = 0; arr_a < a.Count; arr_a++)
                {
                    if (i % a[arr_a] != 0) a_arr = false;
                }

                for (int arr_b = 0; arr_b < b.Count; arr_b++)
                {
                    if (b[arr_b] % i != 0) a_arr = false;
                }

                if (a_arr && b_arr) possibleN.Add(i);
            }
            return possibleN.Count;
        }
        public static void AppleAndOrange(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            int appleCount = 0;
            int orangeCount = 0;
            for (int i = 0; i < apples.Count; i++)
            {
                if (apples[i] >= -100000 && apples[i] <= 100000)
                {
                    int distance = a + apples[i];
                    if (distance >= s && distance <= t) appleCount++;
                }
            }
            for (int i = 0; i < oranges.Count; i++)
            {
                if (oranges[i] >= -100000 && oranges[i] <= 100000)
                {
                    int distance = b + oranges[i];
                    if (distance >= s && distance <= t) orangeCount++;
                }
            }
            Console.WriteLine(appleCount);
            Console.WriteLine(orangeCount);
        }
        public static int NOTCORRECTTITLE(List<int> a)
        {
            int[] arr = a.ToArray();
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int temp = 0;
                Array.Sort(arr);    //The important part is the pre-sort of the array
                                    //  This makes it easier to count the max number of ints in 
                                    //  a row that are 1 number apart 
                for (int j = i; j < arr.Length; j++)
                {
                    if (Math.Abs(arr[i] - arr[j]) <= 1) temp++;
                    else break;
                }
                if (temp > max) max = temp;
            }
            return max;
        }
        public static string DayOfTheProgrammer(int year)
        {
            string time;
            if (year >= 1700 && year <= 1917)
            {
                time = year % 4 == 0 ? "12.09." : "13.09.";
                return time + year.ToString();

            }
            else if (year >= 1919 && year <= 2700)
            {
                time = (year % 400 == 0 || (year % 4 == 0) && (year % 100 != 0)) ? "12.09." : "13.09.";
                return time + year.ToString();
            }
            else
            {
                return "26.09." + year.ToString();

            }
        }
        public static List<int> CircularArrayRotation(List<int> a, int k, List<int> queries)
        {          
            int arr_count = a.Count;
            int minimizedRotations = k % arr_count;  //Reduce rotations to less then one complete rotation
            int rotateRange = arr_count - minimizedRotations;

            List<int> ls = new List<int>(a.GetRange(0, rotateRange));
            a.RemoveRange(0, rotateRange);
            a.AddRange(ls);
            
            var qs = new int[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                qs[i] = a[queries[i]];
            }
            return qs.ToList();
        }
        public static List<int> PermutationEquation(List<int> p)
        {
            Dictionary<int , int> valueIndexPairs = new Dictionary<int, int>(p.Count);
            for(int x = 0; x < p.Count; x++)
            {
                valueIndexPairs.Add(p[x], x);
            }
            int[] indexValue = new int[p.Count];
            for ( int x = 1; x <= p.Count; x++)
            {
                indexValue[x-1] = valueIndexPairs[valueIndexPairs[x] + 1] +1;
            }
            return indexValue.ToList();
        }
        public static int JumpingOnClouds(int[] c, int k)
        {
            int n = c.Length;
            int energy = 100;
            for(int i = 0; i < n;)
            {
                i = (i + k) % n;
                if (c[i] == 1){ energy -= 3; }
                else{ energy -= 1; }

                if(i == 0) break;
            }
            return energy;
        }
        public static int FindDigits(int n)
        {
            int count = 0;
            int temp = n;
            int digit = 0;

            while(n != 0)
            {
                digit = n%10;
                n = n/10;
                if(digit == 0) continue;
                if(temp%digit == 0) count++;
            }
            return count;
        }
        public static BigInteger getFactorial(int n)
        {
            if(n == 1) return n;
            return n * getFactorial(n-1);
        }
        public static void ExtraLongFactorials(int n)
        {
            BigInteger assigned = getFactorial(n);
            Console.WriteLine(assigned.ToString());
        }
        public static string AppendAndDelete(string s, string t, int k)
        {   
            int sIdx = 0, tIdx = 0;
            while(sIdx < s.Length && tIdx < t.Length)
            {
                if (s[sIdx] == t[tIdx])
                {
                    sIdx++;
                    tIdx++;
                }
                else
                {
                    break;
                }
            }

            int minOperationsNeeded = s.Length - sIdx + t.Length - tIdx;
            if(k < minOperationsNeeded) return "No";
            
            if(k >= s.Length + t.Length) return "Yes";

            if ((k - minOperationsNeeded) % 2 == 0) return "Yes";
            
            return "No";
        }
        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            //If book is returned on or before expected return date ----> Fine = 0
            //If book is returned after the expected return date but within same calendar month and year
            //      ------> Fine = 15 Hackos * number of days late
            //If book is returned after the expected return month but still within the same caledar year
            //  as expected return date -----> Fine = 500 Hackos * the number of months late
            //If book is returned after the calendar year in which it was expected ----> Fixed Fine = 10000 Hackos


            DateTime returnDate = new DateTime(y1, m1, d1);
            DateTime expectedReturnDate = new DateTime(y2, m2, d2);

            TimeSpan ts = returnDate - expectedReturnDate;
            Console.WriteLine(ts.Days);
            
            //Return on or Before Due Date (-Days)
            if(returnDate <= expectedReturnDate)
            {
                return 0;
            }

            //Returned After date but withing same calendar month and year
            if(returnDate.Month == expectedReturnDate.Month && returnDate.Year == expectedReturnDate.Year)
            {
                return 15*ts.Days;
            }else if(returnDate.Month > expectedReturnDate.Month && returnDate.Year == expectedReturnDate.Year){
                return 500 * (returnDate.Month - expectedReturnDate.Month);
            }
            else
            {
                return 10000;
            }
        }
        public static List<int> CutTheSticks(List<int> arr)
        {
            List<int> operationSeries = new List<int>();
            int operations = 0;
            int zeroCount = 0;
            while(zeroCount != arr.Count)
            {
                int minValue = arr.Where(x => x != 0).Min();
                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i] == 0){
                        continue;
                    }else if(arr[i] - minValue == 0)
                    {
                        arr[i] -= minValue;
                        operations++;
                        zeroCount++;
                    }
                    else
                    {
                        arr[i] -= minValue;
                        operations++;
                    }
                }
                if (operations != 0) {
                    operationSeries.Add(operations);
                    operations = 0;
                }
                else
                {
                    break;
                }

            }
            return operationSeries;
            
        }
        public static int SherlockAndSquares(int a, int b)
        {
            int squareCount = 0;
            int i = (int)Math.Sqrt(a);
            int endsqure = (int)Math.Sqrt(b)+1;
            for(; i <= endsqure; i++) 
            {
                if(Math.Pow(i, 2) >= a && Math.Pow(i,2) <= b) squareCount++;
            }
            return squareCount;
        }

        public static int NonDivisibleSubset(int k, List<int> s)
        {
            List<int> temp = new List<int>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < s.Count; i++)
            {
                int val = s[i]%k;
                if (!map.ContainsKey(val))
                {
                    map.Add(val, 1);
                }
                else
                {
                    map[val] += 1;
                }
            }
            return 1;
        }

    }
}
