using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.DataAccess.Interfaces
{
    public interface ISearchable<T>
    {
        Task<T> GetSingleAsync(Expression<Func<T, bool>> query);
    }
}
