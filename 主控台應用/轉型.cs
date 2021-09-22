using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console
{
    class 繼承與覆寫
    {
        static void Main(string[] args)
        {
            object objNull = null;
            object objEmpty = "";

            //Convert轉型
            System.Console.WriteLine(Convert.ToInt32(objNull));
            /*
            System.Console.WriteLine(Convert.ToInt32(objEmpty)); // System.FormatException: '輸入字串格式不正確
            */
            System.Console.WriteLine(Convert.ToString(objNull));
            System.Console.WriteLine(Convert.ToString(objEmpty));


            //(int)(string)轉型
            /*
            System.Console.WriteLine((int)objNull); // System.NullReferenceException: '並未將物件參考設定為物件的執行個體'
            */
            /*
            System.Console.WriteLine((int)objEmpty); // System.InvalidCastException: '指定的轉換無效'
            */
            System.Console.WriteLine((string)objNull);
            System.Console.WriteLine((string)objEmpty);


            //ToString()轉型
            /*
            System.Console.WriteLine(objNull.ToString()); // System.NullReferenceException: '並未將物件參考設定為物件的執行個體'
            */
            System.Console.WriteLine(objEmpty.ToString());


            System.Console.ReadLine();
        }
    }
}
