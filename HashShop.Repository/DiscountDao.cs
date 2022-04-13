using Grpc.Net.Client;
using GrpcDiscountClient;
using HashShop.Repository.Interfaces;
using System;

namespace HashShop.Infrastructure
{
    public class DiscountDao : IDiscountDao
    {
        public DiscountDao()
        {
            AppContext.SetSwitch(
                    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        }

        public float Get(int productId)
        {
            var channel = GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("DISCOUNT_API_DATABASE"));
            var client = new Discount.DiscountClient(channel);

            var reply = client.GetDiscount(new GetDiscountRequest { ProductID = productId });

            return reply.Percentage;
        }
    }
}
