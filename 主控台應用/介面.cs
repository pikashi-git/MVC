namespace Console
{
    class 介面
    {
        static void Main(string[] args)
        {
            介面測試();

            System.Console.ReadLine();
        }

        static void 介面測試()
        {
            ITransportation _iTransportation = new Bus();
            _iTransportation.Color = @"綠色";
            System.Console.WriteLine(_iTransportation.Color);
            _iTransportation.Move();
            _iTransportation.Stop();

            ITransportation _iTransportation1 = new Scooter();
            _iTransportation1.Color = @"黃色";
            System.Console.WriteLine(_iTransportation1.Color);
            _iTransportation1.Move();
            _iTransportation1.Stop();
        }
    }

    interface ITransportation
    {
        void Move();
        void Stop();
        string Color { get; set; }
    }

    class Bus : ITransportation
    {
        public string Color { get; set; }

        public void Move()
        {
            System.Console.WriteLine("Bus is moving!");
        }

        public void Stop()
        {
            System.Console.WriteLine("Bus is stoping!");
        }
    }

    class Scooter : ITransportation
    {
        public string Color { get; set; }

        public void Move()
        {
            System.Console.WriteLine("Scooter is moving!");
        }

        public void Stop()
        {
            System.Console.WriteLine("Scooter is stoping!");
        }
    }
}

