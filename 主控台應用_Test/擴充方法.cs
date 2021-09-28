using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    using Helper;
    class 擴充方法
    {
        static void Main(string[] args)
        {
            var test1 = new Test1();
            System.Console.WriteLine(test1.Show("Vincent", "38"));

            System.Console.ReadLine();
        }
    }
    class Test1
    {
        public Test1()
        { }
    }
}
namespace Helper
{
    using Console;
    static class Test2
    {
        public static string Show(this Test1 test, string name, string age)
        {
            return $"{ name}: {age}歲";
        }
    }
}
