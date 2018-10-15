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
                    return IsLeapYear(_Year) ? 29 : 28;
                default:
                    return -1;
            }
        }
        static bool IsLeapYear(int _Year)
        {
            if( _Year % 4 ==0)
                if( _Year % 100 != 0 || _Year % 400 == 0)
                    return true;
            return false;
        }
        static bool IsHtml(string _Html)
        {
            return Regex.IsMatch(_Html, @"^<(?<element>.+)>.*</\k<element>>$");
        }
        
        static string GetInputAndTest(string _Question ,string _Wrong,string _Condition, Func<string,bool> test)
        {
            string input;
            System.Console.WriteLine("{0}, {1}", _Question,_Condition);
            input = System.Console.ReadLine();
            while(!test(input))
            {
                System.Console.WriteLine("{0}, {1}",_Wrong,_Condition);
                input = System.Console.ReadLine();
            }
            return input;
        }
        static void Main(string[] args)
        {   
            //while (true)
            {
                GetInputAndTest("Input a name", "Invalid name","it must start with a capitol letter and be 5 or more letters long", IsName);
                GetInputAndTest("Input a date", "Invalid date" , "it must be dd/mm/yyyy format",IsDate);
                GetInputAndTest("Input an email address", "Invalid email address", "it must start with 5-30 letters, '@', 5-10letters, '.', 2,3 letters", IsEmail);
                GetInputAndTest("Input a phone number", "Invalid phone number", "it must be xxx-xxx-xxxx", IsPhoneNumber);
                GetInputAndTest("Input Html", "Invalid Html", "<*>asdfasdf</*>", IsHtml);
            }
        }
    }
}
