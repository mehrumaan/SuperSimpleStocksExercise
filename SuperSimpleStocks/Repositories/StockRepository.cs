using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks.Repositories
{
    public class StockRepository : IStockRepository<IStock>
    {
        readonly IList<IStock> _list;

        public StockRepository()
        {
            _list = new List<IStock>();
        }

        public void Add(IStock stock)
        {
            if(stock == null)
                throw new NullReferenceException();
            else
                _list.Add(stock);

            
        }

        public bool Delete(IStock stock)
        {
            if(stock == null)
                throw new NullReferenceException();
            else
                return _list.Remove(stock);

        }

        public IStock FindBySymbol(string stockSymbol)
        {
            return _list.FirstOrDefault(x => x.Symbol.Equals(stockSymbol));
        }

        public IList<IStock> GetAll()
        {
            return _list;
        }
    }
}
