﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheShop.DataAccess.DataModels;
using TheShop.DataAccess.Interfaces;
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
            context.Articles.Add(data);

            return 1; //TODO: we should return generated ID of artice
        }

        protected override IQueryable<ArticleModel> GetEntities()
        {
            return context.Articles.AsQueryable(); //in real life this would return joined database tables
        }
    }
}
