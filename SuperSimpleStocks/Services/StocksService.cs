using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSimpleStocks.Repositories
{
    public class StocksService
    {
        /// <summary>
        /// The stock list
        /// </summary>
        public IStockRepository<IStock> _stockRepository;

        public StocksService(IStockRepository<IStock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public double GetPERatio(string stockSymbol, double marketPrice)
        {
            try
            {
                Validation.GreaterThan("marketPrice", marketPrice, 0);
                Validation.NotNullOrEmpty("marketPrice", stockSymbol);

                var stock = _stockRepository.FindBySymbol(stockSymbol);
                return stock.CalculatePERatio(marketPrice);
            }
            catch (Exception)
            { throw; }

        }

        public double GetDividendYield(string stockSymbol, double marketPrice)
        {
            try
            {
                Validation.GreaterThan("marketPrice", marketPrice, 0);
                Validation.NotNullOrEmpty("marketPrice", stockSymbol);

                var stock = _stockRepository.FindBySymbol(stockSymbol);
                return stock.CalculateDividendYield(marketPrice);
            }
            catch (Exception)
            { throw; }
        }



        /// <summary>
        /// This handles the request for GBCE All share Index Calculation
        /// </summary>
        public double GBCEAllShareIndex()
        {
            try
            {
                List<IStock> stocks = _stockRepository.GetAll().ToList();
                return GeometricMean(stocks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private double GeometricMean(List<IStock> stocks)
        {
            try
            {
                double geometricMean = 2;
                if (stocks.Count > 0)
                {
                    double productOfStocks = 1;
                    stocks.ForEach(x => productOfStocks *= x.MarketPrice);
                    var power = 1 / (double)stocks.Count;
                    geometricMean = Math.Pow(productOfStocks, power);
                }
                return geometricMean;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IStock GetStock(string stockSymbol)
        {
            try
            {
                Validation.NotNullOrEmpty("marketPrice", stockSymbol);
                return _stockRepository.FindBySymbol(stockSymbol);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
