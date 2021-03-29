using System;
using System.Threading.Tasks;
using TheShop.Core.Services.LogService;
using TheShop.Core.Services.SupplierService;
using TheShop.DataAccess.Infrastructure.Shop;
using TheShop.Shared.Models;

namespace TheShop.Core.Services.ShopServices
{
    public class ShopService : IShopService
    {
        public Task Test()
        {
            throw new NotImplementedException();
        }

        private readonly IShopRepository _repo;
        private readonly ISupplierService _supplierService;
        private readonly ILogService _log;

        public ShopService(IShopRepository repo, ISupplierService supplierService, ILogService log)
        {
            _repo = repo;
            _supplierService = supplierService;
            _log = log;
        }

        public async Task OrderArticle(int id, int maxExpectedPrice)
        {
            #region ordering article

            ArticleModel article = null;
            article = await _supplierService.FindArticle(id, maxExpectedPrice);

            #endregion

            #region selling article

            if (article == null)
            {
                throw new Exception("Could not order article");
            }

        
            #endregion
        }

        public async Task SellArticle(int buyerId, ArticleModel article) {
            await _log.LogDebugAsync("Trying to sell article");//Id is not generated yet
            int? articleID = null;
            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                articleID = await _repo.SaveAsync(article);
                await _log.LogInfoAsync("Article with id=" + articleID + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                await _log.LogErrorAsync("Could not save article with id=" + articleID);
                throw new Exception("Could not save article with id");
            }
            catch (Exception)
            {
            }


        }

        public async Task<ArticleModel> GetById(int id)
        {
            return await _repo.GetSingleAsync(a => a.ID == id);
        }
    }
}

