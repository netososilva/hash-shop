using HashShop.Repository.Interfaces;

namespace HashShop.Test.Dao
{
    public class FakeSpecialDateDao : ISpecialDateDao
    {
        public bool IsBlackFriday()
        {
            return false;
        }
    }
}
