using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSimpleStocks.Repositories;
using SuperSimpleStocks.Services;

namespace SuperSimpleStocks
{
    class Program
    {        

        private static StocksService _stockService;
        private static TradeService _tradeService;
        private static IStockRepository<IStock> _stockRepository;
        private static ITradeRepository<ITrade> _tradeRepository;

        private const double MarketPrice = 102.0;

        static void Main(string[] args)
        {
            SetUpData();
            GivenMarketPriceAsInputCalculateDividendYield(MarketPrice);
            GivenMarketPriceAsInputCalculateProfitEarningRatio(MarketPrice);
            CalculateVolumeWeightedStockPriceForTradesBasedOnMinutes();
            RecordingTrade(SetupANewTradeForStock("TEA",-100,Trade.TradeType.Buy,100));
            CalculateGbceAllShareIndex();

            Console.ReadLine();
        }

        static void GivenMarketPriceAsInputCalculateDividendYield(double marketPrice)
        {

            foreach (var stock in _stockService._stockRepository.GetAll())
            {
                double DividendYield = _stockService.GetDividendYield(stock.Symbol, marketPrice);

                Console.WriteLine("------");
                Console.WriteLine(stock + " "+"Dividend Yield is: "+DividendYield);
            }
            Console.WriteLine("Completed Calculating Dividend Yield");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        static void GivenMarketPriceAsInputCalculateProfitEarningRatio(double marketPrice)
        {

            foreach (var stock in _stockService._stockRepository.GetAll())
            {
                 double ProfitToEarningsRatio = _stockService.GetPERatio(stock.Symbol, marketPrice);

                Console.WriteLine("------");
                Console.WriteLine(stock + " " + "The P/E Ratio is " + ProfitToEarningsRatio);
            }
            Console.WriteLine("Completed P/E Ratio");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        static void RecordingTrade(Trade trade)
        {
            Console.WriteLine("Record Trade");

            _tradeService._tradeRepository.Add(trade);
            Console.WriteLine(trade);

            Console.WriteLine("##ALL TRADES##");
            DisplayAllTrades();
            Console.WriteLine("##############");

            Console.WriteLine("Completed Record Trade");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        static void CalculateVolumeWeightedStockPriceForTradesBasedOnMinutes(int minutes = 15)
        {
            Console.WriteLine("Calculating Volume Weighted Stock Price for all trades placed in last 15 minutes....");

            foreach (var stock in _stockService._stockRepository.GetAll())
            {
                double VolumeWeightedStockPrice = _tradeService.CalculateVolumeWeightedStockPrice(stock.Symbol, minutes);

                Console.WriteLine("------");
                Console.WriteLine(stock + " " + "Volume Weighted Stock Price is " + VolumeWeightedStockPrice);
            }
            Console.WriteLine("Completed Calculating Volume Weighted Stock Price");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

        }

        static void CalculateGbceAllShareIndex()
        {
            Console.WriteLine("Calculating GBCE All Share Index....");

            Console.WriteLine("GBCE All Share Index = " + _stockService.GBCEAllShareIndex());
            Console.WriteLine("Completed GBCE All Share Index");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        static void DisplayAllStocks()
        {
            foreach (var stock in _stockService._stockRepository.GetAll())
            {
                Console.WriteLine("------");
                Console.WriteLine(stock);
            }
        }

        static void DisplayAllTrades()
        {
            foreach (var trade in _tradeService._tradeRepository.GetAll())
            {
                Console.WriteLine("------");
                Console.WriteLine(trade);
            }
        }

        static void SetUpData()
        {
            _stockRepository.Add(new StockCommon("TEA", 100, 0, 100));
            _stockRepository.Add(new StockCommon("POP", 100, 8, 100));
            _stockRepository.Add(new StockCommon("ALE", 60, 23, 60));
            _stockRepository.Add(new StockPreferred("GIN", 100, 8, 100, 2));
            _stockRepository.Add(new StockCommon("JOE", 250, 13, 250));

            _stockService = new StocksService(_stockRepository);

            _tradeRepository.Add(new Trade(new StockCommon("TEA", 100, 0, 100), DateTime.Now.AddMinutes(-5), 3, Trade.TradeType.Buy,23));
            _tradeRepository.Add(new Trade(new StockCommon("TEA", 100, 0, 100),DateTime.Now.AddMinutes(5), 3, Trade.TradeType.Buy,33));
            _tradeRepository.Add(new Trade(new StockCommon("POP", 100, 8, 100), DateTime.UtcNow.AddMinutes(-5), 4, Trade.TradeType.Buy,33));
            _tradeRepository.Add(new Trade(new StockCommon("ALE", 60, 23, 60), DateTime.UtcNow.AddMinutes(-1), 5, Trade.TradeType.Buy,23));
            _tradeRepository.Add(new Trade(new StockPreferred("GIN", 100, 8, 100, 2), DateTime.UtcNow.AddMinutes(-1), 6,  Trade.TradeType.Buy,23));
            _tradeRepository.Add(new Trade(new StockCommon("JOE", 250, 13, 250), DateTime.UtcNow.AddMinutes(-1), 7,  Trade.TradeType.Buy,23));                             

            _tradeService = new TradeService(_tradeRepository);

        }



        static Trade SetupANewTradeForStock(string stockSymbol, int qty, Trade.TradeType type,double price)
        {
            return new Trade(_stockService._stockRepository.FindBySymbol(stockSymbol),DateTime.Now,qty, type, price);
        }
    }
}
