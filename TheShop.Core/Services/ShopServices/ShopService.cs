using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        //private DatabaseDriver DatabaseDriver;
        private Logger logger;

        private Supplier1 Supplier1;
        private Supplier2 Supplier2;
        private Supplier3 Supplier3;

        public ShopService(IShopRepository repo)
        {
            _repo = repo;
            //DatabaseDriver = new DatabaseDriver();
            logger = new Logger();
            Supplier1 = new Supplier1();
            Supplier2 = new Supplier2();
            Supplier3 = new Supplier3();
        }

        //TODO: this method should break into two seperate methods
        public async Task OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            #region ordering article

            ArticleModel article = null;
            ArticleModel tempArticle = null;
            var articleExists = Supplier1.ArticleInInventory(id);
            if (articleExists)
            {
                tempArticle = Supplier1.GetArticle(id);
                if (maxExpectedPrice < tempArticle.ArticlePrice)
                {
                    articleExists = Supplier2.ArticleInInventory(id);
                    if (articleExists)
                    {
                        tempArticle = Supplier2.GetArticle(id);
                        if (maxExpectedPrice < tempArticle.ArticlePrice)
                        {
                            articleExists = Supplier3.ArticleInInventory(id);
                            if (articleExists)
                            {
                                tempArticle = Supplier3.GetArticle(id);
                                if (maxExpectedPrice < tempArticle.ArticlePrice)
                                {
                                    article = tempArticle;
                                }
                            }
                        }
                    }
                }
            }

            article = tempArticle;
            #endregion

            #region selling article

            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            logger.Debug("Trying to sell article with id=" + id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                //DatabaseDriver.Save(article);
                await _repo.SaveAsync(article);
                logger.Info("Article with id=" + id + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("Could not save article with id=" + id);
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

    //in memory implementation
    //public class DatabaseDriver
    //{
    //    private List<ArticleModel> _articles = new List<ArticleModel>();

    //    public async Task<ArticleModel> GetById(int id)
    //    {
    //        return _articles.Single(x => x.ID == id);
    //    }

    //    public async Task Save(ArticleModel article)
    //    {
    //        _articles.Add(article);
    //    }
    //}

    public class Logger
    {
        public void Info(string message)
        {
            Console.WriteLine("Info: " + message);
        }

        public void Error(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public void Debug(string message)
        {
            Console.WriteLine("Debug: " + message);
        }
    }

    public class Supplier1
    {
        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public ArticleModel GetArticle(int id)
        {
            return new ArticleModel()
            {
                ID = 1,
                Name_of_article = "Article from supplier1",
                ArticlePrice = 458
            };
        }
    }

    public class Supplier2
    {
        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public ArticleModel GetArticle(int id)
        {
            return new ArticleModel()
            {
                ID = 1,
                Name_of_article = "Article from supplier2",
                ArticlePrice = 459
            };
        }
    }

    public class Supplier3
    {
        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public ArticleModel GetArticle(int id)
        {
            return new ArticleModel()
            {
                ID = 1,
                Name_of_article = "Article from supplier3",
                ArticlePrice = 460
            };
        }
    }
}

