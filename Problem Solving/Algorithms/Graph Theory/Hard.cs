using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleInput;

namespace Algorithms;

public partial class GraphTheory
{
    public static int MinTime(List<List<int>> roads, List<int> machines)
    {

        Stack<List<int>> stack = new Stack<List<int>>();

        List<List<int>> machineCities = new List<List<int>>();
        int sum = 0;
        for (int i = 0; i < roads.Count; i++)
        {
            if (machines.Contains(roads[i][1]))
            {
                machineCities.Add(roads[i]);
                sum += roads[i][2];
            }
        }
        machineCities.Sort();
        return sum;
    }
}

class GraphTheoryEasy_Client
{
    public static void Run()
    {
        MinTime();
    }

    public static void MinTime()
    {
        string[] firstMultipleInput = Input.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> roads = new List<List<int>>();

        for (int i = 0; i < n - 1; i++)
        {
            roads.Add(Input.ReadLine().TrimEnd().Split(' ').ToList().Select(roadsTemp => Convert.ToInt32(roadsTemp)).ToList());
        }

        List<int> machines = new List<int>();

        for (int i = 0; i < k; i++)
        {
            int machinesItem = Convert.ToInt32(Input.ReadLine().Trim());
            machines.Add(machinesItem);
        }

        int result = GraphTheory.MinTime(roads, machines);
    }

}

