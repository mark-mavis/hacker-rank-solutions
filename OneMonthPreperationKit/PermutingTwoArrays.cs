using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMonthPreperationKit
{
    class PermutingTwoArrays
    {
        public static string TwoArrays(int k, List<int> A, List<int> B)
        {
            if ((k > 1000000000 || k < 1) || (A.Count > 1000 || A.Count < 1)) return "NO";

            A.Sort((A, B) => A.CompareTo(B)); // ascending sort
            B.Sort((A, B) => B.CompareTo(A)); // descending sort

            for (int i = 0; i < A.Count; i++)
            {
                //Console.WriteLine(A[i] + "+" + B[i]);
                if (A[i] + B[i] < k) return "NO";
            }
            return "YES";
        }

        public static void Run()
        {
            List<int> A = new List<int> { 2, 1, 3 };
            List<int> B = new List<int> { 7, 8, 9 };
            Console.WriteLine(TwoArrays(10, A, B));

            List<int> C = new List<int> { 1, 2, 2, 1 };
            List<int> D = new List<int> { 3, 3, 3, 4 };
            Console.WriteLine(TwoArrays(5, C, D));

        }

    }
}
