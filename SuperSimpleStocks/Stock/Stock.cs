using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    public abstract class Stock: IStock
    {
        /// <summary>
        /// Define an Enum for the type of Stock
        /// <summary>
        public enum StockType
        {
            Common,
            Preferred
        }

        public string Symbol { get; set; }

        public StockType Type { get; set; }

        public double LastDividend { get; set; }

        /// <summary>
        /// The ParValue is in pennies
        /// </summary>
        public double ParValue { get; set; }

        public double MarketPrice { get; set; }

        public Stock(string symbol, double parValue, double lastDividend, double marketPrice)
        {
            Symbol = symbol;
            ParValue = parValue;
            LastDividend = lastDividend;
            MarketPrice = marketPrice;
        }

        public double CalculatePERatio(double marketPrice)
        {
            return marketPrice / LastDividend; /// LastDividend is dividend Yield passed through Factory Object
        }

        public abstract double CalculateDividendYield(double marketPrice);

    }
}
