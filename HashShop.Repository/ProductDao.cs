using HashShop.Models.Dao;
using HashShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HashShop.Repository
{
    public class ProductDao : IProductDao
    {
        private readonly IEnumerable<Product> _products;

        public ProductDao()
        {
            try
            {
                var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var productsFromDatabase = File.ReadAllText(Path.Combine(appPath, Environment.GetEnvironmentVariable("DATABASE")));
                
                _products = JsonSerializer.Deserialize<IEnumerable<Product>>(productsFromDatabase);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetAGiftProduct()
        {
            return _products.FirstOrDefault(product => product.IsGift);
        }
    }
}
