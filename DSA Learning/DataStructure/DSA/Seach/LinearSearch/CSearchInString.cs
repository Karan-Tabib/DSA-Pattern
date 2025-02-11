using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.LinearSearch
{
    internal class CSearchInString
    {
        //static void Main(string[] args)
        //{
        //    // search chararcter 'n' in string
        //    string name = "karan";
        //    char target = 'n';
        //    linearSearch(name, target);
        //}

        private static bool linearSearch(string name, char target)
        {
            if (name.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == target)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool linearSearch2(string name, char target)
        {
            if (name.Length == 0)
            {
                return false;
            }
            foreach (char c in name.ToCharArray())
            {
                if (c == target)
                    return true;
            }
            return false;
        }
    }
}
