using Grpc.Net.Client;
using GrpcDiscountClient;
using HashShop.Infrastructure.Interfaces;
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
            var channel = GrpcChannel.ForAddress("http://localhost:50051/");
            var client = new Discount.DiscountClient(channel);
            
            try
            {
                var reply = client.GetDiscount(new GetDiscountRequest { ProductID = productId });

                return reply.Percentage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return 0;
            }
        }
    }
}
