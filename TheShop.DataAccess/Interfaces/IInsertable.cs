using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.DataAccess.Interfaces
{
    public interface IInsertable<T1,T2>
    {
        Task<T1> SaveAsync(T2 data);
    }
}
