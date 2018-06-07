using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperSimpleStocks.Services;
using SuperSimpleStocks.Repositories;
using Moq;

namespace SuperSimpleStocks.Tests
{
    [TestFixture]
    public class TradeServiceTest
    {
        Mock<ITradeRepository<ITrade>> _mockTradeRepository;
        TradeService _main;

        [SetUp]
        public void SetUp()
        {
            _mockTradeRepository = new Mock<ITradeRepository<ITrade>>();
            _mockTradeRepository.Setup(x => x.GetAll()).Returns(new List<ITrade>
                {
                    new Trade(new StockCommon("TEA", 100, 0, 100), DateTime.Now.AddMinutes(-5), 3, Trade.TradeType.Buy,23),
                    new Trade(new StockCommon("TEA", 100, 0, 100),DateTime.Now.AddMinutes(5), 3, Trade.TradeType.Buy,33),
                    new Trade(new StockCommon("POP", 100, 8, 100), DateTime.UtcNow.AddMinutes(-5), 4, Trade.TradeType.Buy,33),
                    new Trade(new StockCommon("ALE", 60, 23, 60), DateTime.UtcNow.AddMinutes(-1), 5, Trade.TradeType.Buy,23),
                    new Trade(new StockPreferred("GIN", 100, 8, 100, 2), DateTime.UtcNow.AddMinutes(-1), 6,  Trade.TradeType.Buy,23),
                    new Trade(new StockCommon("JOE", 250, 13, 250), DateTime.UtcNow.AddMinutes(-1), 7,  Trade.TradeType.Buy,23)
                    
                });

            _main = new TradeService(_mockTradeRepository.Object);
        }

        [TestCase]
        public void Get_Volume_Weighted_Test()
        {
            //Arrange 
            SetUp();

            //Act
            double result = _main.CalculateVolumeWeightedStockPrice("TEA");

            double expectedValue = 23.0;

            //Assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}
