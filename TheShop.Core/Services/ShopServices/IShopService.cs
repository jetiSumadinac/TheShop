using System.Threading.Tasks;
using TheShop.Shared.Models;

namespace TheShop.Core.Services.ShopServices
{
    public interface IShopService
    {
        Task OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
        Task<ArticleModel> GetById(int id);
    }
}
