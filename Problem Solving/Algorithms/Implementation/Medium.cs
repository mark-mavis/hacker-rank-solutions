using System.Numerics;

namespace Algorithms;

public partial class Implementation
{
    public static int FormingAMagicSquare(List<List<int>> s)
    {


        int x_dim = s.Count, y_dim = s[0].Count;

        for (int i = 0; i < x_dim; i++)
        {

            for (int j = 0; j < y_dim; j++)
            {
                Console.Write(s[i][j]);
            }
            Console.WriteLine();
        }
        return 1;
    }
    public static List<int> ClimbingTheLeaderboard(List<int> ranked, List<int> player)
    {
        List<int> result = new List<int>();

        var cleanedLeaderboardScores = ranked.ToHashSet().ToArray();
        int i = cleanedLeaderboardScores.Length - 1;

        for (int j = 0; j < player.Count; j++)
        {
            bool rankFound = false;
            while (!rankFound && i >= 0)
            {
                // Counting backwards on the Cleaned Leader Board Scores
                // 1st --> playerScore[0] < cleanedLeaderboardScore[3]
                //                  70 < 80 True
                if (player[j] < cleanedLeaderboardScores[i])
                {
                    result.Add(i + 2);  //Add the Player Score to End
                    rankFound = true;   //Set ranked flag

                }
                else if (player[j] == cleanedLeaderboardScores[i])
                {
                    result.Add(i + 1);
                    rankFound = true;
                }
                else
                {
                    i--;
                }
            }
            if (!rankFound)
            {
                result.Add(1);
            }
        }
        return result;
    }
    public static BigInteger ExtraLongFactorials(int n)
    {
        if (n == 1) return n;
        return n * ExtraLongFactorials(n - 1);
    }
    public static int NonDivisibleSubset(int k, List<int> s)
    {
        if (k < 2) return 1;
        int[] arr = new int[k];
        for (int i = 0; i < s.Count(); i++)
        {
            arr[s[i] % k]++;
        }
        int c = 0;
        for (int i = 1; i < k / 2; i++)
        {
            c += Math.Max(arr[i], arr[k - i]);
        }
        if (arr[0] > 1) c++;
        if (k % 2 == 0 && arr[k / 2] > 0)
        {
            c++;
        }
        if (k % 2 != 0)
        {
            c += Math.Max(arr[k / 2], arr[k - k / 2]);
        }
        return c;
    }
    public static string OrganizingContainersOfBalls(List<List<int>> container)
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
            count++;
        }
        return "Possible";
    }
    public static string TheTimeInWords(int h, int m)
    {

        if (m < 30 && m > 0)
        {
            //{minutes to string} {minute/s} past {h}

        }
        else if (m < 60 && m > 30)
        {
            // m < 15
            //{minutes to string} {minutes} past {h}
            // m > 15
            //{minutes to string} {minutes} to {h+1}
            // m = 15
            // quarter to

        }


        //Case: The front half of the hour (30 > m > 0 
        // sentence += 

        //if    m = 1 sentence += "minute "
        //else  minutes
        // 

        //Case: The back half of the hour (60 > m > 30)

        //Case: On a quarter of the hour ( m = 15, 30, 45)
        //Case: On the Hour (4:00, 7:00)


        return "Testing";
    }


}


class ImplementationMedium_Client
{
    public static void Run()
    {
        //FormingAMagicSquare();
        //ClimbingTheLeaderboard();
        //ExtraLongFactorials();
        //NonDivisibleSubset();
        //OrganizingContainersOfBalls();
        
    }

    public static void FormingAMagicSquare()
    {
        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Input.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Implementation.FormingAMagicSquare(s);
    }
    public static void ClimbingTheLeaderboard()
    {
        int rankedCount = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> ranked = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> player = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Implementation.ClimbingTheLeaderboard(ranked, player);
    }
    public static void ExtraLongFactorials()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        Implementation.ExtraLongFactorials(n);
    }
    public static void NonDivisibleSubset()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> s = Input.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Implementation.NonDivisibleSubset(k, s);
    }
    public static void OrganizingContainersOfBalls()
    {
        int q = Convert.ToInt32(Input.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Input.ReadLine().Trim());

            List<List<int>> container = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                container.Add(Input.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
            }

            string result = Implementation.OrganizingContainersOfBalls(container);
        }
    }
    public static void TheTimeInWords()
    {
        int h = Convert.ToInt32(Input.ReadLine().Trim());

        int m = Convert.ToInt32(Input.ReadLine().Trim());

        string result = Implementation.TheTimeInWords(h, m);
    }



}

