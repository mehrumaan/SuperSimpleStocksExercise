using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks.Repositories
{
    public class TradeRepository : ITradeRepository<ITrade>
    {
        readonly IList<ITrade> _list;

        public TradeRepository()
        {
            _list = new List<ITrade>();
        }

        public void Add(ITrade trade)
        {
            Validation.NotNull<ITrade>("trade", trade);
            _list.Add(trade);
        }

        public bool Delete(ITrade trade)
        {
            Validation.NotNull<ITrade>("trade", trade);
            return _list.Remove(trade);
        }

        public IList<ITrade> FindByTimeStamp(string stockSymbol, DateTime timeStamp)
        {
            //return _list.Where(trade => trade.Stock.Symbol == stockSymbol  trade => trade.TimeStamp == timeStamp);
            return _list.Where(t => t.Stock.Symbol.Equals(stockSymbol)).Where(t => t.TimeStamp > timeStamp).ToList();
         
        }

        public IList<ITrade> GetAll()
        {
            return _list;
        }
    }
}
