using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    class DividendYield: Stock
    {
        public DividendYield(string symbol, double parValue, double lastDividend, double marketPrice)
            :base(symbol, parValue, lastDividend, marketPrice)
        { }

        public override double CalculateDividendYield(double inputMarketPrice)
        {
            switch (Type)
            {
                case StockType.Common:
                    return LastDividend / inputMarketPrice;

               // case StockType.Preferred:
                   // return ((FixedDividend / 100) * ParValue) / inputMarketPrice;

                default:
                    return double.NaN;
            }
        }
    }
}
