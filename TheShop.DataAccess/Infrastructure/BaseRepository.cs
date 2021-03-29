using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.DataAccess.Infrastructure
{
    public abstract class BaseRepository<T>
    {
        protected abstract IQueryable<T> GetEntities();
    }
}
