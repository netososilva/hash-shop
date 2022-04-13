using HashShop.Repository.Interfaces;
using System;

namespace HashShop.Test.Dao
{
    public class FakeErrorDiscountDao : IDiscountDao
    {
        public float Get(int productId)
        {
            throw new Exception("Erro ao consultar a API");
        }
    }
}
