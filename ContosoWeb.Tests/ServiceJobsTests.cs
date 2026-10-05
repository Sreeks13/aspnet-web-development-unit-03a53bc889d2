using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using System.Web.Mvc;
using ContosoWeb.Controllers;

namespace ContosoWeb.Test
{
    [TestClass]
    public class ServiceJobsTests
    {
        [TestMethod]
        public void ServiceJobsByMake_FiltersByMake()
        {
            var controller = new ServiceJobsController();

            var result = controller.ServiceJobsByMake("Toyota")
                as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Toyota", result.ViewBag.Make);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void ServiceJobDetails_ReturnsJobForMatchingMakeAndId()
        {
            var controller = new ServiceJobsController();

            var result = controller.ServiceJobDetails("Toyota", 1)
                as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void ServiceJobDetails_Returns404ForUnknownJob()
        {
            var controller = new ServiceJobsController();

            var result = controller.ServiceJobDetails("Toyota", 999);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void ServiceJobDetails_Returns404ForWrongMake()
        {
            var controller = new ServiceJobsController();

            var result = controller.ServiceJobDetails("Honda", 1);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}