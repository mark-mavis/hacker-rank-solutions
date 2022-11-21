using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given an array of integers, where all elements but one occur 
 * twice, find the unique element.
 */
namespace OneMonthPreperationKit
{
    class LonelyInteger
    {
        //get first value to find
        //search for a duplicate of value in List
        // if found - remove all istances of that number


        public static int RunLonelyIntegar(List<int> a)
        {
            List<int> searchedItems = new List<int>();
            bool dup_notfound = true;
            for(int i = 0; i < a.Count; i++)
            {
                dup_notfound = true;
                if (!searchedItems.Contains(a[i]))
                {
                    searchedItems.Add(a[i]);
                    for (int j = i; j < a.Count; j++)
                    {
                        if (a[j] == a[i] && i != j)
                        {
                            dup_notfound = false;
                            break;
                        }
                    }
                    if (dup_notfound || i == a.Count - 1) return a[i];
                }
            }
            return 0;
        }

        public static void Run()
        {
            List<int> a = new List<int>() { 0, 3, 0, 3, 1, 1, 2};
            Console.WriteLine(RunLonelyIntegar(a));
        }
    }
}
