using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace Algorithms.Result
{
    public class Result
    {
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
        public static List<int> PermutationEquation(List<int> p)
        {
            Dictionary<int , int> valueIndexPairs = new Dictionary<int, int>(p.Count);
            for(int x = 0; x < p.Count; x++)
            {
                valueIndexPairs.Add(p[x], x);
            }
            int[] indexValue = new int[p.Count];
            for ( int x = 1; x <= p.Count; x++)
            {
                indexValue[x-1] = valueIndexPairs[valueIndexPairs[x] + 1] +1;
            }

            return indexValue.ToList();
        }

        public static int JumpingOnClouds(int[] c, int k)
        {
            return 10;
        }
    }
}
