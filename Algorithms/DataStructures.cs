using Algorithms.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Arrays { 
        public static int HourGlassSum(List<List<int>> arr)
        {
            int MaxSum = Int32.MinValue;
            for (int i_idx = 0; i_idx < arr.Count - 2; i_idx++)
            {
                for (int j_idx = 0; j_idx < arr[i_idx].Count - 2; j_idx++)
                {
                    int upperSum = arr[i_idx][j_idx] + arr[i_idx][j_idx + 1] + arr[i_idx][j_idx + 2];
                    int middleSum = arr[i_idx + 1][j_idx + 1];
                    int bottomSum = arr[i_idx + 2][j_idx] + arr[i_idx + 2][j_idx + 1] + arr[i_idx + 2 ][j_idx + 2];
                    int totalSum = upperSum + middleSum + bottomSum;
                    arr[i_idx][j_idx] = totalSum;
                    if (totalSum > MaxSum) MaxSum = totalSum;
                }
            }
            return MaxSum;
        }
        public static List<int> DynamicArray(int n, List<List<int>> queries)
        {
            List<List<int>> arr = new List<List<int>>();
            
            for(int i = 0; i < n; i++)
            {
                arr.Add(new List<int>());   // Pushing N number of Empty List<int> to the List
            }

            List<int> lastAnswers = new List<int>();
    
            int lastAnswer = 0;
            foreach(List<int> query in queries)
            {
                int queryType = query[0];   // Get Query Type

                int idx = ((query[1] ^ lastAnswer) % n);    // Get Index
                if (queryType == 1) arr[idx].Add(query[2]);
                else
                {
                    lastAnswer = arr[idx][query[2] % arr[idx].Count];
                    lastAnswers.Add(lastAnswer);
                }
            }
            return lastAnswers;
        }
        public static List<int> RotateLeft(int d, List<int> arr)
        {
            int rotations = d % arr.Count;
            List<int> temp = arr.GetRange(0, rotations);
            arr.RemoveRange(0,rotations);
            arr.AddRange(temp);
            return arr;
        }
        public static List<int> MatchingStrings(List<string> stringList, List<string> queries)
        {
            List<int> results = new List<int>();
            foreach (string query in queries)
            {
                results.Add(stringList.Count(str => str == query));
            }

            return results;
        }
    }
    public class ArraysController { 
    
        public static void HourGlassSum()
        {
            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < 6; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = Arrays.HourGlassSum(arr);
        }
        public static void DynamicArray()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = Arrays.DynamicArray(n, queries);
        }
        public static void LeftRotation()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int d = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Arrays.RotateLeft(d, arr);
        }
        public static void SparesArrays()
        {
            int stringListCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> stringList = new List<string>();

            for (int i = 0; i < stringListCount; i++)
            {
                string stringListItem = Console.ReadLine();
                stringList.Add(stringListItem);
            }

            int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> queries = new List<string>();

            for (int i = 0; i < queriesCount; i++)
            {
                string queriesItem = Console.ReadLine();
                queries.Add(queriesItem);
            }

            List<int> res = Arrays.MatchingStrings(stringList, queries);
        }
    }

}
