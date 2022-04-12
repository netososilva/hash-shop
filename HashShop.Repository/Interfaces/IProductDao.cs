using HashShop.Models.Dao;
using System.Collections.Generic;

namespace HashShop.Repository.Interfaces
{
    public interface IProductDao
    {
        Product GetAGiftProduct();
        IEnumerable<Product> GetAll();
    }
}
