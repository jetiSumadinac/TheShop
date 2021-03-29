using System.Threading.Tasks;
using TheShop.Shared.Models;

namespace TheShop.Core.Services.ShopServices
{
    public interface IShopService
    {
        Task OrderArticle(int id, int maxExpectedPrice);
        Task SellArticle(int buyerId, ArticleModel article);
        Task<ArticleModel> GetById(int id);
    }
}
