using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console
{
    class 數學
    {
        static void Main(string[] args)
        {
            //取"等於"或是"大於的最小值"
            int a = 1234567;
            int b = 5;
            System.Console.WriteLine((a/b).GetType());
            System.Console.WriteLine((Convert.ToSingle(a) / b).GetType());
            System.Console.WriteLine(Convert.ToSingle(a) / b);
            System.Console.WriteLine(Convert.ToInt32(a / b));
            System.Console.WriteLine(Convert.ToDouble(a) / b);
            System.Console.WriteLine(Math.Ceiling(Convert.ToDouble(a) / b));
            System.Console.WriteLine(Convert.ToInt32(Math.Ceiling(Convert.ToDouble(a) / b)));

            System.Console.ReadLine();
        }
    }
}
