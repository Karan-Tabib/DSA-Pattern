using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.Recurssion
{
    internal class CPhonePad
    {
        static void CPhonePad_Main(string[] args)
        {
            PhonePad("", "12");

            //Console.WriteLine($"{string.Join(",", PhonePadReturnList("", "12").Cast<string>().ToArray())}");
        }
        static void PhonePad(string process, string unProcess)
        {
            if (string.IsNullOrEmpty(unProcess))
            {
                Console.WriteLine(process);
                return;
            }

            int digit = unProcess[0] - '0';
            for (int i = (digit - 1) * 3; i < digit * 3; i++)
            {
                char ch = (char)('a' + i);
                PhonePad(ch + process, unProcess.Substring(1));
            }

        }

        static ArrayList PhonePadReturnList(string process, string unProcess)
        {
            if (string.IsNullOrEmpty(unProcess))
            {
                ArrayList sublist = new ArrayList();
                sublist.Add(process);
                return sublist;
            }
            ArrayList list = new ArrayList();
            int digit = unProcess[0] - '0';
            for (int i = (digit - 1) * 3; i < digit * 3; i++)
            {
                char ch = (char)('a' + i);
                list.AddRange(PhonePadReturnList(ch + process, unProcess.Substring(1)));
            }
            return list;
        }
    }
}
