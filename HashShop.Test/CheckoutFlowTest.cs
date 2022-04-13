using HashShop.Api.Controllers;
using HashShop.Handlers;
using HashShop.Handlers.Base;
using HashShop.Models;
using HashShop.Models.Dto.Checkout.Request;
using HashShop.Models.Dto.Checkout.Response;
using HashShop.Models.Mapper;
using HashShop.Test.Dao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HashShop.Test
{
    [TestClass]
    public class CheckoutFlowTest
    {
        [TestMethod]
        public void CheckoutWithProductsWithouDiscountTest()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao(), new FakeSpecialDateDao())));
            
            IActionResult objectResult = controller.Post(CreateRequestWithProductsWithoutDiscount());

            var fakeResponse = CreateResponseWithProductsWithoutDiscount();
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

        [TestMethod]
        public void CheckoutWithProductsWithDiscountTest()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao(), new FakeSpecialDateDao())));
            IActionResult objectResult = controller.Post(CreateRequestWithProductsWithDiscount());

            var fakeResponse = CreateResponseWithProductsWithDiscount();
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

        [TestMethod]
        public void CheckoutInBlackFriday()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao(), new FakeBlackFridayDao())));

            IActionResult objectResult = controller.Post(CreateRequestWithProductsWithoutDiscount());
            
            var fakeResponse = CreateResponseWithProductsWithoutDiscount();
            var responseResult = (OkObjectResult)objectResult;
            var response = (CheckoutResponse)responseResult.Value;
            var containsAGiftProduct = response.Products.Any(product => product.IsGift);

            Assert.IsNotNull(objectResult);
            Assert.IsTrue(containsAGiftProduct);
        }

        [TestMethod]
        public void CheckoutWithGiftProduct()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao(), new FakeSpecialDateDao())));

            IActionResult objectResult = controller.Post(CreateRequestWithGiftProduct());

            var invalidRequest = objectResult is BadRequestObjectResult;

            Assert.IsTrue(invalidRequest);
        }

        [TestMethod]
        public void ErrorOnDiscountApiTest()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeErrorDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao(), new FakeSpecialDateDao())));

            IActionResult objectResult = controller.Post(CreateRequestWithProductsWithoutDiscount());
            
            var fakeResponse = CreateResponseWithProductsWithoutDiscount();
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
        
        [TestMethod]
        public void CheckoutWithMoreThanOneGiftProduct()
        {
            InvalidGiftHandler invalidGiftHandler = new InvalidGiftHandler();

            var orderWithTwoGiftProducts = new Order();

            orderWithTwoGiftProducts.Products.Add(ProductOrder.CreateGiftProduct(1));
            orderWithTwoGiftProducts.Products.Add(ProductOrder.CreateGiftProduct(2));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                invalidGiftHandler.Handle(orderWithTwoGiftProducts));
        }

        [TestMethod]
        public void RequestWithNullProduct()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao(), new FakeSpecialDateDao())));
            CheckoutRequest request = new CheckoutRequest();

            IActionResult objectResult = controller.Post(request);

            Assert.IsTrue(objectResult is BadRequestResult);
        }

        [TestMethod]
        public void RequestWithEmptyProducts()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao(), new FakeSpecialDateDao())));
            CheckoutRequest request = new CheckoutRequest();

            request.Products = new List<ProductRequestDto>();

            IActionResult objectResult = controller.Post(request);

            Assert.IsTrue(objectResult is BadRequestResult);
        }

        [TestMethod]
        public void RequestWithInvalidIdProduct()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao(), new FakeSpecialDateDao())));
            CheckoutRequest request = new CheckoutRequest();

            request.Products = new List<ProductRequestDto>()
            {
                new ProductRequestDto(22, 2)
            };

            IActionResult objectResult = controller.Post(request);

            Assert.IsTrue(objectResult is BadRequestObjectResult);

            request.Products = new List<ProductRequestDto>()
            {
                new ProductRequestDto(-2, 2)
            };

            objectResult = controller.Post(request);

            Assert.IsTrue(objectResult is BadRequestResult);
        }

        [TestMethod]
        public void RequestWithInvalidQuantityProduct()
        {
            CheckoutController controller = new CheckoutController(
                new CheckoutBaseHandler(
                    new ProductRepositoryHandler(new FakeProductDao()),
                    new DiscountHandler(new FakeDiscountDao()),
                    new InvalidGiftHandler(),
                    new BlackFridayHandler(new FakeProductDao(), new FakeSpecialDateDao())));
            CheckoutRequest request = new CheckoutRequest();

            request.Products = new List<ProductRequestDto>()
            {
                new ProductRequestDto(2, -2)
            };

            IActionResult objectResult = controller.Post(request);

            Assert.IsTrue(objectResult is BadRequestResult);

            request.Products = new List<ProductRequestDto>()
            {
                new ProductRequestDto(2, 0)
            };

            objectResult = controller.Post(request);

            Assert.IsTrue(objectResult is BadRequestResult);
        }

        private CheckoutRequest CreateRequestWithProductsWithoutDiscount()
        {
            CheckoutRequest request = new CheckoutRequest();

            var products = new List<ProductRequestDto>();

            products.Add(new ProductRequestDto(1, 2));
            request.Products = products;

            return request;
        }
        private CheckoutResponse CreateResponseWithProductsWithoutDiscount()
        {
            CheckoutResponse response = new CheckoutResponse();

            var productResponseList = new List<ProductResponseDto>();

            productResponseList.Add(new ProductResponseDto(1, 2, 15157, (15157 * 2),0, false));
            
            response.Products = productResponseList;
            response.TotalAmountWithDiscount = (15157 * 2);
            response.TotalAmount = (15157 * 2);
            response.TotalDiscount = 0;

            return response;
        }

        private CheckoutRequest CreateRequestWithProductsWithDiscount()
        {
            CheckoutRequest request = new CheckoutRequest();
            FakeProductDao fakeProductDao = new FakeProductDao();

            var productWithDiscount = fakeProductDao.GetById(3);
            
            request.Products = new List<ProductRequestDto> {
                new ProductRequestDto(productWithDiscount.Id, 2)
            };

            return request;
        }
        private CheckoutResponse CreateResponseWithProductsWithDiscount()
        {
            FakeProductDao fakeProductDao = new FakeProductDao();

            var product = fakeProductDao.GetById(3);
            var quantity = 2;
            var order = new Order();
            var productWithDiscount = new ProductOrder(product.Id, quantity, product.Amount,
                product.IsGift);

            productWithDiscount.SetDiscount(0.01f);

            order.Products.Add(productWithDiscount);

            return OrderMapping.ToCheckoutResponse(order);
        }

        private CheckoutRequest CreateRequestWithGiftProduct()
        {
            CheckoutRequest request = new CheckoutRequest();

            var products = new List<ProductRequestDto>();

            products.Add(new ProductRequestDto(1, 2));
            request.Products = products;

            products.Add(new ProductRequestDto(2, 1));
            request.Products = products;

            return request;
        }

    }
}
