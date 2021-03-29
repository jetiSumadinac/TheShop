using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.DataAccess.Interfaces;
using TheShop.Shared.Models;

namespace TheShop.DataAccess.Infrastructure.Shop
{
    public interface IShopRepository : 
        IInsertable<int, ArticleModel>, 
        ISearchable<ArticleModel>
    {
    }
}
