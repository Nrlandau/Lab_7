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
        static bool IsPhoneNumber(string _Phone)
        {
            return Regex.IsMatch(_Phone, @"^\d{3}-\d{3}-\d{4}$");
        }
        static bool IsDate(string _Date)    //dd/mm/yyyy
        {
            int day;
            if (Regex.IsMatch(_Date, @"^[0123]\d/(0\d|1[012])/\d{4}$"))
            {
                day = int.Parse(_Date.Substring(0,2));
                if( day != 0 && day <= GetDaysInMonth(int.Parse(_Date.Substring(3,2)),int.Parse(_Date.Substring(6,4))))
                {
                    return true;
                }
            }
            return false;
        }
        static int GetDaysInMonth(int _Month, int _Year)
        {
            switch(_Month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    return 31;
                case 4: case 6: case 9: case 11:
                    return 30;
                case 2:
                    return IsLeapYear() ? 29 : 28;
                default:
                    return -1;
            }
        }
        static bool IsLeapYear()
        {
            return false;
        }
        static void Main(string[] args)
        {   
            System.Console.WriteLine(IsName("Hello World"));
            System.Console.WriteLine(IsEmail("asdfasdf@asdfa.co"));
            System.Console.WriteLine(IsPhoneNumber("999-999-9999"));
            System.Console.WriteLine(IsDate("12/12/1234"));
            System.Console.WriteLine(IsDate("34/12/1234"));
        }
    }
}
