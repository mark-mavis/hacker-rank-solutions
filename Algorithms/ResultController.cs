using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Result
{
    public class ResultController
    {
        public static void BetweenTwoSets()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

            int total = Result.BetweenTwoSets(arr, brr);
        }
        public static void AppleAndOrange()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int s = Convert.ToInt32(firstMultipleInput[0]);

            int t = Convert.ToInt32(firstMultipleInput[1]);

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int a = Convert.ToInt32(secondMultipleInput[0]);

            int b = Convert.ToInt32(secondMultipleInput[1]);

            string[] thirdMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int m = Convert.ToInt32(thirdMultipleInput[0]);

            int n = Convert.ToInt32(thirdMultipleInput[1]);

            List<int> apples = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(applesTemp => Convert.ToInt32(applesTemp)).ToList();

            List<int> oranges = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(orangesTemp => Convert.ToInt32(orangesTemp)).ToList();

            Result.AppleAndOrange(s, t, a, b, apples, oranges);
        }
        public static void NOTCORRECTTITLE()
        {
            Result.NOTCORRECTTITLE(new List<int>() { 1, 1, 2, 2, 4, 4, 5, 5, 5 });
        }
        public static void DayOfTheProgrammer()
        {
            int year = Convert.ToInt32(Console.ReadLine().Trim());
            string result = Result.DayOfTheProgrammer(year);
        }
        public static void CircularArrayRotation()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            int q = Convert.ToInt32(firstMultipleInput[2]);

            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

            List<int> queries = new List<int>();

            for (int i = 0; i < q; i++)
            {
                int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
                queries.Add(queriesItem);
            }

            List<int> result = Result.CircularArrayRotation(a, k, queries);
        }
        public static void SequenceEquation()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> p = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(pTemp => Convert.ToInt32(pTemp)).ToList();

            List<int> result = Result.PermutationEquation(p);
        }
        public static void JumpingOnTheClouds()
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
            ;
            int result = Result.JumpingOnClouds(c, k);
        }
        public static void FindDigits()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                int result = Result.FindDigits(n);
            }
        }
        public static void ExtraLongFactorials()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            Result.ExtraLongFactorials(n);
        }
        public static void AppendAndDelete()
        {
            string s = Console.ReadLine();

            string t = Console.ReadLine();

            int k = Convert.ToInt32(Console.ReadLine().Trim());

            string result = Result.AppendAndDelete(s, t, k);

        }
        public static void LibraryFine()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d1 = Convert.ToInt32(firstMultipleInput[0]);

            int m1 = Convert.ToInt32(firstMultipleInput[1]);

            int y1 = Convert.ToInt32(firstMultipleInput[2]);

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d2 = Convert.ToInt32(secondMultipleInput[0]);

            int m2 = Convert.ToInt32(secondMultipleInput[1]);

            int y2 = Convert.ToInt32(secondMultipleInput[2]);

            int result = Result.libraryFine(d1, m1, y1, d2, m2, y2);
        }
        public static void CutTheSticks()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.CutTheSticks(arr);
        }
        public static void SherlockAndSquares()
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

                int a = Convert.ToInt32(firstMultipleInput[0]);

                int b = Convert.ToInt32(firstMultipleInput[1]);

                int result = Result.SherlockAndSquares(a, b);
            }
        }
    }

}
