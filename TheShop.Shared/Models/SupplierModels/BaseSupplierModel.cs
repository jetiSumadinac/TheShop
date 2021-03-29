namespace TheShop.Shared.Models.SupplierModels
{
    public abstract class BaseSupplierModel
    {
        public abstract bool ArticleInInventory(int id);
        public abstract ArticleModel GetArticle(int id);
    }
}
