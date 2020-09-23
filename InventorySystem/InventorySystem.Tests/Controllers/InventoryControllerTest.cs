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
  public  class InventoryControllerTest
    {
        [TestMethod]
        public async Task Index()
        {
            // Arrange
            InventoryController controller = new InventoryController();

            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
           // return IViewPageActivator()
        }

    }
}
