using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Shared.Models.SupplierModels
{
    public abstract class BaseSupplierModel
    {
        public abstract bool ArticleInInventory(int id);
        public abstract ArticleModel GetArticle(int id);
    }
}
