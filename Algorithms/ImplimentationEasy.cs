using System;
using System.Collections.Generic;
using Algorithms.Result;

namespace Algorithms
{
    public class ListCreator
    {
        public static List<int> ReturnList(int size)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();

            for(int i = 0; i < size; i++)
            {
                list.Add(rnd.Next());
            }

            return list;
        }
    }
    public class ImplementationEasy
    {
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
        public static void CountApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
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
        public static int DayOfTheProgrammer(List<int> a)
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
        public static int DrawingBook(int n, int p)
        {
            return Math.Min((n / 2 - p / 2), (p / 2));
        }
        public static List<int> GradingStudents(List<int> grades)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                int grade = grades[i];
                int next_multple = (grade / 5) + 1;

                if (grade < 38)
                {
                    grades[i] = grade;
                }
                else if ((5 * next_multple) - grade < 3)
                {
                    grades[i] = 5 * next_multple;
                }
            }
            return grades;
        }
        public static string NumberLineJumps(int x1, int v1, int x2, int v2)
        {
            //For loop represents the jumps
            for (int i = 0; i < 100000; i++)
            {
                x1 += v1;
                x2 += v2;
                Console.WriteLine($"Difference: {x1 - x2}");
                if (x1 == x2) return "YES";
            }
            return "NO";
        }
        public static List<int> BreakingTheRecords(List<int> scores)
        {
            int minCount = 0;
            int maxCount = 0;
            int min = scores[0];
            int max = scores[0];
            for (int i = 0; i < scores.Count; i++)
            {
                if (scores[i] < min)
                {
                    minCount++;
                    min = scores[i];
                }
                if (scores[i] > max)
                {
                    maxCount++;
                    max = scores[i];
                }
            }
            List<int> result = new List<int>() { maxCount, minCount };
            return result;
        }
        public static int SubarrayDivision(List<int> s, int d, int m)
        {
            int count = 0;
            for (int i = 0; i < s.Count - (m - 1); i++)
            {
                int sum = 0;
                for (int j = i; j < (i + m); j++)
                {
                    sum += s[j];
                }
                if (sum == d)
                {
                    count++;
                }
            }
            return count;
        }
        public static int DivisibleSumPairs(int n, int k, List<int> ar)
        {
            //ar - list of integers
            //k - 
            // Where i < j && ar[i] + ar[j] % k ==0
            int count = 0;
            for (int i = 0; i < ar.Count; i++)
            {
                for (int j = i; j < ar.Count; j++)
                {
                    if (i != j)
                    {
                        if ((ar[i] + ar[j]) % k == 0) count++;
                    }
                }
            }
            return count;
        }
        public static int MigratoryBirds(List<int> arr)
        {
            if (arr.Count >= 5 && arr.Count <= 1000000)
            {
                int[] types = new int[6];

                for (int i = 0; i < arr.Count; i++)
                {
                    types[arr[i]]++;
                }
                List<int> btypes = types.ToList();
                return btypes.IndexOf(types.Max());
            }
            return 1;
        }
        public static void BillDivision(List<int> bill, int k, int b)
        {
            int sum = 0;
            for (int i = 0; i < bill.Count; i++)
            {
                if (i != k) sum += bill[i];
            }
            if (sum / 2 - b != 0)
            {
                Console.WriteLine(Math.Abs(sum / 2 - b));
            }
            else
            {
                Console.WriteLine("Bon Appetit");
            }

        }
        public static int SalesByMatch(int n, List<int> ar)
        {
            int[] arr = new int[ar.Max() + 1];
            for (int i = 0; i < ar.Count; i++)
            {
                arr[ar[i]]++;
            }
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    arr[i] = arr[i] / 2;
                    sum += arr[i];
                }
            }
            return sum;
        }
        public static int CountingValleys(int steps, string path)
        {
            int elevation = 0;
            bool traversingvalley = false;
            int valleystraversed = 0;

            for (int i = 0; i < path.Length; i++)
            {
                switch (path[i])
                {
                    case 'U':
                        elevation++;
                        break;
                    case 'D':
                        elevation--;
                        break;
                }

                if (elevation < 0)
                {
                    traversingvalley = true;
                }
                else if (elevation == 0 && traversingvalley == true)
                {
                    valleystraversed++;
                    traversingvalley = false;
                }
                else
                {
                    continue;
                }
            }
            return valleystraversed;
        }
        public static int ElectronicsShop(int[] keyboards, int[] drives, int b)
        {
            int maxKeyboardVal = 0;
            int maxDriveVal = 0;
            int currMaxSum = 0;

            for (int i = 0; i < keyboards.Length; i++)
            {
                //if(keyboards[i] >= b) return -1;

                for (int j = 0; j < drives.Length; j++)
                {
                    if (b >= keyboards[i] + drives[j])
                    {
                        int tempSum = keyboards[i] + drives[j];
                        if (tempSum > currMaxSum)
                        {
                            currMaxSum = tempSum;
                            maxKeyboardVal = keyboards[i];
                            maxDriveVal = drives[j];
                        }
                    }
                }
            }

            if (currMaxSum == 0)
            {
                return -1;
            }
            else
            {
                return currMaxSum;
            }

        }
        public static string CatAndMouse(int x, int y, int z)
        {
            int catADist = Math.Abs(z - x);
            int catBDist = Math.Abs(z - y);
            if (catADist == catBDist) return "Mouse C";
            return catADist < catBDist ? "Cat A" : "Cat B";
        }
        public static int PickingNumbers(List<int> a)
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
        public static int HurdleRace(int k, List<int> height)
        {
            //k - the height the player can initially jump
            //height - hurtle heights
            if ((height.Count >= 1 && height.Count <= 100) && (k >= 1 && k <= 100))
            {
                //return potions needed
                int potions = 0;

                for (int i = 0; i < height.Count; i++)
                {
                    if (height[i] >= 1 && height[i] <= 100)
                    {
                        if (height[i] - k <= 0) continue;
                        if (height[i] - k > 0)
                        {
                            potions += height[i] - k;
                            k += potions;
                        }
                    }
                }
                return potions;
            }
            return 0;
        }
        public static int DesignerPdfViewer(List<int> h, string word)
        {
            int sum = 0;
            int max = 0;

            word = word.ToLower();
            foreach (char c in word)
            {
                int idx = c - 97;
                int val = h[idx];
                max = Math.Max(max, val);
                sum += h[idx];
            }
            return sum * max;
        }
        public static void AngryProfessor(int k, List<int> a)
        {
            if (a.Count <= 1000 && a.Count >= 1)
            {
                a.Sort();
                if (a[k - 1] <= 0) Console.WriteLine("NO");
            }
            Console.WriteLine("YES");   //Class is cancelled
        }
        public static int UtopianTree(int n)
        {
            bool spring = true;
            bool summer = false;

            int height = 1;

            for (int i = 0; i < n; i++)
            {
                if (spring)
                {
                    height *= 2;
                    spring = false;
                    summer = true;
                    continue;
                }
                if (summer)
                {
                    height += 1;
                    summer = false;
                    spring = true;
                    continue;
                }
            }
            return height;
        }
        public static int BeautifulDays(int i, int j, int k)
        {
            int numBeautifulDays = 0;            
            for(int c = i; c <= j; c++)
            {
                var reverseString = new string(c.ToString().Reverse().ToArray());
                var reverseNumber = int.Parse(reverseString);
                var d = Math.Abs(c - reverseNumber);
                var r = d % k;

                if (r == 0)
                    numBeautifulDays++;
            }
            return numBeautifulDays;
            
            
            // i - the starting day number
            // j - the ending day number
            // k - the divisor

            // Returns - Number of days in the range

        }
        public static int ViralAdvertising(int n)
        {
            // n = number of days
            // recipients/2 * 3 = Likedshares
            // i = 0, 
            // i = 1, 5/2 = 2*3 = 6
            // i = 2, 6/2 = 3*3 = 9
            // i = 3, 9/2 = 4*3 = 12
            // i = 4, 12/2 = 6*3 = 18
            // i = 5, 18/2 = 9*3 = 24
            // i = 6, 24/2 = 12*3 = 36
            // i = 7, 36/2 = 18*3 = 54
            // i = 8, 54/2 = 27*3 = 81

            int currRecipients = 5;
            int cumulativeLikes = 0;

            for(int i = 1; i <= n; i++)
            {
                int likes = currRecipients / 2;
                currRecipients = likes*3;
                cumulativeLikes += likes;
            }
            return cumulativeLikes;  
        }
        public static int SaveThePrisoner(int n, int m, int s)
        {
            // n - prisoners
            // m - pieces of candy
            // s - starting chair
            if (PrisonerInputValidatation(n, m, s))
            {
                int prisonerSeat = m % n;
                if((prisonerSeat + (s - 1)) % n == 0) return n;
                else return (prisonerSeat + (s - 1)) % n;
            }
            return 0;
        }
        private static bool PrisonerInputValidatation(int n, int m, int s)
        {
            return (n>=1 && n<=10000000000) && (m >= 1 && m <= 10000000000) && (s>= 1 && n >= s);
        }
        public static List<int> CircularArrayRotation(List<int> a, int k, List<int> queries)
        {
            int[] arr = a.ToArray();

            int temp, prev;
            for (int i = 0; i < k; i++)
            {
                prev = a[a.Count - 1]; //Copy the element at the end of the arrary
                for (int j = 0; j < a.Count; j++)
                {
                    temp = a[j];    //Copy the element at J in the array to Temp
                    a[j] = prev;    //assign the copied end value
                    prev = temp;    //assign the temp o the previous
                }
            }

            List<int> ints = new List<int>();
            foreach(int i in queries)
            {
                ints.Add(a[i]);
            }
           
            return ints;
        }

    }


    class ImplementationEasyController
    {
        public static void Run()
        {
            //ImplementationEasy.DrawingBook(6, 2);

            //ImplementationEasy.GradingStudents(new List<int>() { 73, 67, 38, 33 });
            
            //Implementation.CountApplesAndOranges()
            
            //ImplementationEasy.NumberLineJumps(1571, 4240, 9023, 4234);

            //ImplementationEasy.BetweenTwoSets(new List<int>() { 2, 4 }, new List<int>() { 16, 32, 96 });

            //ImplementationEasy.BreakingTheRecords(new List<int>() { 10, 5, 20, 20, 4, 5, 2, 25, 1 });

            //ImplementationEasy.SubarrayDivision(new List<int>() { 2, 2, 1, 3, 2 }, 4, 2);
            //ImplementationEasy.SubarrayDivision(new List<int>() { 4, 1 }, 4, 1);

            //ImplementationEasy.DivisibleSumPairs(6, 3, new List<int>() { 1, 3, 2, 6, 1, 2 });

            //ImplementationEasy.MigratoryBirds(new List<int>() { 1, 1, 2, 2, 3 });
            //ImplementationEasy.MigratoryBirds(new List<int>() { 1, 4, 4, 4, 5, 3 });

            //ImplementationEasy.DayOfTheProgrammer(new List<int>() { 1, 1, 2, 2, 4, 4, 5, 5, 5 });
            //ImplementationEasy.DayOfTheProgrammer(new List<int>() { 4, 6, 5, 3, 3, 1 });

            //ImplementationEasy.BillDivision(new List<int>() { 3, 10, 2, 9 }, 1, 12);
            //ImplementationEasy.BillDivision(new List<int>() { 3, 10, 2, 9 }, 1, 7);

            //ImplementationEasy.SalesByMatch(new List<int>() { 1, 2, 1, 2, 1, 3, 2 }.Count, new List<int>() { 1, 2, 1, 2, 1, 3, 2 });
            //ImplementationEasy.CountingValleys(8, "UDDDUDUU");

            //int[] keyboards = new int[] { 3, 1 };
            //int[] drives = new int[] { 5, 2, 8 };
            //ImplementationEasy.ElectronicsShop(keyboards, drives, 10);

            //Console.WriteLine(ImplementationEasy.CatAndMouse(1, 2, 3));
            //Console.WriteLine(ImplementationEasy.CatAndMouse(1, 3, 2));

            //ImplementationEasy.PickingNumbers(new List<int>() { 1, 1, 2, 2, 4, 4, 5, 5, 5 });
            //ImplementationEasy.PickingNumbers(new List<int>() { 4, 6, 5, 3, 3, 1 });

            //List<int> heights = new List<int>() { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            //ImplementationEasy.DesignerPdfViewer(heights, "abc");

            //List<int> arrivalTime = new List<int>() { -1, -3, 4, 2 };
            //ImplementationEasy.AngryProfessor(3, arrivalTime);

            //arrivalTime = new List<int>() { 0, -1, 2, 1 };
            //ImplementationEasy.AngryProfessor(2, arrivalTime);

            //arrivalTime = new List<int>() { -93, -86, 49, -62, -90, -63, 40, 72, 11, 67 };
            //ImplementationEasy.AngryProfessor(4, arrivalTime);

            //arrivalTime = new List<int>() { 23, -35, -2, 58, -67, -56, -42, -73, -19, 37 };
            //ImplementationEasy.AngryProfessor(10, arrivalTime);

            //arrivalTime = new List<int>() { 13, 91, 56, -62, 96, -5, -84, -36, -46, -13 };
            //ImplementationEasy.AngryProfessor(9, arrivalTime);

            //ImplementationEasy.UtopianTree(2);
            //ImplementationEasy.UtopianTree(10);

            //ImplementationEasy.BeautifulDays(123, 456789, 189);

            //Console.WriteLine(ImplementationEasy.ViralAdvertising(5));
            //Console.WriteLine(ImplementationEasy.SaveThePrisoner(5, 2, 1));
            //Console.WriteLine(ImplementationEasy.SaveThePrisoner(352926151, 380324688, 94730870));
            //Console.WriteLine(ImplementationEasy.CircularArrayRotation(new List<int>() { 3, 4, 5}, 2, new List<int>() { 1, 2}));



            Console.ReadLine();
            
        }
    }
}
