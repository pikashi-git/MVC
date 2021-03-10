using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console
{
    class TOLIST函式
    {
        static void Main(string[] args)
        {
            TestToList();

            System.Console.ReadLine();
        }

        static void TestToList()
        {
            string[] a = { "a", "b", "c", "d", "e", "f", "g" };
            List<string> aList = a.ToList();
            aList.Add("h");
            aList.Remove("c");
            aList.Reverse();
            aList.RemoveAt(4);
            foreach (string s in aList)
            {
                System.Console.WriteLine(s);
            }
        }

    }
}
