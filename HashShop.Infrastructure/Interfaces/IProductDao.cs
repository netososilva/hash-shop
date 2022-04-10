using HashShop.Models;
using System.Collections.Generic;

namespace HashShop.Service.Interfaces
{
    public interface IProductDao
    {
        IEnumerable<Product> GetAll();
    }
}
