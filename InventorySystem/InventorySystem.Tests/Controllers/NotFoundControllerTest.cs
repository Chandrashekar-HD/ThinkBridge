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
   public class NotFoundControllerTest
    {
        [TestMethod]
        public void DetailFound()
        {
            // Arrange
            NotFoundController controller = new NotFoundController();

            // Act
            var result =  controller.Error() as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
            // return IViewPageActivator()
        }
    }
}
