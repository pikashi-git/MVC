using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Null_Conditional
    {
        static void Main(string[] args)
        {
            string a = null;
            WriteResult(a);

            int? b = null;
            WriteResultInt(b);

            string[] c = null;
            WriteResultIndexer(c);

            System.Console.ReadLine();
        }

        static void WriteResult(object obj)
        {
            try { System.Console.WriteLine("obj.ToString(): " + obj.ToString()); }
            catch (Exception ex) { System.Console.WriteLine("obj.ToString(): " + ex.Message); } //System.NullReferenceException: '並未將物件參考設定為物件的執行個體。'

            try { System.Console.WriteLine("obj?.ToString(): " + obj?.ToString()); }
            catch (Exception ex) { System.Console.WriteLine("obj?.ToString(): " + ex.Message); }
        }

        static void WriteResultIndexer(string[] obj)
        {
            try { System.Console.WriteLine("obj[indexer]: " + obj[3]); }
            catch (Exception ex) { System.Console.WriteLine("obj[indexer]: " + ex.Message); } //System.NullReferenceException: '並未將物件參考設定為物件的執行個體。'

            try { System.Console.WriteLine("obj?[indexer]: " + obj?[3]); }
            catch (Exception ex) { System.Console.WriteLine("obj?[indexer]: " + ex.Message); }
        }

        static void WriteResultInt(int? obj)
        {
            try { System.Console.WriteLine("obj: " + obj); }
            catch (Exception ex) { System.Console.WriteLine("obj: " + ex.Message); } //System.NullReferenceException: '並未將物件參考設定為物件的執行個體。'

            try { System.Console.WriteLine("obj?: " + (obj?.GetType())); }
            catch (Exception ex) { System.Console.WriteLine("obj?: " + ex.Message); }
        }
    }
}
