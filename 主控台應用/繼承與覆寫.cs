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
            測試繼承與覆寫();

            System.Console.ReadLine();
        }

        static void 測試繼承與覆寫()
        {
            Bus _bus = new Bus();
            _bus.Move();
            _bus.Stop();
        }
    }

    class Transportation
    { 
        public virtual void Move()
        {
            System.Console.WriteLine(@"It's moving!");
        }

        public void Stop()
        {
            System.Console.WriteLine(@"It's stoping!");
        }
    }

    class Bus: Transportation
    {
        public string Color { get; set; }
        public int Speed { get; set; }

        public override void Move()
        {
            System.Console.WriteLine(@"Bus is moving!");
        }

        public new void Stop()
        {
            System.Console.WriteLine(@"Bus is stoping!");
        }
    }
}
