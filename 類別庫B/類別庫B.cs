using System;

namespace 類別庫Lib
{
    public class 類別庫B
    {
        public void PublicDo()
        {
            System.Console.WriteLine("類別庫B_PublicDO");
        }

        public void 類別庫B_類別庫A_PublicDo()
        {
            類別庫A _類別庫A = new 類別庫A();
            _類別庫A.PublicDo();///
        }
    }
}
