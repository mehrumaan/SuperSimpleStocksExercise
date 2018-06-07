using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks.Tests
{
    [TestFixture]
    public class StockTests
    {
        [TestCase]
        public void Calculate_PE_Ratio_Test()
        {
            //Arrange
            IStock stock = new StockCommon("ALE", 60, 23, 90);

            //Act
            double peRatio = stock.CalculatePERatio(90);
            double lastDividend = 23;
            double marketPrice = 90;
            double expectedValue = marketPrice / lastDividend;

            //Assert
            Assert.AreEqual(expectedValue, peRatio);
        }

        [TestCase]
        public void Calculate_Preferred_Stock_DividendYield_Test()
        {
            //Arrange
            IStock stock = new StockPreferred("GIN", 100, 8, 90, 2);

            //Act
            double dividendYield = stock.CalculateDividendYield(90);
            double fixedDividend = 2;
            double marketPrice = 90;
            double expectedValue = fixedDividend / marketPrice;

            //Assert
            Assert.AreEqual(expectedValue, dividendYield);
        }

        [TestCase]
        public void Calculate_Common_Stock_DividendYield_Test()
        {
            //Arrange
            IStock stock = new StockCommon("TEA", 100, 0, 100);

            //Act
            double dividendYield = stock.CalculateDividendYield(10);

            //Assert
            dividendYield.Equals(0);
        }
    }
}
