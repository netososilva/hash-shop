using HashShop.Models;
using HashShop.Service.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HashShop.Infrastructure
{
    public class ProductDao : IProductDao
    {
        public IEnumerable<Product> GetAll()
        {
            var productsFromDatabase = File.ReadAllText(@"products.json");

            return JsonSerializer.Deserialize<IEnumerable<Product>>(productsFromDatabase);
        }
    }
}
