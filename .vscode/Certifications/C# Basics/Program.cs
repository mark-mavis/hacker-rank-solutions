namespace CSharpBasics;

class Program{
    public static void Main(){
        SkillCertificationClient.RunQuestion01();
        SkillCertificationClient.RunQuestion02();
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
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}
