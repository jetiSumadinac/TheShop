using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Core.Services.ShopServices
{
    public interface IShopService
    {
        Task OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
        Task<Article> GetById(int id);
    }
}
