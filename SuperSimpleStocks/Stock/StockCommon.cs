using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    public class StockCommon:Stock
    {
        public StockCommon(string symbol, double parValue, double lastDividend, double marketPrice)
            :base(symbol, parValue, lastDividend, marketPrice)
        {}

        public override double CalculateDividendYield(double marketPrice)
        {
            try
            {
                Validation.GreaterThan("marketPrice", marketPrice, 0);

                return LastDividend / marketPrice;
            }
            catch (Exception)
            { throw; }
        }
    }
}
