using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheShop.DataAccess.DataModels;
using TheShop.Shared.Models;

namespace TheShop.DataAccess.Infrastructure.Shop
{
    public class ShopRepository : BaseRepository<ArticleModel>, IShopRepository
    {
        private DbContext context = DbContext.Instance;

        public async Task<ArticleModel> GetSingleAsync(Expression<Func<ArticleModel, bool>> query)
        {
            return  GetEntities().FirstOrDefault(query); //this will most probably be an Async in real life
        }

        public async Task<int> SaveAsync(ArticleModel data)
        {
            data.ID = generateId();//this should simulate ID generator
            context.Articles.Add(data);

            return data.ID; //TODO: we should return generated ID of artice
        }

        protected override IQueryable<ArticleModel> GetEntities()
        {
            return context.Articles.AsQueryable(); //in real life this would return joined database tables
        }

        #region private methods 
        private int generateId() {
            if (!GetEntities().Any())
                return 1;
            var lastId = GetEntities().LastOrDefault().ID;

            return lastId++;
        }
        #endregion
    }
}
