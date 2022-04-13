using HashShop.Repository.Interfaces;

namespace HashShop.Test.Dao
{
    public class FakeBlackFridayDao : ISpecialDateDao
    {
        public bool IsBlackFriday()
        {
            return true;
        }
    }
}
