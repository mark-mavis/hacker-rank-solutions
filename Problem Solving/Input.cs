using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInput;

class Input
{
    public static string ReadLine()
    {
        string? user_input = Console.ReadLine();
        if (!String.IsNullOrEmpty(user_input))
        {
            return user_input;
        }
        else
        {
            throw new ArgumentNullException("Please enter an input");
        }
    }
}
