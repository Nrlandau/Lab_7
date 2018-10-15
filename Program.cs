using System;
using System.Text.RegularExpressions;

namespace Lab_7
{
    class Program
    {
        static bool IsName(string _name)
        {
            return Regex.IsMatch(_name, @"^[A-Z][\w ]{0,29}$");
        }
        static bool IsEmail(string _email)
        {
            return Regex.IsMatch(_email, @"^[\w\d]{5,30}@[\w\d]{5,10}\.[\w\d]{2,3}$");
        }

        static void Main(string[] args)
        {   
            System.Console.WriteLine(IsName("Hello World"));
            System.Console.WriteLine(IsEmail("asdfasdf@asdfa.co"));
        }
    }
}
