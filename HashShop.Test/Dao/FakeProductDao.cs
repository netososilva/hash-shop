using HashShop.Models;
using HashShop.Service.Interfaces;
using System.Collections.Generic;

namespace HashShop.Test.Dao
{
    public class FakeProductDao : IProductDao
    {
        private static List<Product> _products = GetFakeDatabase();

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        private static List<Product> GetFakeDatabase()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Amount = 15157,
                    Description = "An item for tests",
                    IsGift = false,
                    Title = "Test item 1"
                }
            };
        }
    }
}
