using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort
{
    internal class CSubstringUsingRecursion
    {
        //static void Main(string[] args)
        //{
        //    //Q: skip a from string using recursion
        //    //Skip("", "KARAN");
        //    Console.WriteLine(SkipString("KARANTABIB"));
        //}

        private static void SkipChar(string processString, string unProcessString)
        {
            if (string.IsNullOrEmpty(unProcessString))
            {
                Console.WriteLine(processString);
                return;
            }
            char ch = unProcessString[0];
            if (ch == 'a')
            {
                SkipChar(processString, unProcessString.Substring(1));
            }
            else
            {
                SkipChar(processString + ch, unProcessString.Substring(1));
            }
        }

        private static string SkipChar(string unProcessString)
        {
            if (string.IsNullOrEmpty(unProcessString))
            {
                return string.Empty;
            }
            char ch = unProcessString[0];
            if (ch == 'a' || ch == 'A')
            {
                return SkipChar(unProcessString.Substring(1));
            }
            else
            {
                return ch + SkipChar(unProcessString.Substring(1));
            }

        }

        private static string SkipString(string unProcessString)
        {
            //KARANTABIB
            if (string.IsNullOrEmpty(unProcessString))
            {
                return string.Empty;
            }
            char ch = unProcessString[0];

            if (unProcessString.StartsWith("KARAN"))
            {
                return SkipString(unProcessString.Substring(5));
            }
            else
            {
                return ch + SkipString(unProcessString.Substring(1));
            }
        }

        //ahabcAppleaaso
        //skip aap but not from aaple

        private static string SkipAppNotApple(string unProcessString)
        {
            //KARANTABIB
            if (string.IsNullOrEmpty(unProcessString))
            {
                return string.Empty;
            }
            char ch = unProcessString[0];

            if (unProcessString.StartsWith("app") && !unProcessString.StartsWith("apple"))
            {
                return SkipString(unProcessString.Substring(3));
            }
            else
            {
                return ch + SkipString(unProcessString.Substring(1));
            }
        }
    }
}
