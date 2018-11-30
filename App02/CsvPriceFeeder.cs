using System;
using System.Collections.Generic;
using System.Text;

namespace App02
{
    class CsvPriceFeeder : IPriceFeeder
    {
        private decimal[] prices = new decimal[]
        {
            10m,10.1m,10.2m
        };
        private int index = 0;
        public decimal? GetPrice(string symbol)
        {
            if (index++ >= prices.Length) return null;
            
            return 10;
        }
    }
}
