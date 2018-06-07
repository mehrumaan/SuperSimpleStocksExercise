using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSimpleStocks.Repositories;

namespace SuperSimpleStocks.Services
{
    public class TradeService
    {
        /// <summary>
        /// The trade list
        /// </summary>
        public ITradeRepository<ITrade> _tradeRepository;
        
        /// <summary>
        /// We need to calculatestock price in trades over 15 minutes
        /// </summary>
        private readonly int StockPriceDurationPeriod = 5;

        public TradeService(ITradeRepository<ITrade> tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }
        /// <summary>'#]
        /// Recording a trade.  An event of Sell/Buy has occured for a stock
        /// and it needs to be recorded.
        /// </summary>
        /// <param name="stock"></param>
        private void recordTrade(Stock stock, int quanitityOfShares, Trade.TradeType trade, double price)
        {
            _tradeRepository.Add(new Trade(stock, DateTime.Now, quanitityOfShares, trade, price));
        }

        public double CalculateVolumeWeightedStockPrice(string stockSymbol, int minutes = 15)
        {

            double volumeWeightedStockPrice = 0,
            totalTradePrice = 0,
            totalQuantity = 0;
            minutes *= -1;
            var dt = DateTime.Now;

            TimeSpan duration = TimeSpan.FromMinutes(15);

            var endTime = DateTime.UtcNow;
            var startTime = endTime.Subtract(duration);
            try { 

                //var stockTrades = _tradeRepository.FindByTimeStamp(stockSymbol, DateTime.Now.AddSeconds(-1 * StockPriceDurationPeriod));
                var stockTrades1 = _tradeRepository.GetAll().Where(x => x.Stock.Symbol.Equals(stockSymbol));
                //List<ITrade> stockTrades = stockTrades1.Where(x => x.TimeStamp >= DateTime.Now.AddSeconds(-1 * StockPriceDurationPeriod)).ToList();
                List<ITrade> stockTrades = stockTrades1.Where(x => x.TimeStamp >= startTime && x.TimeStamp <= endTime).ToList();

                if (stockTrades != null)
                {

                    stockTrades.ToList().ForEach(trade =>
                        {
                            totalTradePrice += (trade.Price * trade.QuantityOfShares);
                            totalQuantity += trade.QuantityOfShares;
                        });

                    if (totalQuantity > 0)
                        volumeWeightedStockPrice = totalTradePrice / totalQuantity;
                }

                return volumeWeightedStockPrice;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
