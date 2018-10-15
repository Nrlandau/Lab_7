using System;
using System.Text.RegularExpressions;

namespace Lab_7
{
    class Program
    {
        static bool IsName(string name)
        {
            return Regex.IsMatch(name, @"^[A-Z][\w ]{0,29}$");
        }
        static void Main(string[] args)
        {   
            System.Console.WriteLine(IsName("Hello World"));
        }
    }
}
