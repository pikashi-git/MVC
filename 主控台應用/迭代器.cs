using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console
{
    class 迭代器
    {
        static void Main(string[] args)
        {
            TestIEnummerator();

            System.Console.ReadLine();
        }

        static void TestIEnummerator()
        {
            PageCollection pages = new PageCollection();
        }
    }

    class Page
    { }

    class PageCollection : IEnumerator, IEnumerable
    {
        //public string Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {

        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
