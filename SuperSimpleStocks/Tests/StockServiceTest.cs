using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using SuperSimpleStocks.Repositories;
using SuperSimpleStocks.Services;

namespace SuperSimpleStocks
{
    [TestFixture]
    public class StockServiceTest
    {
        Mock<IStockRepository<IStock>> _mockStockRepository;
        StocksService _main;

        [SetUp]
        public void SetUp()
        {
            _mockStockRepository = new Mock<IStockRepository<IStock>>();
            _mockStockRepository.Setup(x => x.GetAll()).Returns(new List<IStock>
                {
                    new StockCommon("TEA", 100, 0, 100),
                    new StockCommon("POP", 100, 8, 100),
                    new StockCommon("ALE", 60, 23, 60)
                    //new StockPreferred("GIN", 100, 8, 100, 2),
                    //new StockCommon("JOE", 250, 13, 250)
                });

            _main = new StocksService(_mockStockRepository.Object);
        }

        [TestCase]
        public void Get_All_Share_Index_Test()
        {
            //Arrange 
            SetUp();

            //Act
            double result = _main.GBCEAllShareIndex();

            double expectedValue = 100 * 100 * 60;
            expectedValue = Math.Pow(expectedValue, 1.0/3);

            //Assert
            Assert.AreEqual(result, expectedValue);
            
        }
    }
}
