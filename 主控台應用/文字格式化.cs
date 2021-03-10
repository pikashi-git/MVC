using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console
{
    class 文字格式化
    {
        static void Main(string[] args)
        {
            文字格式();

            System.Console.ReadLine();
        }

        static void 文字格式()
        {
            string name = System.Console.ReadLine();
            System.Console.WriteLine(@"我是{0}", name);
            System.Console.WriteLine(string.Format(@"我是{0}", name));
        }
    }
}

