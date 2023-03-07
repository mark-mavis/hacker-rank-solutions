using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algorithms;

internal class Algorithms
{
    public static long RepeatedString(string s, long n)
    {
        long count = s.Count(ch => ch == 'a');
            
        if (s.Length <= n)
        {
            long fullScans = n/(long)s.Length;
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
    public static int JumpingOnClouds(List<int> c)
    {
        int count = 0;
        for (int i = 0; i < c.Count-1;)
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
    public static int EqualizeArray(List<int> arr)
    {
        var mostCommonNumber = arr.GroupBy(n => n).OrderByDescending(g => g.Count()).First().Key;
        return arr.Count(n => n != mostCommonNumber);
    }
    public static List<int> ACMTeam(List<string> topic)
    {
        List<int> subjectList = new List<int>();
        for(int i = 0; i < topic.Count;i++)
        {
            
            for(int j = i; j < topic.Count; j++)
            {
                int Subjects = 0;
                if (i == j) continue;
                for(int k = 0; k < topic[i].Length; k++)
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
        return new List<int>{ maxSubjects, maxSubjectsCount };
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

        long cost = b*(minBC) + w*(minWC);

        return cost;
    }
    public static string OrganizingContainers(List<List<int>> container)
    {
        /*
        for(int containersIdx = 0; containersIdx < container.Count; containersIdx++)
        {
            for(int BallTypeIdx = 0; BallTypeIdx < container[containersIdx].Count; BallTypeIdx++)
            {

            }
        }*/
        for (int i = 0; i < container.Count; i++)
        {
            int count = 0, sum1 = 0, sum2 = 0;
            for (int j = 0; j < container[i].Count; j++)
            {
                sum1 += container[i][j];
                sum2 += container[j][i];
            }

            if (sum1 != sum2)
                return "Impossible";
        }
        return "Possible";
    }
    public static void KaprekarNumbers(int p, int q)
    {
        bool isValid = false;
        for(; p <= q; p++)
        {
            string strValue = Math.Pow(p, 2).ToString();
            if(strValue.Length == 1)
            {
                if(Convert.ToInt32(strValue) == p){
                    Console.Write(p + " ");
                    isValid = true;
                }
            }
            else
            {
                int middleIdx = strValue.Length/2;
                int right = Convert.ToInt32(strValue.Substring(middleIdx, strValue.Length - middleIdx));
                int left = Convert.ToInt32(strValue.Substring(0, middleIdx));
                int sum = left + right;
                if(sum == p)
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

        for(int i = 0; i < a.Count; i++)
        {
            for(int j = i+1; j < a.Count; j++)
            {
                if (a[i] == a[j]) {
                    distances.Add(Math.Abs(i - j));
                }
            }
        }

        if(distances.Count > 0 )
        {
            return distances.Min();
        }
        return -1;
    }
}

public class AlgorithmsController
{
    public static void RepeatedString()
    {
        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Algorithms.RepeatedString(s, n);
    }

    public static void JumpingOnTheClouds()
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

        int result = Algorithms.JumpingOnClouds(c);
    }

    public static void EqualizeTheArray()
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Algorithms.EqualizeArray(arr);
    }

    public static void ACMTeam()
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<string> topic = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string topicItem = Console.ReadLine();
            topic.Add(topicItem);
        }

        List<int> result = Algorithms.ACMTeam(topic);
    }

    public static void TaumAndBday()
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int b = Convert.ToInt32(firstMultipleInput[0]);

            int w = Convert.ToInt32(firstMultipleInput[1]);

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int bc = Convert.ToInt32(secondMultipleInput[0]);

            int wc = Convert.ToInt32(secondMultipleInput[1]);

            int z = Convert.ToInt32(secondMultipleInput[2]);

            long result = Algorithms.TaumBday(b, w, bc, wc, z);
        }
    }

    public static void OrganizingContainersOfBalls()
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> container = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
            }

            string result = Algorithms.OrganizingContainers(container);
        }
    }

    public static void ModifiedKaprekarNumbers()
    {
        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        Algorithms.KaprekarNumbers(p, q);
    }

    public static void MinimumDistances()
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Algorithms.MinimumDistances(a);
        Console.WriteLine(result);
    }
}

