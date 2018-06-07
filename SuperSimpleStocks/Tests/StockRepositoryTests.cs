using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperSimpleStocks.Repositories;

namespace SuperSimpleStocks.Tests
{
    [TestFixture]
    class StockRepositoryTests
    {
        IStockRepository<IStock> _stocksRepository;

        [SetUp]
        public void SetUp()
        {
            _stocksRepository = new StockRepository();
        }

        [TestCase]
        public void Add_Stock_Test()
        {
            //Arrage
            Stock newCommonStock = new StockCommon("TEA", 100, 0, 50);

            //Act
            _stocksRepository.Add(newCommonStock);

            //Assert
            Assert.AreEqual(1,_stocksRepository.GetAll().Count);
        }

        [TestCase]
        public void Stock_Find_By_Symbol_Test()
        {
            //Arrage
            Stock newCommonStock = new StockCommon("TEA", 100, 0, 50);
            _stocksRepository.Add(newCommonStock);

            //Act
            var stock = _stocksRepository.FindBySymbol("TEA");

            //Assert
            Assert.NotNull(stock);
            Assert.AreEqual(50, stock.MarketPrice);
        }

    }
}
