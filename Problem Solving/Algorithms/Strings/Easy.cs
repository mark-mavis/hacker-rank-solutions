
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
using System.Security.Cryptography.X509Certificates;

namespace Algorithms;

public partial class Strings
{
    //EASY IMPLEMENTATIONS
    public static string SuperReducedString(string str)
    {
        return new string(str.ToCharArray().Distinct().ToArray());
    }

}

class StringsEasy_Client
{
    public static void Run()    {
        
        SuperReducedString();

    }

    public static void SuperReducedString()
    {
        string s = Input.ReadLine();
        string result = Strings.SuperReducedString(s);
        Console.WriteLine(result);
    }

    
}