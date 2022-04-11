using HashShop.Infrastructure;
using HashShop.Infrastructure.Interfaces;
using HashShop.Service;
using HashShop.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HashShop.Api.Config
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IOrderProcessService, OrderProcessService>();
            services.AddScoped<IDiscountDao, DiscountDao>();
            services.AddScoped<IProductDao, ProductDao>();
        }
    }
}
