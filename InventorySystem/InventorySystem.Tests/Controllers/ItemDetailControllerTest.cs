using InventorySystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InventorySystem.Tests.Controllers
{
    [TestClass]
    public  class ItemDetailControllerTest
    {
        [TestMethod]
        public async Task DetailFound()
        {
            // Arrange
            ItemDetailController controller = new ItemDetailController();

            // Act
            var result = await controller.Detail(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            // return IViewPageActivator()
        }

        [TestMethod]
        public async Task DetailNotFound()
        {
            // Arrange
            ItemDetailController controller = new ItemDetailController();

            // Act
            var result = await controller.Detail(600) as ViewResult;

            // Assert
            Assert.IsNull(result);
            // return IViewPageActivator()
        }
    }
}
