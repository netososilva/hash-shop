using HashShop.Infrastructure.Interfaces;

namespace HashShop.Test.Dao
{
    public class FakeDiscountDao : IDiscountDao
    {
        public float Get(int productId)
        {
            return 0;
        }
    }
}
