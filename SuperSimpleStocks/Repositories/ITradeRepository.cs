using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks.Repositories
{
    public interface ITradeRepository<T> where T : ITrade
    {
        IList<T> FindByTimeStamp(string stockSymbol,DateTime timeStamp);
        void Add(T trade);
        bool Delete(T trade);
        IList<T> GetAll();
    }
}
