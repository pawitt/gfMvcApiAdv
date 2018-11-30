using System;
using System.Collections.Generic;
using System.Text;

namespace App02
{
    class Robot
    {
        private readonly IPriceFeeder feeder;
        private readonly IEnumerable< ILog> logs;

        public Guid Id { get; set; } = Guid.NewGuid();

        public Robot(IPriceFeeder feeder,IEnumerable<ILog> logs)
        {
            this.feeder = feeder;
            this.logs = logs;
        }
        public void DoWork()
        {
            foreach(var log in logs)
                log.Write($"{Id} is working");
        }
        public decimal? AveragePrice()
        {
            //var feeder = new CsvPriceFeeder();
            decimal? sum = 0m;
            decimal? price;
            int count = 0;

            price = feeder.GetPrice("abc");
            while (price != null)
            {
                sum = sum + price;
                count++;

                price = feeder.GetPrice("abc");
            }

            if (count == 0) return 0;
            return sum / count;
        }

    }
}