using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks.Repositories
{
    public interface IStockRepository<T> where T : IStock
    {
        T FindBySymbol(string stockSymbol);
        void Add(T stock);
        bool Delete(T stock);
        IList<T> GetAll();
    }
}
