using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1
{
    class MockTest
    {
        public static int findMedian(List<int> arr)
        {
            arr.Sort((A, B) => A.CompareTo(B));

            return arr[(arr.Count)/2];
        }

        /*
        public static int flippingthematrix(List<List<int>> arr)
        {
            int n = arr.Count/2;

            for(int i = 0; i < n; i++)
            {
                for(int j =0; j<n;j++)
                {
                    int s = Math.Max(arr[i][j], arr[i][n-i-1]);
                    int p = Math.Max(arr[n-j-1]arr[n - i - 1][n - j - 1]);
                }
            }
        }
        */
        public static void RunProgram()
        {
            List<List<int>> arr = new List<List<int>>()
            {
               new List<int>(){112, 42, 83, 119 },
               new List<int>(){56, 125, 56, 49 },
               new List<int>(){15, 78, 101, 43},
               new List<int>(){62, 98, 114, 108 }
            };

            //Console.WriteLine(findMedian(arr));
            //Console.WriteLine(flippingthematrix(arr));

        }
    }
}
