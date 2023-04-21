namespace DataStructures
{

    public class ArrayController
    {
        public static string GetInput()
        {
            string? s = Console.ReadLine();
            if(s == null) throw new ArgumentNullException("s");
            else return s;
        }
        public static void TwoDimensionArray()
        {
            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < 6; i++)
            {
                arr.Add(GetInput().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = Arrays.TwoDimensionArray(arr);
        }
        public static void DynamicArray()
        {
            string[] firstMultipleInput = GetInput().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(GetInput().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = Arrays.DynamicArray(n, queries);
        }
        public static void LeftRotation()
        {
            string[] firstMultipleInput = GetInput().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int d = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = GetInput().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Arrays.LeftRotation(d, arr);
        }
        public static void SparesArrays()
        {
            int stringListCount = Convert.ToInt32(GetInput().Trim());

            List<string> stringList = new List<string>();

            for (int i = 0; i < stringListCount; i++)
            {
                string stringListItem = GetInput();
                stringList.Add(stringListItem);
            }

            int queriesCount = Convert.ToInt32(GetInput().Trim());

            List<string> queries = new List<string>();

            for (int i = 0; i < queriesCount; i++)
            {
                string queriesItem = GetInput();
                queries.Add(queriesItem);
            }

            List<int> res = Arrays.MatchingStrings(stringList, queries);
        }

        public static void Run()
        {
            //TwoDimensionArray();
            //DynamicArray();
            //LeftRotation();
            //SparesArrays();
        }
    }
}
