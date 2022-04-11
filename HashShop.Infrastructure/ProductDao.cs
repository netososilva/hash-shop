using HashShop.Models;
using HashShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HashShop.Infrastructure
{
    public class ProductDao : IProductDao
    {
        public IEnumerable<Product> GetAll()
        {
            try
            {
                var productsFromDatabase = File.ReadAllText(@"Database/products.json");

                return JsonSerializer.Deserialize<IEnumerable<Product>>(productsFromDatabase);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }
    }
}
