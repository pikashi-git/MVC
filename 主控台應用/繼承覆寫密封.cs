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
            Bus bus = new Bus();
            bus.Move(); //測試base
            bus.Stop(); //測試new新method
            bus.Fix(); //測試繼承的類已sealed的method
            bus.Slow(); //測試override幾層

            System.Console.ReadLine();
        }
    }

    class Bus : Transportation
    {
        public string Color { get; set; }
        public int Speed { get; set; }

        public override void Move()
        {
            base.Stop();
            System.Console.WriteLine(@"It's Bus Class Move()!");
        }

        public new void Stop()
        {
            System.Console.WriteLine(@"It's Bus Class Stop!");
        }

        /*
        public override void Fix() //無法覆寫繼承的成員 'Transportation.Fix()'，因為其已密封。
        {
            System.Console.WriteLine(@"It's Bus Class Fix()!");
        }
        */

        public override void Slow()
        {
            System.Console.WriteLine(@"it's Bus Class Slow()!");
        }
    }

    class Transportation : Action
    {
        public override void Move()
        {
            System.Console.WriteLine(@"It's Transportation Class Move()!");
        }

        public virtual void Stop()
        {
            System.Console.WriteLine(@"It's Transportation Class Stop()!");
        }

        public sealed override void Fix()
        {
            System.Console.WriteLine(@"It's Transportation Class Fix()!");
        }

        public override void Slow()
        {
            System.Console.WriteLine(@"it's Transportation Class Slow()!");
        }
    }

    class Action
    {
        public virtual void Move()
        {
            System.Console.WriteLine(@"It's Action Class Move()!");
        }

        public virtual void Fix()
        {
            System.Console.WriteLine(@"it's Action Class Fix()!");
        }

        public virtual void Slow()
        {
            System.Console.WriteLine(@"it's Action Class Slow()!");
        }
    }
}
