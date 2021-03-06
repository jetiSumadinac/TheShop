using System.Threading.Tasks;
using TheShop.Shared.Models;

namespace TheShop.Core.Services.SupplierService
{
    public interface ISupplierService
    {
        Task<ArticleModel> FindArticle(int id, int maxExpectedPrice);

    }
}
