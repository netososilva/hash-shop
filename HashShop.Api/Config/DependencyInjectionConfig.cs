using HashShop.Handlers;
using HashShop.Handlers.Base;
using HashShop.Handlers.Interfaces;
using HashShop.Infrastructure;
using HashShop.Repository;
using HashShop.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HashShop.Api.Config
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IDiscountDao, DiscountDao>();
            services.AddScoped<IProductDao, ProductDao>();
            services.AddScoped<ISpecialDateDao, SpecialDateDao>();

            services.AddScoped<IBlackFridayHandler, BlackFridayHandler>();
            services.AddScoped<ICheckoutBaseHandler, CheckoutBaseHandler>();
            services.AddScoped<IDiscountHandler, DiscountHandler>();
            services.AddScoped<IInvalidGiftHandler, InvalidGiftHandler>();
            services.AddScoped<IProductRepositoryHandler, ProductRepositoryHandler>();
        }
    }
}
