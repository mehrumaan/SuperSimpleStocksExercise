using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    class Trade: ITrade
    {
        /// <summary>
        /// Let's define the two Trade Types
        /// </summary>
        public enum TradeType
        { 
            Buy,
            Sell
        }

        public IStock Stock { get; set; }
        public DateTime TimeStamp {get; set;}
        public int QuantityOfShares { get; set; }
        public TradeType Type { get; set; }
        public double Price { get; set; }

        public Trade(IStock stock, DateTime timeStamp, int quantity, TradeType type, double price)
        {
            Stock = stock;
            TimeStamp = timeStamp;
            QuantityOfShares = quantity;
            Type = type;
            Price = price;
        }
    }
}
