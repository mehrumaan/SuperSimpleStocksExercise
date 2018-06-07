﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    public interface ITrade
    {
        IStock Stock { get; }
        DateTime TimeStamp { get; }
        int QuantityOfShares { get; }
        double Price { get; }

    }
}
