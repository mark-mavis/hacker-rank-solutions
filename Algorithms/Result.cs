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
            int[] permutations = new int[p.Count];
            for(int i = 0; i < p.Count; i++)
            {
                permutations[i] = p[p[i]];
            }
            return permutations.ToList<int>();
        }

    }
}
