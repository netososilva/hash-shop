using HashShop.Repository.Interfaces;
using System;

namespace HashShop.Repository
{
    public class SpecialDateDao : ISpecialDateDao
    {
        public bool IsBlackFriday()
        {
            var blackFridayDate = Environment.GetEnvironmentVariable("BLACK_FRIDAY_DATE");
            var today = DateTime.Today;

            return blackFridayDate.Equals(today);
        }
    }
}
