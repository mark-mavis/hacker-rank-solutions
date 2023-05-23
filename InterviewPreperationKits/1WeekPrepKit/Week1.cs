using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OneWeekPrepKit
{
    
    
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }

    public class Week1
    {
        public class Day1
        {
            public static void PlusMinus(List<int> arr)
            {
                int pos_count = 0;
                int neg_count = 0;
                int zero_count = 0;

                foreach (int i in arr)
                {
                    if (i < 0) neg_count++;
                    else if (i > 0) pos_count++;
                    else zero_count++;
                }

                decimal currentTotal = (decimal)pos_count + (decimal)neg_count + (decimal)zero_count;
                decimal pos_rat = (decimal)pos_count / currentTotal;
                decimal neg_rat = (decimal)neg_count / currentTotal;
                decimal zero_rat = (decimal)zero_count / currentTotal;

                Console.WriteLine($"{pos_rat:F6}");
                Console.WriteLine($"{neg_rat:F6}");
                Console.WriteLine($"{zero_rat:F6}");
            }
            public static void MiniMaxSum(List<int> arr)
            {
                arr.Sort();
                BigInteger low_sum = 0;
                BigInteger high_sum = 0;
                for (int i = 0; i < arr.Count; i++)
                {
                    if (i >= 0 && i < arr.Count - 1) low_sum += arr[i];

                    if (i >= 1 && i < arr.Count) high_sum += arr[i];
                }
                Console.WriteLine($"{low_sum} {high_sum}");
            }
            public static string TimeConversion(string s)
            {
                DateTime dt = DateTime.ParseExact(s, "hh:mm:sstt", System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine(dt.ToString("HH:mm:ss"));
                return dt.ToString("HH:mm:ss");
            }
            public static int MockTest()
            {
                List<int> arr = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
                arr.Sort();
                int idx = arr.Count() / 2;
                Console.WriteLine(idx);
                return arr[idx];

            }
        }
        public class Day2
        {
            public static int LonelyInteger(List<int> a)
            {
                a.Sort();
                //Console.WriteLine($"Array Count: {a.Count}");
                for (int i = 0; i < a.Count; i += 2)
                {
                    //Console.WriteLine($"idx: {i} idx+1: {i+1}");
                    if (i + 1 < a.Count)
                    {
                        if (a[i] == a[i + 1])
                        {
                            //Console.WriteLine("breaking loop");
                            continue;
                        }
                        else
                        {
                            return a[i];
                        }
                    }
                    else
                    {
                        return a[i];
                    }
                }
                throw new ArgumentNullException("Argument passed is empty");
            }
            public static int DiagonalDifference(List<List<int>> arr)
            {
                int left_dia = 0;
                int right_dia = 0;

                for (int i = 0; i < arr.Count; i++)
                {
                    left_dia += arr[i].ElementAt(i);
                    right_dia += arr[i].ElementAt(arr.Count - (i + 1));
                }
                //Console.WriteLine($"Returning: {Math.Abs(right_dia - left_dia)}");
                return Math.Abs(right_dia - left_dia);
            }
            public static List<int> CountingSort(List<int> arr)
            {

                int idx_len = arr.Max() + 1;
                int[] idxs = new int[idx_len];

                for (int i = 0; i < arr.Count(); i++)
                {
                    idxs[arr[i]]++;
                }

                List<int> temp = new List<int>();
                for (int i = 0; i < idxs.Length; i++)
                {
                    if (idxs[i] > 0)
                    {
                        for (int j = 0; j < idxs[i]; j++)
                        {
                            temp.Add(i);
                        }
                    }
                }

                return idxs.ToList();
            }
            public static int FlippingMatrix(List<List<int>> matrix)
            {
                for(int i = 0; i < matrix.Count/2; i++)
                {
                    for(int j = 0; j < matrix[i].Count/2; j++)
                    {
                        Console.WriteLine($"matrix[i][j]: {matrix[i][j]} ");
                        Console.WriteLine($"matrix[matrix.Count - (i + 1)][matrix.Count - (j + 1)]: {matrix[matrix.Count - (i + 1)][matrix.Count - (j + 1)]}");
                        Console.WriteLine($"matrix[matrix.Count - (j + 1)]: {matrix[matrix.Count - (j + 1)][i]}");
                        Console.WriteLine($"matrix[matrix.Count - (j + 1)][matrix.Count - (i + 1)]: {matrix[j][matrix.Count - (i + 1)]}");

                        if (matrix[i][j] < matrix[matrix.Count - (i + 1)][matrix.Count - (j + 1)])
                        {

                        }
                    }
                }

                return 0;
            }
        }
        public class Day3{
            public static void ZigZagSequence(){
                int t = Convert.ToInt32(Console.ReadLine());
                for(int i = 0; i < t; i++){
                    int n = Convert.ToInt32(Console.ReadLine());
                    List<int> ints = Console.ReadLine().TrimEnd().Split(' ').ToList().Select( (c) => Convert.ToInt32(c)).ToList();
                    int midpointIdx = (ints.Count+1)/2;
                    ints.Sort();
                    List<int> ascending = ints.GetRange(0, midpointIdx-1);
                    Stack<int> decending = new Stack<int>();

                    for(int j = midpointIdx-1; j < ints.Count; j++){
                        
                        /*
                        if(j > 0 && j < midpointIdx){
                            decending.Push(ints[j]);
                        }else{
                            ascending.Add(ints[j]);
                        }
                        */
                        decending.Push(ints[j]);
                    }

                    while(decending.Count > 0){
                        ascending.Add(decending.Pop());
                    }

                    for(int j = 0; j < ascending.Count; j++){
                        Console.Write(ascending[j]);
                        if(j < ascending.Count-1){
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }

            }
        }

        
        public class SkillCertification{
            public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
            {
                Dictionary<string, int> result = new Dictionary<string, int>();

                var GroupBy = employees.GroupBy((emp) => emp.Company);

                foreach(IGrouping<string, Employee> e in GroupBy){
                    result.Add(e.Key, (int)e.Average( (emp) => emp.Age));
                }
                return result;
            }
        
            public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
            {
                Dictionary<string, int> result = new Dictionary<string, int>();

                var GroupBy = employees.GroupBy((emp) => emp.Company);

                foreach(IGrouping<string, Employee> e in GroupBy){
                    result.Add(e.Key, (int)e.Count(emp => emp.Company == e.Key));
                }
                return result;
            }
        
            public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
            {
                Dictionary<string, Employee> result = new Dictionary<string, Employee>();

                var GroupBy = employees.GroupBy((emp) => emp.Company);

                foreach(IGrouping<string, Employee> e in GroupBy){
                    result.Add(e.Key, e.First((emp) => emp.Age == e.Max( emp => emp.Age )));
                }
                return result;        
            }
        
            public class Team{
                public string teamName;
                public int noOfPlayers;
                public Team(string teamname, int num_players){
                    teamName = teamname;
                    noOfPlayers = num_players;
                }
                public void AddPlayer(int count){
                    noOfPlayers += count;
                }
                public bool RemovePlayer(int count){
                    
                    if(noOfPlayers >= count){
                        noOfPlayers -= count;
                        return true;
                    }else{
                        return false;
                    }
                }
            }
            public class SubTeam : Team{
                public SubTeam(string teamname, int num_players) : base(teamname, num_players){} 
                public void ChangeTeamName(string name){
                    if(name != null){
                        teamName = name;
                    } 
                }
            }
        }
    }
    
    public class Week1Client
    {
        public class Day1Client
        {
            public static void PlusMinus()
            {
                Console.WriteLine("Plus Minus...");
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
                Week1.Day1.PlusMinus(arr);
            }
            public static void MiniMaxSum()
            {
                Console.WriteLine("MiniMaxSum...");
                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
                Week1.Day1.MiniMaxSum(arr);
            }
            public static void TimeConversion()
            {
                string s = Console.ReadLine();

                string result = Week1.Day1.TimeConversion(s);
            }
            public static void MockTest()
            {
                int result = Week1.Day1.MockTest();
            }
        }
        public class Day2Client
        {
            public static void LonelyInteger()
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

                int result = Week1.Day2.LonelyInteger(a);
            }
            public static void DiagonalDifference()
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<List<int>> arr = new List<List<int>>();

                for (int i = 0; i < n; i++)
                {
                    arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
                }

                int result = Week1.Day2.DiagonalDifference(arr);
            }
            public static void CountingSort()
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                List<int> result = Week1.Day2.CountingSort(arr);

            }
            public static void MockTest()
            {
                int q = Convert.ToInt32(Console.ReadLine().Trim());

                for (int qItr = 0; qItr < q; qItr++)
                {
                    int n = Convert.ToInt32(Console.ReadLine().Trim());

                    List<List<int>> matrix = new List<List<int>>();

                    for (int i = 0; i < 2 * n; i++)
                    {
                        matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
                    }

                    int result = Week1.Day2.FlippingMatrix(matrix);
                }
            }
        }
        public class Day3Client{
            public static void ZigZagSequence(){
                Week1.Day3.ZigZagSequence();
            }
        }


        public class SkillCertificationClient{
            public static void RunQuestion01(){
                
                int countOfEmployees = int.Parse(Console.ReadLine());
            
                var employees = new List<Employee>();
                
                for (int i = 0; i < countOfEmployees; i++)
                {
                    string str = Console.ReadLine();
                    string[] strArr = str.Split(' ');
                    employees.Add(new Employee { 
                        FirstName = strArr[0], 
                        LastName = strArr[1], 
                        Company = strArr[2], 
                        Age = int.Parse(strArr[3]) 
                        });
                }
                
                foreach (var emp in Week1.SkillCertification.AverageAgeForEachCompany(employees))
                {
                    Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
                }

                
                foreach (var emp in Week1.SkillCertification.CountOfEmployeesForEachCompany(employees))
                {
                    Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
                }
                
                foreach (var emp in Week1.SkillCertification.OldestAgeForEachCompany(employees))
                {
                    Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
                }
            
                //Week1.SkillCertification.Question2();

                Console.WriteLine("Press Enter to Shutdown");
                Console.ReadLine();
            }

            public static void RunQuestion02(){
                if(!typeof(Week1.SkillCertification.SubTeam).IsSubclassOf(typeof(Week1.SkillCertification.Team))){
                    throw new Exception("Subteam class should inherit from Team class");
                }
                String str = Console.ReadLine();
                String[] strArr = str.Split();
                string initialName = strArr[0];
                int count = Convert.ToInt32(strArr[1]);
                Week1.SkillCertification.SubTeam teamObj = new Week1.SkillCertification.SubTeam(initialName, count);
                Console.WriteLine("Team " + teamObj.teamName + " created");

                str = Console.ReadLine();
                count = Convert.ToInt32(str);
                Console.WriteLine("Current number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
                teamObj.AddPlayer(count);
                Console.WriteLine("New number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);

                str = Console.ReadLine();
                count = Convert.ToInt32(str);
                Console.WriteLine("Current number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
                var res = teamObj.RemovePlayer(count);
                if(res) {
                    Console.WriteLine("New number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
                }else{
                    Console.WriteLine("Number of players in team " + teamObj.teamName + " remains same");
                }

                str = Console.ReadLine();
                teamObj.ChangeTeamName(str);
                Console.WriteLine("Team name of team " + initialName + " changed to " + teamObj.teamName);
                Console.ReadLine();
                
                
            }
        
        }
    }
}
