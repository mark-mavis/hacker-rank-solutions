
using System.IO;
using System.Security;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using ConsoleInput;
using System.Security.Cryptography.X509Certificates;

namespace Strings;

public partial class Strings
{
    //EASY IMPLEMENTATIONS
    public static string SuperReducedString(string s)
    {
        Stack<char> chars = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (chars.Count == 0)
            {
                chars.Push(s[i]);
            }
            else
            {
                if (chars.Peek() == s[i])
                {
                    chars.Pop();
                }
                else
                {
                    chars.Push(s[i]);
                }
            }
        }

        StringBuilder sb = new StringBuilder();
        if (chars.Count != 0)
        {
            while (chars.Count != 0)
            {
                sb.Insert(0, chars.Pop());
            }
            //Console.WriteLine($"Returning {sb}");
            return sb.ToString();
        }
        //Console.WriteLine($"Returning Empty String");
        return sb.ToString();
    }
    public static int CamelCase(string s)
    {
        return s.Count(c => char.IsUpper(c)) + 1;
    }
    public static int MinimumNumber(int n, string password)
    {
        int condition_count = 0;
        if (password.Any(c => char.IsUpper(c))) condition_count++;
        if (password.Any(c => char.IsLower(c))) condition_count++;
        if (password.Any(c => char.IsNumber(c))) condition_count++;
        if (password.Any(c => !char.IsLetterOrDigit(c))) condition_count++;

        return Math.Max(4 - condition_count, 6 - password.Length);
    }
    public static int TwoCharacters(string s)
    {
        char[] chars = s.Distinct().ToArray();
        int maxCount = 0;
        int AlternateCount(char a, char b)
        {
            char? previous = null;
            int count = 0;
            foreach (char c in s)
            {
                if (previous == null && (c == a || c == b))
                {
                    previous = c;
                    count++;
                }
                else
                {
                    if (previous == c)
                    {
                        return 0;
                    }
                    if (previous == a && c == b)
                    {
                        count++;
                        previous = b;
                    }
                    if (previous == b && c == a)
                    {
                        count++;
                        previous = a;
                    }
                }
            }
            return count;
        }

        for (int i = 0; i < chars.Length; i++)
        {
            for (int j = i; j < chars.Length; j++)
            {
                if (i == j) continue;
                int count = AlternateCount(chars[i], chars[j]);
                if (maxCount < count) maxCount = count;
                Console.WriteLine($"Count of {chars[i]}, {chars[j]} = {count}");
            }
        }
        Console.WriteLine($"Returning: {maxCount}");
        return maxCount;
    }
    public static string CaesarCipher(string s, int k)
    {

        StringBuilder sb = new StringBuilder(s);

        //A-Z = 65-90 -> -65 = 0 - 25
        //a-z = 97-122 -> -65 = 32 - 57
        for (int i = 0; i < sb.Length; i++)
        {
            int rotations = k % 26;
            if (char.IsLetter(sb[i]))
            {
                if (char.IsUpper(sb[i]))
                {
                    if (sb[i] + rotations > 90)
                    {
                        int remainder = 90 - sb[i];
                        rotations -= remainder;
                        sb[i] = (char)(65 + (rotations - 1));
                    }
                    else
                    {
                        sb[i] += (char)rotations;
                    }

                }
                else
                {
                    if (sb[i] + rotations > 122)
                    {
                        int remainder = 122 - sb[i];
                        rotations -= remainder;
                        sb[i] = (char)(97 + (rotations - 1));
                    }
                    else
                    {
                        sb[i] += (char)rotations;
                    }
                }
            }
        }
        Console.WriteLine($"Returning: {sb.ToString()}");
        return sb.ToString();
    }
    public static int MarsExploration(string s)
    {
        int ChangeCount = 0;
        StringBuilder sb = new StringBuilder(s);
        for (int i = 1; i < s.Length - 1; i += 3)
        {
            if (sb[i - 1] != 'S')
            {
                sb[i - 1] = 'S';
                ChangeCount++;
            }
            if (sb[i] != 'O')
            {
                sb[i] = 'O';
                ChangeCount++;
            }
            if (sb[i + 1] != 'S')
            {
                sb[i + 1] = 'S';
                ChangeCount++;
            }
        }
        return ChangeCount;
    }
    public static string HackerrankInString(string s)
    {
        StringBuilder sb = new StringBuilder("hackerrank");
        foreach (char c in s)
        {
            if (sb.Length != 0)
            {
                if (sb[0] == c)
                {
                    sb.Remove(0, 1);
                }
            }
        }
        if (sb.Length == 0) return "YES";
        return "NO";
    }
    public static string Pangrams(string s)
    {

        //List<char> chars = new List<char>() {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        string trim = s.Replace(" ", "").ToLower().Trim();
        char[] distincts = trim.Distinct().ToArray();

        if (distincts.Length == 26) return "pangram";
        return "not pangram";
    }
    public static List<string> WeightedUniformStrings(string s, List<int> queries)
    {
        List<int> weights = new List<int>();

        char? currentChar = null;
        int currentWeight = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == currentChar) break;      // Case when reach end of s to stop the 
                                                 // loop from double counting weights

            currentChar = s[i];
            currentWeight += s[i] - 96;
            weights.Add(currentWeight);
            Console.WriteLine($"Weight: {currentWeight}");
            for (int j = i; j < s.Length; j++)
            {
                if (i == j) continue;
                if (currentChar == s[j])
                {
                    currentWeight += s[j] - 96;
                    weights.Add(currentWeight);
                    Console.WriteLine($"Weight: {currentWeight}");
                }
                else
                {
                    i = j - 1;
                    currentWeight = 0;
                    break;
                }

            }
        }

        List<string> queryresults = new List<string>();
        foreach (int i in queries)
        {
            if (weights.Contains(i))
            {
                queryresults.Add("Yes");
            }
            else
            {
                queryresults.Add("No");
            }
        }
        return queryresults;
    }
    public static void SeparateNumbers(string s)
    {
        
        if (s[0] == '0') { Console.WriteLine("NO"); return; }
        if (s.Length == 1) { Console.WriteLine("NO"); return; }

        bool isB = false;
        
        int i = 0;
        while (i < s.Length / 2)
        {
            string curStr = s.Substring(0, (i + 1));
            long current = long.Parse(curStr);

            for (int j = (i + 1); j < s.Length; j += curStr.Length)
            {
                current = current + 1;
                curStr = current.ToString();

                if ((j + curStr.Length) <= s.Length && (curStr == s.Substring(j, curStr.Length))) isB = true;
                else isB = false;
                if (!isB) break; // next split does not meet conditions, try next iteration
            }
            i++;
            if (isB) break; // found beautiful string, break out
        }
        string result = isB ? $"YES {s.Substring(0, i)}" : "NO";
        Console.WriteLine(result);
        




        /*
        int starter_val = 0;
        //Check if second number is +1 then first
        for (int i = 0; i < s.Length; i++)
        {
            StringBuilder current_val_str = new StringBuilder();
            current_val_str.Append(s[i]);

            for (int j = 0; j < s.Length;j++)
            {
                
                if (i == j)
                {
                    continue;
                }
                int current_val = int.Parse(current_val_str.ToString());
                string looking_val_str = current_val++.ToString();
                String.Equals()



                if (int.Parse(s[i].ToString()) - int.Parse(s[i].ToString()) == 1)
                {
                    
                    current_val_str.Clear();
                    break;
                }
                current_val_str.Append(s[j].ToString());
                
            }
            starter_val = int.Parse(current_val_str.ToString());
            break; 
        }
        */
        //Console.WriteLine($"Starter Value found: {starter_val}");
    }
}

public class StringsEasy_Client
{
    public static void Run()
    {

        //SuperReducedString();
        //CamelCase();
        //MinimumNumber();
        //TwoCharacters();
        //CaesarCipher();
        //MarsExploration();
        //HackerrankInString();
        //Pangrams();
        //WeightedUniformStrings();
        SeparateNumbers();


    }

    public static void SuperReducedString()
    {
        string s = Input.ReadLine();
        string result = Strings.SuperReducedString(s);
        Console.WriteLine(result);
    }
    public static void CamelCase()
    {
        string s = Input.ReadLine();

        int result = Strings.CamelCase(s);
    }
    public static void MinimumNumber()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        string password = Input.ReadLine();

        int answer = Strings.MinimumNumber(n, password);
        Console.WriteLine(answer);
    }
    public static void TwoCharacters()
    {
        int l = Convert.ToInt32(Input.ReadLine().Trim());

        string s = Input.ReadLine();

        int result = Strings.TwoCharacters(s);
    }
    public static void CaesarCipher()
    {
        int n = Convert.ToInt32(Input.ReadLine().Trim());

        string s = Input.ReadLine();

        int k = Convert.ToInt32(Input.ReadLine().Trim());

        string result = Strings.CaesarCipher(s, k);
    }
    public static void MarsExploration()
    {
        string s = Input.ReadLine();

        int result = Strings.MarsExploration(s);
        Console.WriteLine($"Result: {result}");
    }
    public static void HackerrankInString()
    {
        int q = Convert.ToInt32(Input.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Input.ReadLine();

            string result = Strings.HackerrankInString(s);
            Console.WriteLine($"Result: {result}");
        }
    }
    public static void Pangrams()
    {
        string s = Input.ReadLine();

        string result = Strings.Pangrams(s);
        Console.WriteLine($"Result: {result}");
    }
    public static void WeightedUniformStrings()
    {
        string s = Input.ReadLine();

        int queriesCount = Convert.ToInt32(Input.ReadLine().Trim());

        List<int> queries = new List<int>();

        for (int i = 0; i < queriesCount; i++)
        {
            int queriesItem = Convert.ToInt32(Input.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<string> result = Strings.WeightedUniformStrings(s, queries);


        Console.WriteLine("Results: ");
        foreach (string str in result)
        {
            Console.WriteLine(str);
        }
    }
    public static void SeparateNumbers()
    {
        int q = Convert.ToInt32(Input.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Input.ReadLine();

            Strings.SeparateNumbers(s);
        }
    }

}