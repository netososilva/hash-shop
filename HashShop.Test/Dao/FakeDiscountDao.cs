using HashShop.Repository.Interfaces;
using System.Collections.Generic;

namespace HashShop.Test.Dao
{
    public class FakeDiscountDao : IDiscountDao
    {
        private Dictionary<int, float> _discounts = 
            new Dictionary<int, float> { { 1, 0}, { 2, 0}, { 3, 0.01f } };

        public float Get(int productId)
        {
            return _discounts[productId];
        }
    }
}
