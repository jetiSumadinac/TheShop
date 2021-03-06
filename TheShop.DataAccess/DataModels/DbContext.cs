using System.Collections.Generic;
using TheShop.Shared.Models;

namespace TheShop.DataAccess.DataModels
{
    public sealed class DbContext
    {
        private static DbContext instance = null;
        private static readonly object padlock = new object();
        public static DbContext Instance {
            get {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DbContext();
                    }
                    return instance;
                }
            }
        }

        public DbContext()
        {
            Articles = new List<ArticleModel>();
        }

        public List<ArticleModel> Articles;
    }
}
