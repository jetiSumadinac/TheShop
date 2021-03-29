using System.Collections.Generic;
using System.Threading.Tasks;
using TheShop.Shared.Models;
using TheShop.Shared.Models.SupplierModels;

namespace TheShop.Core.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private List<BaseSupplierModel> suppliers;
        private Supplier1 supp1;
        private Supplier2 supp2;
        private Supplier3 supp3;
        public SupplierService()
        {
            supp1 = new Supplier1();
            supp2 = new Supplier2();
            supp3 = new Supplier3();

            suppliers = new List<BaseSupplierModel>();
            suppliers.Add(supp1);
            suppliers.Add(supp2);
            suppliers.Add(supp3);
        }
        public async Task<ArticleModel> FindArticle(int id, int maxExpectedPrice)
        {
            ArticleModel result = null;
            ArticleModel tempArticle = null;
            foreach (var s in suppliers) {
                var articleExists = s.ArticleInInventory(id);
                if (articleExists) {
                    tempArticle = s.GetArticle(id);
                    if(maxExpectedPrice > tempArticle.ArticlePrice)
                        result = s.GetArticle(id);
                }
            }

            return result;
        }

        #region mock data

        private class Supplier1 : BaseSupplierModel
        {
            override public bool ArticleInInventory(int id)
            {
                return true;
            }

            override public ArticleModel GetArticle(int id)
            {
                return new ArticleModel()
                {
                    ID = 1,
                    Name_of_article = "Article from supplier1",
                    ArticlePrice = 458
                };
            }
        }

        private class Supplier2 : BaseSupplierModel
        {
            override public bool ArticleInInventory(int id)
            {
                return true;
            }

            override public ArticleModel GetArticle(int id)
            {
                return new ArticleModel()
                {
                    ID = 1,
                    Name_of_article = "Article from supplier2",
                    ArticlePrice = 459
                };
            }
        }

        private class Supplier3 : BaseSupplierModel
        {
            override public bool ArticleInInventory(int id)
            {
                return true;
            }

            override public ArticleModel GetArticle(int id)
            {
                return new ArticleModel()
                {
                    ID = 1,
                    Name_of_article = "Article from supplier3",
                    ArticlePrice = 15
                };
            }
        }
        #endregion
    }
}
