﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console
{
    class 函式
    {
        static void Main(string[] args)
        {
            string s;
            TestDefaultArgs(s = "aaa");
            TestDefaultArgs(arg: "aaa");
            TestDefaultArgs(arg: "aaa", arg1: "bbb");

            //TestToList();

            System.Console.ReadLine();
        }
        static void TestDefaultArgs(string arg)
        {
            System.Console.WriteLine(arg);
        }
        static void TestDefaultArgs(string arg, string arg1)
        {
            System.Console.WriteLine(arg+","+arg1);
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
