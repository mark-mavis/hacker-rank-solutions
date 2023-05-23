using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using ConsoleInput;

namespace Algorithms;
public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
{
    public bool Equals(List<T> x, List<T> y)
    {
        if (x == null || y == null)
        {
            return x == y;
        }

        return x.SequenceEqual(y);
    }
    public int GetHashCode(List<T> obj)
    {
        return obj.Aggregate(0, (acc, val) => acc ^ val.GetHashCode());
    }
}
public partial class Implementation
{
    public static int FormingAMagicSquare(List<List<int>> s)
    {
        // Only 8 ways to sum to 15
        // 1+9+5
        // 2+8+5
        // 3+7+5
        // 4+6+5
        // 4+3+8
        // 6+2+7
        // 6+1+8
        // 9+2+4

        /*      Magic Square Layout
         * 
         *   Corner  |  Edge  |  Corner
         *  ---------|--------|---------
         *    Edge   | Middle |   Edge
         *  ---------|--------|---------
         *   Corner  |  Edge  |  Corner
         *   
         */

        // Shows up 4 times (Middle) - 5
        // Shows up 3 times (Corners) - 2, 4, 6, 8
        // Shows up 2 times (Edges) - 1, 3, 7, 9

        // ALL POSSIBLE MAGIC SQUARES
        // 8 3 4   2 7 6  |  4 9 2   2 9 4
        // 1 5 9   9 5 1  |  3 5 7   7 5 3
        // 6 7 2   4 3 8  |  8 1 6   6 1 8
        // ---------------------------------
        // 6 7 2   4 3 8  |  8 1 6   6 1 8
        // 1 5 9   9 5 1  |  3 5 7   7 5 3
        // 8 3 4   2 7 6  |  4 9 2   2 9 4

        // All Magic Square Possibilities
        ((int, int, int), (int, int, int), (int, int, int)) [,] possible_magic_sqaures = new ((int, int, int), (int, int, int), (int, int, int))[8,1]
        {
            { ((8, 3, 4 ), (1, 5, 9 ), (6, 7, 2 )) },
            { ((2, 7, 6 ), (9, 5, 1 ), (4, 3, 8 )) },
            { ((4, 9, 2 ), (3, 5, 7 ), (8, 1, 6 )) },
            { ((2, 9, 4 ), (7, 5, 3 ), (6, 1, 8 )) },
            { ((6, 7, 2 ), (1, 5, 9 ), (8, 3, 4 )) },
            { ((4, 3, 8 ), (9, 5, 1 ), (2, 7, 6 )) },
            { ((8, 1, 6 ), (3, 5, 7 ), (4, 9, 2 )) },
            { ((6, 1, 8 ), (7, 5, 3 ), (2, 9, 4 )) }
        };
        
        /* Iterate through the 2 Dimensional Array of (int, int, int), (int, int, int), (int, int, int) datatype tuples
         * 
         * Use a foreach loop to iterate the first dimension and the enumerable return provides a 
         * two dimensional tuple that includes a three item tuple as the second dimension
         */

        int min_val = int.MaxValue;
        foreach (((int, int, int), (int, int, int), (int, int, int)) subarray in possible_magic_sqaures)
        {
            int row1sum = Math.Abs(s[0].ElementAt(0) - subarray.Item1.Item1) + Math.Abs(s[0].ElementAt(1) - subarray.Item1.Item2) + Math.Abs(s[0].ElementAt(2) - subarray.Item1.Item3);
            int row2sum = Math.Abs(s[1].ElementAt(0) - subarray.Item2.Item1) + Math.Abs(s[1].ElementAt(1) - subarray.Item2.Item2) + Math.Abs(s[1].ElementAt(2) - subarray.Item2.Item3);
            int row3sum = Math.Abs(s[2].ElementAt(0) - subarray.Item3.Item1) + Math.Abs(s[2].ElementAt(1) - subarray.Item3.Item2) + Math.Abs(s[2].ElementAt(2) - subarray.Item3.Item3);
            if(min_val > (row1sum+row2sum+row3sum)) min_val = (row1sum + row2sum + row3sum);
        }
        Console.WriteLine($"Min Value: {min_val.ToString()}");
        return min_val;
    }

    public static int QueensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        bool up = true;
        bool down = true;
        (int x, int y) up_pos = (r_q, c_q);
        (int x, int y) down_pos = (r_q, c_q);

        bool left = true;
        bool right = true;
        (int x, int y) left_pos = (r_q, c_q);
        (int x, int y) right_pos = (r_q, c_q);

        bool right_down = true;
        bool left_up = true;
        (int x, int y) right_down_pos = (r_q, c_q);
        (int x, int y) left_up_pos = (r_q, c_q);

        bool left_down = true;
        bool right_up = true;
        (int x, int y) left_down_pos = (r_q, c_q);
        (int x, int y) right_up_pos = (r_q, c_q);


        int row_max = Math.Max(Math.Abs(r_q-n), Math.Abs(r_q-0));
        int col_max = Math.Max(Math.Abs(c_q-n), Math.Abs(c_q-0));

        int max_move = Math.Max(row_max, col_max);
        
        int moves = 0;

        for (int i = 0; i < max_move; i++)
        {
            if (up)
            {
                up_pos.x++;
                if (obstacles.Contains(new List<int>() { up_pos.x, up_pos.y }, new ListEqualityComparer<int>()) || up_pos.x > n) up = false;
            }

            if (down)
            {
                down_pos.x--;
                if (obstacles.Contains(new List<int>() { down_pos.x, down_pos.y }, new ListEqualityComparer<int>()) || down_pos.x < 1) down = false;
            }

            if (left)
            {
                left_pos.y--;
                if (obstacles.Contains(new List<int>() { left_pos.x, left_pos.y }, new ListEqualityComparer<int>()) || left_pos.y < 1) left = false;
            }

            if (right)
            {
                right_pos.y++;
                if (obstacles.Contains(new List<int>() { right_pos.x, right_pos.y }, new ListEqualityComparer<int>()) || right_pos.y > n) right = false;
            }

            if (right_down)
            {
                right_down_pos.x--;
                right_down_pos.y++;
                if (obstacles.Contains(new List<int>() { right_down_pos.x, right_down_pos.y }, new ListEqualityComparer<int>()) || (right_down_pos.x < 1 || right_down_pos.y > n)) right_down = false;
            }

            if (left_up)
            {
                left_up_pos.x++;
                left_up_pos.y--;
                if (obstacles.Contains(new List<int>() { left_up_pos.x, left_up_pos.y }, new ListEqualityComparer<int>()) || (left_up_pos.x > n || left_up_pos.y < 1)) left_up = false;
            }

            if (left_down)
            {
                left_down_pos.y--;
                left_down_pos.x--;
                if (obstacles.Contains(new List<int>() { left_down_pos.x, left_down_pos.y }, new ListEqualityComparer<int>()) || (left_down_pos.x < 1 || left_down_pos.y < 1)) left_down = false;
            }

            if (right_up)
            {
                right_up_pos.x++;
                right_up_pos.y++;
                if (obstacles.Contains(new List<int>() { right_up_pos.x, right_up_pos.y }, new ListEqualityComparer<int>()) || (right_up_pos.x > n || right_up_pos.y > n)) right_up = false;
            }

            if (up) moves++;
            if(down) moves++;
            if(left) moves++;
            if(right) moves++;
            if(right_down) moves++;
            if(left_up) moves++;
            if(left_down) moves++;
            if(right_up) moves++;
            
            Console.WriteLine($"Moves: {moves}");
        }
        return moves;
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
        //QueensAttack();

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
    public static void QueensAttack()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Input.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Implementation.QueensAttack(n, k, r_q, c_q, obstacles);
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

