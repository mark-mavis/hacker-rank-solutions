using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OneMonthPreperationKit
{
    class Pangrams
    {
        public static string RunPangrams(string s)
        {
            s = s.ToLower();
            s = Regex.Replace(s, " ", "");
            if (s.All(char.IsLetter))
            {
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                for (int i = 0; i < 26; i++)
                {
                    if (!s.Contains(alphabet[i])) return "not pangram";
                }
                return "pangram";
            }
            return s;
        }

        public static void Run()
        {
            string s = RunPangrams("We promptly judged antique ivory buckles for the next prize");
            Console.WriteLine(s);
        }

    }
}
