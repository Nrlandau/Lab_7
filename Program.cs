using System;
using System.Text.RegularExpressions;

namespace Lab_7
{
    class Program
    {
        static bool IsName(string _name) // Must be more than 5 characters and the first one must be uppercase.
        {
            return Regex.IsMatch(_name, @"^[A-Z][\w ]{0,29}$");
        }
        static bool IsEmail(string _email)  //5-30 letters,'@',5-10 letters,'.',2-3 letters
        {
            return Regex.IsMatch(_email, @"^[\w\d]{5,30}@[\w\d]{5,10}\.[\w\d]{2,3}$");
        }
        static bool IsPhoneNumber(string _Phone) //xxx-xxx-xxxx
        {
            return Regex.IsMatch(_Phone, @"^\d{3}-\d{3}-\d{4}$");
        }
        static bool IsDate(string _Date)    //dd/mm/yyyy
        {
            int day;
            if (Regex.IsMatch(_Date, @"^[0123]\d/(0\d|1[012])/\d{4}$"))
            {
                day = int.Parse(_Date.Substring(0,2));
                if( day != 0 && day <= GetDaysInMonth(int.Parse(_Date.Substring(3,2)),int.Parse(_Date.Substring(6,4)))) //Tests if the day is a valid day for the month.
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
        static bool IsHtml(string _Html) //<*>   junk  </*>
        {
            return Regex.IsMatch(_Html, @"^<(?<element>.+)>.*</\k<element>>$");
        }
        static string hasN(string name)
        {
            switch (name.ToLower()[0])
            {
                case 'a': case 'e' : case 'i' : case 'o' : case 'u':
                return "n";
                default:
                return "";
            }
        }
        
        static string GetInputAndTest(string _Name ,string _Condition, Func<string,bool> test)
        {
            string input;
            System.Console.WriteLine("Input a{2} {0}, {1}",_Name,_Condition , hasN(_Name));
            input = System.Console.ReadLine();
            while(!test(input))
            {
                System.Console.WriteLine("Invalid {0}, {1}",_Name,_Condition);
                input = System.Console.ReadLine();
            }
            return input;
        }
        static void Main(string[] args)
        {   
            //while (true)
            {
                GetInputAndTest("name","it must start with a capital letter and be 5 or more letters long", IsName);
                GetInputAndTest("date" , "it must be dd/mm/yyyy format",IsDate);
                GetInputAndTest("email address",  "it must start with 5-30 letters, '@', 5-10letters, '.', 2,3 letters", IsEmail);
                GetInputAndTest("phone number",  "it must be xxx-xxx-xxxx", IsPhoneNumber);
                GetInputAndTest("Html Code", "<*>asdfasdf</*>", IsHtml);
            }
        }
    }
}