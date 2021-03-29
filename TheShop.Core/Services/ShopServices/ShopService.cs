using System;
using System.Collections.Generic;
using System.Linq;
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

        //TODO: this method should break into two seperate methods
        public async Task OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
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

            await _log.LogDebugAsync("Trying to sell article with id=" + id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                await _repo.SaveAsync(article);
                await _log.LogInfoAsync("Article with id=" + id + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                await _log.LogErrorAsync("Could not save article with id=" + id);
                throw new Exception("Could not save article with id");
            }
            catch (Exception)
            {
            }

            #endregion
        }

        public async Task<ArticleModel> GetById(int id)
        {
            return await _repo.GetSingleAsync(a => a.ID == id);
        }
    }
}

