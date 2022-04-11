﻿using HashShop.Api.Controllers;
using HashShop.Dto.Checkout.Request;
using HashShop.Dto.Checkout.Response;
using HashShop.Infrastructure;
using HashShop.Infrastructure.Interfaces;
using HashShop.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var products = new List<ProductRequestDto>();

            products.Add(new ProductRequestDto(1, 2));
            
            CheckoutRequest request = new CheckoutRequest();

            request.Products = products;

            CheckoutController controller = new CheckoutController(new OrderProcess(new ProductDao(), new DiscountDao()));
            ObjectResult objectResult = controller.Post(request);

            CheckoutResponse fakeResponse = new CheckoutResponse();
            var productResponseList = new List<ProductResponseDto>();

            productResponseList.Add(new ProductResponseDto
            {
                Id = 1,
                Quantity = 2,
                UnitAmount = 15157,
                TotalAmount = 30314,
                Discount = 0,
                IsGift = false
            });

            fakeResponse.TotalDiscount = 0;
            fakeResponse.TotalAmountWithDiscount = 30314;
            fakeResponse.TotalAmount = 30314;
            fakeResponse.Products = productResponseList;

            var response = (CheckoutResponse) objectResult.Value;

            Assert.IsNotNull(objectResult);
            Assert.AreEqual(fakeResponse.TotalDiscount, response.TotalDiscount);
            Assert.AreEqual(fakeResponse.TotalAmountWithDiscount, response.TotalAmountWithDiscount);
            Assert.AreEqual(fakeResponse.TotalAmount, response.TotalAmount);

            foreach (var item in response.Products)
            {
                var fakeResponseItem = fakeResponse.Products.FirstOrDefault(x => x.Id == item.Id);

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
    }
}