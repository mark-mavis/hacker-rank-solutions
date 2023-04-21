namespace DataStructures;
public class Arrays
{
    public static int TwoDimensionArray(List<List<int>> arr)
    {
        int MaxSum = Int32.MinValue;
        for (int i_idx = 0; i_idx < arr.Count - 2; i_idx++)
        {
            for (int j_idx = 0; j_idx < arr[i_idx].Count - 2; j_idx++)
            {
                int upperSum = arr[i_idx][j_idx] + arr[i_idx][j_idx + 1] + arr[i_idx][j_idx + 2];
                int middleSum = arr[i_idx + 1][j_idx + 1];
                int bottomSum = arr[i_idx + 2][j_idx] + arr[i_idx + 2][j_idx + 1] + arr[i_idx + 2][j_idx + 2];
                int totalSum = upperSum + middleSum + bottomSum;
                arr[i_idx][j_idx] = totalSum;
                if (totalSum > MaxSum) MaxSum = totalSum;
            }
        }
        return MaxSum;
    }
    public static List<int> DynamicArray(int n, List<List<int>> queries)
    {
        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(new List<int>());   // Pushing N number of Empty List<int> to the List
        }

        List<int> lastAnswers = new List<int>();

        int lastAnswer = 0;
        foreach (List<int> query in queries)
        {
            int queryType = query[0];   // Get Query Type

            int idx = ((query[1] ^ lastAnswer) % n);    // Get Index
            if (queryType == 1) arr[idx].Add(query[2]);
            else
            {
                lastAnswer = arr[idx][query[2] % arr[idx].Count];
                lastAnswers.Add(lastAnswer);
            }
        }
        return lastAnswers;
    }
    public static List<int> LeftRotation(int d, List<int> arr)
    {
        int rotations = d % arr.Count;
        List<int> temp = arr.GetRange(0, rotations);
        arr.RemoveRange(0, rotations);
        arr.AddRange(temp);
        return arr;
    }
    public static List<int> MatchingStrings(List<string> stringList, List<string> queries)
    {
        List<int> results = new List<int>();
        foreach (string query in queries)
        {
            results.Add(stringList.Count(str => str == query));
        }

        return results;
    }
}

