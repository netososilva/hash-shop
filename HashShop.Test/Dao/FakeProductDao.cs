using HashShop.Models.Dao;
using HashShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HashShop.Test.Dao
{
    public class FakeProductDao : IProductDao
    {
        private static List<Product> _products = GetFakeDatabase();

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(product => product.Id == id);
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
                },
                new Product
                {
                    Id = 2,
                    Amount = 0,
                    Description = "A gift item for tests",
                    Title = "Gift item",
                    IsGift = true
                },
                new Product
                {
                    Id = 3,
                    Amount = 10000,
                    Description = "An item with discount for tests",
                    IsGift = false,
                    Title = "Test item 3"
                }
            };
        }

        public Product GetAGiftProduct()
        {
            return _products.FirstOrDefault(product => product.IsGift);
        }
    }
}
