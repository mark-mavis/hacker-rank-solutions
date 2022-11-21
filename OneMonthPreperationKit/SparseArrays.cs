namespace OneMonthPreperationKit
{
    class SparseArrays
    {

        public static List<int> RunMatchingStrings(List<string> strings, List<string> queries)
        {
            //The Results will always be the size of the queries list
            List<int> results = new List<int>();

            foreach(string s in queries)
            {
                int count = 0;
                foreach(string s2 in strings)
                {
                    if(s.Equals(s2)) count++;
                }
                results.Add(count);
            }
            return results;
        }

        public static void Run()
        {
            List<string> strings = new List<string>() { "ab", "ab", "abc"};
            List<string> queries = new List<string>() { "ab", "abc", "bc"};
            RunMatchingStrings(strings, queries);
        }
    }
}
