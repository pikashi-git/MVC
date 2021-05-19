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
            Bus _bus = new Bus();
            _bus.Move();
            _bus.Stop();
            // _bus.Fix(); //無法覆寫繼承的成員 'Action.Fix()'，因為其已密封。
            
            System.Console.ReadLine();
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
        public sealed override void Fix()
        {
            System.Console.WriteLine(@"Bus is fixing!");
        }
    }
    class Transportation : Action
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
     class Action
    {
        public virtual void Fix()
        {
            System.Console.WriteLine(@"it's fixing!");
        }
    }
}
