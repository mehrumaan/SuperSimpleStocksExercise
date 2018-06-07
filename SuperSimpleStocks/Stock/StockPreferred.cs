using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    public class StockPreferred:Stock
    {
        readonly double _fixedDividend;

        public StockPreferred(string symbol, double parValue, double lastDividend, double marketPrice, double fixedDividend)
            :base(symbol, parValue, lastDividend, marketPrice)
        {
            _fixedDividend = fixedDividend;
        }

        public override double CalculateDividendYield(double marketPrice)
        {
            try
            {
                Validation.GreaterThan("marketPrice", marketPrice, 0);
                double fixedDividendValue = _fixedDividend / 100;
                return ((fixedDividendValue * ParValue) / marketPrice);
            }
            catch (Exception)
            { throw; }
        }
    }
}
