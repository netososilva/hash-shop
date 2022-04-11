using HashShop.Api.Controllers;
using HashShop.Dto.Checkout.Request;
using HashShop.Dto.Checkout.Response;
using HashShop.Service;
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
            CheckoutController controller = new CheckoutController(new OrderProcessService(new FakeProductDao(), new FakeDiscountDao()));
            IActionResult objectResult = controller.Post(CreateSimpleRequest());

            var fakeResponse = CreateSimpleResponse();
            var responseResult = (OkObjectResult) objectResult;
            var response = (CheckoutResponse) responseResult.Value;

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

        [TestMethod, Ignore]
        public void Rule3Test()
        {
            //Deverá ser verificado se é black friday e caso seja, você deve adicionar um produto brinde no carrinho.Lembrando que os produtos brindes possuem a
            //flag is_gift = true e não devem ser aceitos em requisições para adicioná - los ao carrinho(em uma loja virtual, esse produto não deveria ir para "vitrine").
            //A data da Black Friday fica a seu critério.
        }
        
        [TestMethod][Ignore]
        public void Rule4Test()
        {
            //Deverá existir apenas uma entrada de produto brinde no carrinho.
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

            productResponseList.Add(new ProductResponseDto(1, 2, 15157, 0, false));
            
            response.Products = productResponseList;
            
            return response;
        }
    }
}
