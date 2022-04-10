using HashShop.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashShop.Test
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public void IsAliveTest()
        {
            IsAliveController controller = new IsAliveController();
            StatusCodeResult statusCodeResult = controller.Get();

            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(statusCodeResult.StatusCode, 200);
        }
    }
}
