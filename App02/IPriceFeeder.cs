using System;
using System.Collections.Generic;
using System.Text;

namespace App02
{
    interface IPriceFeeder
    {
        decimal? GetPrice(string symbol);
    }
}
