using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class ImplementationMedium
    {
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

        public static void FormingMagicSquare(List<List<int>> s)
        {

        }
    }

    class ImplementationMediumManager
    {
        public static void Run()
        {
            List<int> ranked = new List<int>() { 100, 90, 90, 80 };
            List<int> player = new List<int>() { 70, 80, 105 };
            ImplementationMedium.ClimbingTheLeaderboard(ranked, player);
        }
    }

}
