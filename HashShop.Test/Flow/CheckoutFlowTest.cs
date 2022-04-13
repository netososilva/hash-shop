using HashShop.Api.Controllers;
using HashShop.Handlers;
using HashShop.Handlers.Base;
using HashShop.Models.Dto.Checkout.Request;
using HashShop.Models.Dto.Checkout.Response;
using HashShop.Test.Dao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HashShop.Test.Flow
{
    [TestClass]
    public class CheckoutFlowTest
    {
        [TestMethod]
        public void SimpleCheckoutTest()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao())));
            IActionResult objectResult = controller.Post(CreateSimpleRequest());

            var fakeResponse = CreateSimpleResponse();
            var responseResult = (OkObjectResult)objectResult;
            var response = (CheckoutResponse)responseResult.Value;

            Assert.IsNotNull(objectResult);
            Assert.AreEqual(fakeResponse.TotalDiscount, response.TotalDiscount);
            Assert.AreEqual(fakeResponse.TotalAmountWithDiscount, response.TotalAmountWithDiscount);
            Assert.AreEqual(fakeResponse.TotalAmount, response.TotalAmount);

            foreach (var item in response.Products)
            {
                var fakeResponseItem = fakeResponse.Products.FirstOrDefault(x => x.Id == item.Id);

                Assert.IsNotNull(fakeResponseItem);
                Assert.AreEqual(fakeResponseItem.Discount, item.Discount);
                Assert.AreEqual(fakeResponseItem.UnitAmount, item.UnitAmount);
                Assert.AreEqual(fakeResponseItem.TotalAmount, item.TotalAmount);
                Assert.AreEqual(fakeResponseItem.IsGift, item.IsGift);
                Assert.AreEqual(fakeResponseItem.Quantity, item.Quantity);
            }
        }

        private CheckoutRequest CreateSimpleRequest()
        {
            CheckoutRequest request = new CheckoutRequest();

            var products = new List<ProductRequestDto>();

            products.Add(new ProductRequestDto(1, 2));
            request.Products = products;

            return request;
        }

        private CheckoutResponse CreateSimpleResponse()
        {
            CheckoutResponse response = new CheckoutResponse();

            var productResponseList = new List<ProductResponseDto>();

            productResponseList.Add(new ProductResponseDto(1, 2, 15157, (15157 * 2),0, false));
            productResponseList.Add(new ProductResponseDto(2, 1, 0, 0, 0, true));

            response.Products = productResponseList;
            response.TotalAmountWithDiscount = (15157 * 2);
            response.TotalAmount = (15157 * 2);
            response.TotalDiscount = 0;

            return response;
        }
    }
}
