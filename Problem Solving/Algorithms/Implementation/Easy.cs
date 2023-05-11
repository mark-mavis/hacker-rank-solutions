
using System.IO;
using System.Security;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms;

class Input
{
    public static string ReadLine()
    {
        string? user_input = Console.ReadLine();
        if (!String.IsNullOrEmpty(user_input))
        {
            return user_input;
        }
        else
        {
            throw new ArgumentNullException("Please enter an input");
        }
    }
}

public partial class Implementation
{
    //EASY IMPLEMENTATIONS
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
    public static int DrawingBook(int n, int p)
    {
        return Math.Min((n / 2 - p / 2), (p / 2));
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
    public static int TheHurdleRace(int k, List<int> height)
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
    public static string AngryProfessor(int k, List<int> a)
    {
        if (a.Count <= 1000 && a.Count >= 1)
        {
            if (a.Count <= 1000 && a.Count >= 1)
            {
                a.Sort();
                if (a[k - 1] <= 0) return "NO";
            }
        }
        return "YES";   //Class is cancelled
    }
    public static int BeautifulDaysAtTheMovies(int i, int j, int k)
    {
        int numBeautifulDays = 0;
        for (int c = i; c <= j; c++)
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

        for (int i = 1; i <= n; i++)
        {
            int likes = currRecipients / 2;
            currRecipients = likes * 3;
            cumulativeLikes += likes;
        }
        return cumulativeLikes;
    }
    public static int SaveThePrisoner(int n, int m, int s)
    {
        int prisonerSeat = m % n;
        if ((prisonerSeat + (s - 1)) % n == 0) return n;
        else return (prisonerSeat + (s - 1)) % n;   
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
    public static List<int> CircularArrayRotation2(List<int> a, int k, List<int> queries)
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
        foreach (int i in queries)
        {
            ints.Add(a[i]);
        }

        return ints;
    }
    public static List<int> SequenceEquation(List<int> p)
    {
        Dictionary<int, int> valueIndexPairs = new Dictionary<int, int>(p.Count);
        for (int x = 0; x < p.Count; x++)
        {
            valueIndexPairs.Add(p[x], x);
        }
        int[] indexValue = new int[p.Count];
        for (int x = 1; x <= p.Count; x++)
        {
            indexValue[x - 1] = valueIndexPairs[valueIndexPairs[x] + 1] + 1;
        }
        return indexValue.ToList();
    }
    public static int JumpingOnClouds(List<int> c)
    {
        int count = 0;
        for (int i = 0; i < c.Count - 1;)
        {
            if (i + 2 < c.Count && c[i + 2] == 0)
            {
                i += 2;
                count++;
            }
            else if (i + 1 < c.Count && c[i + 1] == 0)
            {
                i += 1;
                count++;
            }
            else
            {
                return count;
            }
        }
        return count;
    }
    public static int FindDigits(int n)
    {
        int count = 0;
        int temp = n;
        int digit = 0;

        while (n != 0)
        {
            digit = n % 10;
            n = n / 10;
            if (digit == 0) continue;
            if (temp % digit == 0) count++;
        }
        return count;
    }
    public static string AppendAndDelete(string s, string t, int k)
    {
        int sIdx = 0, tIdx = 0;
        while (sIdx < s.Length && tIdx < t.Length)
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
        if (k < minOperationsNeeded) return "No";

        if (k >= s.Length + t.Length) return "Yes";

        if ((k - minOperationsNeeded) % 2 == 0) return "Yes";

        return "No";
    }
    public static int SherlockAndSquares(int a, int b)
    {
        int squareCount = 0;
        int i = (int)Math.Sqrt(a);
        int endsqure = (int)Math.Sqrt(b) + 1;
        for (; i <= endsqure; i++)
        {
            if (Math.Pow(i, 2) >= a && Math.Pow(i, 2) <= b) squareCount++;
        }
        return squareCount;
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
        if (returnDate <= expectedReturnDate)
        {
            return 0;
        }

        //Returned After date but withing same calendar month and year
        if (returnDate.Month == expectedReturnDate.Month && returnDate.Year == expectedReturnDate.Year)
        {
            return 15 * ts.Days;
        }
        else if (returnDate.Month > expectedReturnDate.Month && returnDate.Year == expectedReturnDate.Year)
        {
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
        while (zeroCount != arr.Count)
        {
            int minValue = arr.Where(x => x != 0).Min();
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == 0)
                {
                    continue;
                }
                else if (arr[i] - minValue == 0)
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
            if (operations != 0)
            {
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
    public static long RepeatedString(string s, long n)
    {
        long count = s.Count(ch => ch == 'a');

        if (s.Length <= n)
        {
            long fullScans = n / (long)s.Length;
            count *= fullScans;
            long idx = n % (long)s.Length;
            count += s.Substring(0, (int)idx).Count(ch => ch == 'a');
        }
        else
        {
            count = s.Substring(0, (int)n).Count(ch => ch == 'a');
        }
        return count;
    }
    public static int EqualizeArray(List<int> arr)
    {
        var mostCommonNumber = arr.GroupBy(n => n).OrderByDescending(g => g.Count()).First().Key;
        return arr.Count(n => n != mostCommonNumber);
    }
    public static List<int> ACMTeam(List<string> topic)
    {
        List<int> subjectList = new List<int>();
        for (int i = 0; i < topic.Count; i++)
        {

            for (int j = i; j < topic.Count; j++)
            {
                int Subjects = 0;
                if (i == j) continue;
                for (int k = 0; k < topic[i].Length; k++)
                {
                    if (topic[i][k] != '0' || topic[j][k] != '0')
                    {
                        Subjects++;
                    }
                }
                subjectList.Add(Subjects);
            }
        }
        int maxSubjects = subjectList.Max();
        int maxSubjectsCount = subjectList.Count(val => val == maxSubjects);
        return new List<int> { maxSubjects, maxSubjectsCount };
    }
    public static long TaumBday(int b, int w, int bc, int wc, int z)
    {
        //b  = number of black gifts
        //bc = cost of a black gift
        //w  = number of white gifts
        //wc = cost of a white gift
        // (b * bc) + (w * wc) = cost
        // bc = wc + z
        // wc = bc + z

        //Whats the minimal cost of obtaining the desired gifts.

        // Cheapest way to buy 10 black and 10 white
        //  when black $ = 1 white $ = 1 Conversion $ = 1

        // Black Gifts -> if White + Conversion is less, but all black gifts as white and convert
        //      else buy black gifts

        long bConverted = wc + z;
        long wConverted = bc + z;

        long minWC = Math.Min(wc, wConverted);
        long minBC = Math.Min(bc, bConverted);

        long cost = b * (minBC) + w * (minWC);

        return cost;
    }
    public static void ModifiedKaprekarNumbers(int p, int q)
    {
        bool isValid = false;
        for (; p <= q; p++)
        {
            string strValue = Math.Pow(p, 2).ToString();
            if (strValue.Length == 1)
            {
                if (Convert.ToInt32(strValue) == p)
                {
                    Console.Write(p + " ");
                    isValid = true;
                }
            }
            else
            {
                int middleIdx = strValue.Length / 2;
                int right = Convert.ToInt32(strValue.Substring(middleIdx, strValue.Length - middleIdx));
                int left = Convert.ToInt32(strValue.Substring(0, middleIdx));
                int sum = left + right;
                if (sum == p)
                {
                    Console.Write(p + " ");
                    isValid = true;
                }
            }
        }
        if (!isValid)
        {
            Console.WriteLine("INVALID RANGE");
        }
    }
    public static int MinimumDistances(List<int> a)
    {
        List<int> distances = new List<int>();

        for (int i = 0; i < a.Count; i++)
        {
            for (int j = i + 1; j < a.Count; j++)
            {
                if (a[i] == a[j])
                {
                    distances.Add(Math.Abs(i - j));
                }
            }
        }

        if (distances.Count > 0)
        {
            return distances.Min();
        }
        return -1;
    }
    public static int HalloweenSale(int p, int d, int m, int s)
    {
        //p = price of first game
        //d = declining price
        //m = bottom price
        //s = starting budget
        //Halloween sale --> first game cost p
        //               --> every previous game d less than the previous
        //               --> continues until cost is <= m dollars, after which, every game will be m dollars

        int gameCount = 0;
        int currentCost = p;
        int minCost = m;

        //While we have money left for a game, 
        // Have money for game
        while (s >= currentCost)
        {
            //Buy game
            gameCount++;
            s -= currentCost;

            if (currentCost - d <= minCost)
            {
                currentCost = minCost;
            }
            else
            {
                currentCost -= d;       //Purchase Game
            }
        }
        return gameCount;

    }
    public static int ChocolateFeast(int cash, int costOfChocolate, int wrapperTradeValue)
    {
        // N = dollars
        // C = dollars per chocolate
        // M = wrappers per chocolate
        // W = wrappers per dollar
 
        int wrapper = cash/costOfChocolate;
        int chocolate = wrapper;
        while(wrapper >= wrapperTradeValue)
        {
            int extra_chocolate = wrapper/wrapperTradeValue;
            wrapper = extra_chocolate + wrapper % wrapperTradeValue;
            chocolate += extra_chocolate;
        }

        return chocolate;
    }
    public static List<int> ServiceLane(int n, List<List<int>> cases, List<int> width)
    {
        int[] segwidths = new int[cases.Count];
        int counter = 0;
        foreach(List<int> seg in cases)
        {
            List<int> newlist = width.GetRange(seg[0], (seg.Last()-seg.First())+1);
            segwidths[counter] = newlist.Min();
            counter++;
        }
        return segwidths.ToList();
    }
    public static int Workbook(int n, int k, List<int> arr)
    {
        // n - chapters - 1 to n
        // i - chapterCounter - arr[i]
        // k - problems per page;
        // Only last page can hold fewer then k problems
        // Chapters start on new pages/Not multiple chapters on same page
        // Page number index starts at 1

        int specialProblems = 0;
        int page = 0;
        for(int chapter = 1; chapter <= arr.Count; chapter++)
        {
            Console.WriteLine($"Chapter {chapter}");
            page++;
            Console.WriteLine($"Page {page}");

            for (int problem = 1; problem <= arr[chapter - 1]; problem++)
            {
                Console.WriteLine($"Problem {problem}");
                if (problem == page) specialProblems++;
                if (problem%k == 0 && problem != arr[chapter-1]){
                    page++;
                    Console.WriteLine($"Page {page}");
                }
            }
            Console.WriteLine($"Special Problems Found: {specialProblems}");
        }
        return specialProblems;
    }
    public static int FlatlandSpaceStations(int n, int[] c)
    {
        // First line  - n = Number of Cities m = indicies of Cities
        // Second Line - c[m] - space-seperated integers 
        /*
        int maxDistance = 0;
        if(n == c.Length) return 0;
        int count = 0;
        for(int i = c[count]; i < c.Length; count++)
        {
            for(int j = i; j < n; j++)
            {
                if(i == j) continue;
                if (c[i+1] == j)
                {
                    int distance = (j - c[i])/2;
                    if (maxDistance < distance) maxDistance = distance;
                }
            }
        }
        
        
        if (n == c.Length) return 0;
        int maxDist = 0;
        for(int city = 0; city < c.Length; city++)
        {
            for(int nextCity = city+1; nextCity < c.Length; nextCity++)
            {
                int currentDist;                
                if (Math.Abs(((decimal)c[nextCity] - (decimal)c[city]) / 2.0m) % 2.0m != 0.0m){
                    currentDist = (int)Math.Ceiling(Math.Abs((decimal)(c[nextCity] - (decimal)c[city]) / 2.0m));
                }
                else
                {
                    currentDist = Math.Abs((c[nextCity] - c[city]) / 2);
                }
                if (currentDist > maxDist) maxDist = currentDist;
                break;
            }
        }
        */


        if (n == c.Length)
            return 0;
        int count = 0, max = 0;
        bool first = true;
        for (int i = 0; i < n; i++)
        {
            if (!c.Contains(i))
            {
                count++;
            }
            else
            {
                first = false;
                count = count % 2 == 0 ? count / 2 : (count / 2) + 1;
                max = max < count ? count : max;
                count = 0;
            }
            if (first)
                max = max < count ? count : max;
        }
        max = max < count ? count : max;

        return max;
    }
    public static string FairRations(List<int> B)
    {
        int loafsHanded = 0;
        for(int i = 0; i < B.Count-1; i++)
        {
            if (B[i]%2 != 0)
            {
                B[i]++;
                loafsHanded++;
                B[i+1]++;
                loafsHanded++;
            }
        }
        if(B.Sum()%2 != 0)
        {
            return "NO";
        }
        else
        {
            return loafsHanded.ToString();
        }
        
    }
    public static List<string> CavityMap(List<string> grid)
    {
        int row_dim = grid.Count;
        int col_dim = grid.ElementAt(0).Length;

        for(int row = 0; row < row_dim; row++)
        {
            StringBuilder str = new StringBuilder(grid[row]);
            for (int col = 0; col < col_dim; col++)
            {
                
                if (row == 0 || row == col_dim - 1 || col == 0 || col == col_dim - 1)
                {
                    continue;
                }

                bool upper = grid[row - 1].ElementAt(col) < str[col] && grid[row - 1].ElementAt(col) != 'X' ? true : false;
                bool lower = grid[row + 1].ElementAt(col) < str[col] && grid[row + 1].ElementAt(col)  != 'X' ? true : false;
                bool left = grid[row].ElementAt(col-1) < str[col] && grid[row].ElementAt(col - 1)  != 'X' ? true : false;
                bool right = grid[row].ElementAt(col+1) < str[col] && grid[row].ElementAt(col + 1) != 'X' ? true : false;

                if(upper && lower && left && right)
                {
                    str[col] = 'X';
                    
                }
                else
                {
                    continue;
                }
            }

            grid[row] = str.ToString();
        }

        return grid;
    }
    public static List<int> ManasaAndStones(int n, int a, int b)
    {
        List<int> temp = new List<int>();
        
        int top = n-1;
        
        for(int i = 0; i < n; i++)
        {
            //Console.WriteLine($"i: {i} top: {top}");
            int sum = (a*i) + (b*top);
            //Console.WriteLine($"Sum: {sum}");
            if (!temp.Contains(sum))
            {
                temp.Add(sum);
            }
            top--;            
        }
        temp.Sort();

        return temp;
    }
    public static string TheGridSearch(List<string> G, List<string> P)
    {
        /*
        bool CheckPatternIsPresent(ref List<string> searchGrid, (int, int) beginningSearchPoint, ref List<string> patternGrid)
        {
            int searchGrid_row_offset = beginningSearchPoint.Item1;
            int searchGrid_col_offset = beginningSearchPoint.Item2;
            
            for(int patternGrid_RowIt = 0; patternGrid_RowIt < patternGrid.Count; patternGrid_RowIt++)
            {
                for(int patternGrid_ColIt = 0; patternGrid_ColIt < patternGrid[patternGrid_RowIt].Length; patternGrid_ColIt++)
                {
                    if (searchGrid[patternGrid_RowIt+searchGrid_row_offset].ElementAt(patternGrid_ColIt+searchGrid_col_offset) != patternGrid[patternGrid_RowIt].ElementAt(patternGrid_ColIt))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        for(int grid_row = 0; grid_row <= G.Count - P.Count; grid_row++)
        {
            //StringBuilder sb = new StringBuilder(G[row]);
            for(int grid_col = 0; grid_col <= G[grid_row].Length - P[0].Length; grid_col++)
            {
                Console.WriteLine($"Checking Location: Grid (Row,Col): {grid_row}, {grid_col} = {G[grid_row].ElementAt(grid_col)} Against Pattern Location: 0, 0 = {P[0].ElementAt(0)}");
                
                if (G[grid_row].ElementAt(grid_col) == P[0].ElementAt(0))
                {
                    if(CheckPatternIsPresent(ref G, (grid_row, grid_col), ref P))
                    {
                        return "YES";
                    }
                }
            }
        }
        return "NO";
        */

        return "NO";
    }
    public static int BeautifulTriplets(int d, List<int> arr)
    {
        int beautifultriplecount = 0;
        for(int i = 0; i < arr.Count-2 ; i++)
        {
            for(int j = i+1; j < arr.Count-1 ; j++)
            {
                for(int k = j+1; k < arr.Count ; k++)
                {
                    if (arr[j] - arr[i] != d) {
                        break;
                    }
                    if (arr[k] - arr[j] != d)
                    {
                        continue;
                    }
                    Console.WriteLine($"Adding to count: {i},{j},{k}");
                    beautifultriplecount++;
                }
            }
        }
        Console.WriteLine(beautifultriplecount);
        return beautifultriplecount;
    }
    public static string HappyLadyBugs(string b)
    {
        int n = b.Length;
        bool happy = true;
        if (b.Contains('_'))
        {
            int[] counts = new int[26];
            foreach (char c in b)
            {
                if (c != '_') counts[(int)(c - 'A')]++;
            }
            foreach (int c in counts)
            {
                if (c == 1)
                {
                    happy = false;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                if (b[i] != '_')
                {
                    bool friendleft = i > 0 && b[i - 1] == b[i];
                    bool friendright = i < n - 1 && b[i + 1] == b[i];
                    if (!friendleft && !friendright)
                    {
                        happy = false;
                        break;
                    }
                }
            }
        }
        return happy ? "YES" : "NO";
    }
    public static long StrangeCounter(long t)
    {

        long value_start_count;
        long current_first_time_count = 1;
        long increment = 3;
        long previous_val = 1;
        long multiplyer = 1;
        long idx_offset;
        
        while(previous_val + (multiplyer * increment) <= t)
        {
            current_first_time_count = previous_val + (multiplyer*increment);
            //Console.WriteLine(current_first_time_count);
            previous_val = current_first_time_count;
            multiplyer *= 2;
        }

        value_start_count = current_first_time_count + 2;
        idx_offset = (t - current_first_time_count);
        return value_start_count - idx_offset;
    }

}

class ImplementationEasy_Client
{
    public static void Run()    {
        //GradingStudents();
        //AppleAndOrange();
        //NumberLineJumps();
        //BreakingTheRecords();
        //SubarrayDivision();
        //DivisibleSumPairs();
        //MigratoryBirds();
        //DayOfProgrammer();
        //BillDivision();
        //SalesByMatch();
        //DrawingBook();
        //CountingValleys();
        //ElectronicsShop();
        //CatAndMouse();
        //PickingNumbers();
        //TheHurdleRace();
        //DesignerPDFViewer();
        //UtopianTree();
        //AngryProfessor();
        //BeautifulDaysAtTheMovies();
        //ViralAdvertising();
        //SaveThePrioners();
        //CircularArrayRotation();
        //SequenceEquation();
        //JumpingOnTheClouds();
        //FindDigits();
        //AppendAndDelete();
        //SherlockAndSquares();
        //LibraryFine();
        //CutTheSticks();
        //RepeatedString();
        //EqualizeTheArray();
        //ACMTeam();
        //TaumAndBday();
        //ModifiedKaprekarNumbers();
        //BeautifulTriplets();
        //MinimumDistances();
        //HalloweenSale();
        //ChocolateFeast();
        //ServiceLane();
        //Workbook();
        //FlatlandSpaceStations();
        //FairRations();
        //CavityMap();
        //ManasaAndStones();
        StrangeCounter();
        //TheGridSearch();


    }

    public static void GradingStudents()
    {
        int gradesCount = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Input.ReadLine().Trim());
            grades.Add(gradesItem);
        }

        List<int> result = Implementation.GradingStudents(grades);
    }
    public static void AppleAndOrange()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int s = Convert.ToInt32(firstMultipleInput[0]);

        int t = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int a = Convert.ToInt32(secondMultipleInput[0]);

        int b = Convert.ToInt32(secondMultipleInput[1]);

        string[] thirdMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(thirdMultipleInput[0]);

        int n = Convert.ToInt32(thirdMultipleInput[1]);

        List<int> apples = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(applesTemp => Convert.ToInt32(applesTemp)).ToList();

        List<int> oranges = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(orangesTemp => Convert.ToInt32(orangesTemp)).ToList();

        Implementation.AppleAndOrange(s, t, a, b, apples, oranges);
    }
    public static void NumberLineJumps()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int x1 = Convert.ToInt32(firstMultipleInput[0]);

        int v1 = Convert.ToInt32(firstMultipleInput[1]);

        int x2 = Convert.ToInt32(firstMultipleInput[2]);

        int v2 = Convert.ToInt32(firstMultipleInput[3]);

        string result = Implementation.NumberLineJumps(x1, v1, x2, v2);
    }
    public static void BetweenTwoSets()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Implementation.BetweenTwoSets(arr, brr);
    }
    public static void BreakingTheRecords()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> scores = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

        List<int> result = Implementation.BreakingTheRecords(scores);
    }
    public static void SubarrayDivision()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> s = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int d = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        int result = Implementation.SubarrayDivision(s, d, m);
    }
    public static void DivisibleSumPairs()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> ar = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Implementation.DivisibleSumPairs(n, k, ar);
    }
    public static void MigratoryBirds()
    {
        int arrCount = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> arr = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Implementation.MigratoryBirds(arr);
    }
    public static void DayOfProgrammer()
    {
        int year = Convert.ToInt32(Input.ReadLine().Trim());

        string result = Implementation.DayOfTheProgrammer(year);
    }
    public static void BillDivision()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> bill = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(billTemp => Convert.ToInt32(billTemp)).ToList();

        int b = Convert.ToInt32(Input.ReadLine().Trim());

        Implementation.BillDivision(bill, k, b);
    }
    public static void SalesByMatch()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> ar = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Implementation.SalesByMatch(n, ar);
    }
    public static void DrawingBook()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        int p = Convert.ToInt32(Input.ReadLine().Trim());

        int result = Implementation.DrawingBook(n, p);
    }
    public static void CountingValleys()
    {
        int steps = Convert.ToInt32(Input.ReadLine().Trim());

        string path = Input.ReadLine();

        int result = Implementation.CountingValleys(steps, path);
    }
    public static void ElectronicsShop()
    {
        string[] bnm = Input.ReadLine().Split(' ');

        int b = Convert.ToInt32(bnm[0]);

        int n = Convert.ToInt32(bnm[1]);

        int m = Convert.ToInt32(bnm[2]);

        int[] keyboards = Array.ConvertAll(Input.ReadLine().Split(' '), keyboardsTemp => Convert.ToInt32(keyboardsTemp))
        ;

        int[] drives = Array.ConvertAll(Input.ReadLine().Split(' '), drivesTemp => Convert.ToInt32(drivesTemp))
        ;
        /*
         * The maximum amount of money she can spend on a keyboard and USB drive, or -1 if she can't purchase both items
         */

        int moneySpent = Implementation.ElectronicsShop(keyboards, drives, b);
    }
    public static void CatAndMouse()
    {
        int q = Convert.ToInt32(Input.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] xyz = Input.ReadLine().Split(' ');

            int x = Convert.ToInt32(xyz[0]);

            int y = Convert.ToInt32(xyz[1]);

            int z = Convert.ToInt32(xyz[2]);

            string result = Implementation.CatAndMouse(x, y, z);
        }
    }
    public static void PickingNumbers()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> a = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Implementation.PickingNumbers(a);
    }
    public static void TheHurdleRace()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> height = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(heightTemp => Convert.ToInt32(heightTemp)).ToList();

        int result = Implementation.TheHurdleRace(k, height);
    }
    public static void DesignerPDFViewer()
    {
        List<int> h = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(hTemp => Convert.ToInt32(hTemp)).ToList();

        string word = Input.ReadLine();

        int result = Implementation.DesignerPdfViewer(h, word);
    }
    public static void UtopianTree()
    {
        int t = Convert.ToInt32(Input.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Input.ReadLine().Trim());

            int result = Implementation.UtopianTree(n);
        }
    }
    public static void AngryProfessor()
    {
        int t = Convert.ToInt32(Input.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> a = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

            string result = Implementation.AngryProfessor(k, a);
        }
    }
    public static void BeautifulDaysAtTheMovies()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int i = Convert.ToInt32(firstMultipleInput[0]);

        int j = Convert.ToInt32(firstMultipleInput[1]);

        int k = Convert.ToInt32(firstMultipleInput[2]);

        int result = Implementation.BeautifulDaysAtTheMovies(i, j, k);
    }
    public static void ViralAdvertising()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        int result = Implementation.ViralAdvertising(n);
    }
    public static void SaveThePrioners()
    {
        int t = Convert.ToInt32(Input.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int s = Convert.ToInt32(firstMultipleInput[2]);

            int result = Implementation.SaveThePrisoner(n, m, s);
        }
}
    public static void CircularArrayRotation()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        int q = Convert.ToInt32(firstMultipleInput[2]);

        List<int> a = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> queries = new List<int>();

        for (int i = 0; i < q; i++)
        {
            int queriesItem = Convert.ToInt32(Input.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<int> result = Implementation.CircularArrayRotation(a, k, queries);
    }
    public static void SequenceEquation()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> p = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(pTemp => Convert.ToInt32(pTemp)).ToList();

        List<int> result = Implementation.SequenceEquation(p);
    }
    public static void JumpingOnTheClouds()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> c = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

        int result = Implementation.JumpingOnClouds(c);
    }
    public static void FindDigits()
    {
        int t = Convert.ToInt32(Input.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Input.ReadLine().Trim());

            int result = Implementation.FindDigits(n);
        }
    }
    public static void AppendAndDelete()
    {
        string s = Input.ReadLine();

        string t = Input.ReadLine();

        int k = Convert.ToInt32(Input.ReadLine().Trim());

        string result = Implementation.AppendAndDelete(s, t, k);

    }
    public static void SherlockAndSquares()
    {
        int q = Convert.ToInt32(Input.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

            int a = Convert.ToInt32(firstMultipleInput[0]);

            int b = Convert.ToInt32(firstMultipleInput[1]);

            int result = Implementation.SherlockAndSquares(a, b);
        }
    }
    public static void LibraryFine()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int d1 = Convert.ToInt32(firstMultipleInput[0]);

        int m1 = Convert.ToInt32(firstMultipleInput[1]);

        int y1 = Convert.ToInt32(firstMultipleInput[2]);

        string[] secondMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int d2 = Convert.ToInt32(secondMultipleInput[0]);

        int m2 = Convert.ToInt32(secondMultipleInput[1]);

        int y2 = Convert.ToInt32(secondMultipleInput[2]);

        int result = Implementation.libraryFine(d1, m1, y1, d2, m2, y2);
    }
    public static void CutTheSticks()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> arr = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Implementation.CutTheSticks(arr);
    }
    public static void RepeatedString()
    {
        string s = Input.ReadLine();

        long n = Convert.ToInt64(Input.ReadLine().Trim());

        long result = Implementation.RepeatedString(s, n);
    }
    public static void EqualizeTheArray()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> arr = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Implementation.EqualizeArray(arr);
    }
    public static void ACMTeam()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<string> topic = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string topicItem = Input.ReadLine();
            topic.Add(topicItem);
        }

        List<int> result = Implementation.ACMTeam(topic);
    }
    public static void TaumAndBday()
    {
        int t = Convert.ToInt32(Input.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

            int b = Convert.ToInt32(firstMultipleInput[0]);

            int w = Convert.ToInt32(firstMultipleInput[1]);

            string[] secondMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

            int bc = Convert.ToInt32(secondMultipleInput[0]);

            int wc = Convert.ToInt32(secondMultipleInput[1]);

            int z = Convert.ToInt32(secondMultipleInput[2]);

            long result = Implementation.TaumBday(b, w, bc, wc, z);
        }
    }
    public static void ModifiedKaprekarNumbers()
    {
        int p = Convert.ToInt32(Input.ReadLine().Trim());

        int q = Convert.ToInt32(Input.ReadLine().Trim());

        Implementation.ModifiedKaprekarNumbers(p, q);
    }
    public static void BeautifulTriplets()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Implementation.BeautifulTriplets(d, arr);
    }
    public static void MinimumDistances()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> a = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Implementation.MinimumDistances(a);

    }
    public static void HalloweenSale()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int p = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        int m = Convert.ToInt32(firstMultipleInput[2]);

        int s = Convert.ToInt32(firstMultipleInput[3]);

        int answer = Implementation.HalloweenSale(p, d, m, s);
    }

    public static void ChocolateFeast()
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int c = Convert.ToInt32(firstMultipleInput[1]);

            int m = Convert.ToInt32(firstMultipleInput[2]);

            int result = Implementation.ChocolateFeast(n, c, m);

            Console.WriteLine(result);
        }
    }
    public static void ServiceLane()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int t = Convert.ToInt32(firstMultipleInput[1]);

        List<int> width = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(widthTemp => Convert.ToInt32(widthTemp)).ToList();

        List<List<int>> cases = new List<List<int>>();

        for (int i = 0; i < t; i++)
        {
            cases.Add(Input.ReadLine().TrimEnd().Split(' ').ToList().Select(casesTemp => Convert.ToInt32(casesTemp)).ToList());
        }

        List<int> result = Implementation.ServiceLane(n, cases, width);
    }
    public static void Workbook()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Implementation.Workbook(n, k, arr);
    }

    public static void FlatlandSpaceStations()
    {
        string[] nm = Input.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[] c = Array.ConvertAll(Input.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = Implementation.FlatlandSpaceStations(n, c);
    }

    public static void FairRations()
    {
        int N = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> B = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

        string result = Implementation.FairRations(B);
    }

    public static void CavityMap()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Input.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Implementation.CavityMap(grid);

        Console.WriteLine(String.Join("\n", result));

    }
    public static void ManasaAndStones()
    {
        int T = Convert.ToInt32(Input.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            int n = Convert.ToInt32(Input.ReadLine().Trim());

            int a = Convert.ToInt32(Input.ReadLine().Trim());

            int b = Convert.ToInt32(Input.ReadLine().Trim());

            List<int> result = Implementation.ManasaAndStones(n, a, b);

            Console.WriteLine(String.Join(" ", result));
        }

    }

    public static void TheGridSearch()
    {
        int t = Convert.ToInt32(Input.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

            int R = Convert.ToInt32(firstMultipleInput[0]);

            int C = Convert.ToInt32(firstMultipleInput[1]);

            List<string> G = new List<string>();

            for (int i = 0; i < R; i++)
            {
                string GItem = Input.ReadLine();
                G.Add(GItem);
            }

            string[] secondMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

            int r = Convert.ToInt32(secondMultipleInput[0]);

            int c = Convert.ToInt32(secondMultipleInput[1]);

            List<string> P = new List<string>();

            for (int i = 0; i < r; i++)
            {
                string PItem = Input.ReadLine();
                P.Add(PItem);
            }

            string result = Implementation.TheGridSearch(G, P);
            Console.WriteLine(result);
        }
    }
    
    public static void HappyLadyBugs()
    {

    }
    public static void StrangeCounter()
    {
        long t = Convert.ToInt64(Input.ReadLine().Trim());

        long answer = Implementation.StrangeCounter(t);
        Console.WriteLine(answer);
    }
}