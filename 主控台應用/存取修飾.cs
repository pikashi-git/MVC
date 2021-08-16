using System;
using 類別庫Lib;

namespace Console
{
    class 存取修飾
    {
        static void Main(string[] args)
        {
            測試存取();

            System.Console.ReadLine();
        }

        static void 測試存取()
        {
            類別B _類別B = new 類別B();
            //Public存取
            _類別B.類別BPublic();
            //internal存取
            _類別B.類別BInternal();
            ////Protected存取
            //try
            //{
            //    _類別B.類別BProtected();
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}
            ////Private存取
            //try
            //{
            //    _類別B.類別BPrivate();
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}

            //@@存取繼承的類別A
            //Public存取
            _類別B.類別APublic();
            //internal存取
            _類別B.類別AInternal();
            //Protected存取
            //try
            //{
            //    _類別B.類別AProtected();
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}
            ////Private存取
            //try
            //{
            //    _類別B.類別APrivate();
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}
        }
    }

    class 類別B : 類別A
    {
        public void 類別BPublic()
        {
            System.Console.WriteLine("類別B: public");
        }

        internal void 類別BInternal()
        {
            System.Console.WriteLine("類別B: internal");
        }

        protected void 類別BProtected()
        {
            System.Console.WriteLine("類別B: protected");
        }

        private void 類別BPrivate()
        {
            System.Console.WriteLine("類別B: private");
        }

    }

    class 類別A
    {
        public void 類別APublic()
        {
            System.Console.WriteLine("類別A: public");
        }

        internal void 類別AInternal()
        {
            System.Console.WriteLine("類別A: internal");
        }

        protected void 類別AProtected()
        {
            System.Console.WriteLine("類別A: protected");
        }

        private void 類別APrivate()
        {
            System.Console.WriteLine("類別A: private");
        }
    }
}

