using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    public interface IStock
    {
        string Symbol {get;}
        double ParValue { get; }
        double LastDividend { get; }
        double MarketPrice { get; }
        double CalculateDividendYield(double marketPrice);
        double CalculatePERatio(double marketPrice);
    }
}
