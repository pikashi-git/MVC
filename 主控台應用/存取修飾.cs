using 類別庫Lib;

namespace Console
{
    class 存取修飾
    {
        static void Main(string[] args)
        {
            TestGet();

            System.Console.ReadLine(); 
        }

        static void TestGet()
        {
            B b = new B();
            b._public();
            b.GetPrivate();
            b.GetProtected();
            b.GetInternal();
            b._internal();
            //b._private();
            //b._protected();
            b._c_interal();
            //6985

            //
            類別庫A _類別庫A = new 類別庫A();
            _類別庫A.PublicDo();

            類別庫B _類別庫B = new 類別庫B();
            _類別庫B.PublicDo();
            _類別庫B.類別庫B_類別庫A_PublicDo();
        }
    }

    class A
    {
        protected void _protected()
        {
            System.Console.WriteLine("_protected");
        }

        internal void _internal()
        {
            System.Console.WriteLine("_internal");
        }
    }

    class B : A
    {
        public void GetPrivate()
        {
            _private();
        }

        public void GetProtected()
        {
            _protected();
        }

        public void GetInternal()
        {
            _internal();
        }

        public void _public()
        {
            System.Console.WriteLine("_public");
        }

        private void _private()
        {
            System.Console.WriteLine("_private");
        }

        public void _c_interal()
        {
            C c = new C();
            c._interal();
        }
    }

    class C
    {
        internal void _interal()
        {
            System.Console.WriteLine("_c_internal");
        }
    }
}

