using InventorySystem.Controllers;
using InventorySystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http.Results;

namespace InventorySystem.Tests.Controllers
{
    [TestClass]
    public  class InventoriesControllerTest
    {
        [TestMethod]
        public void PostInventory_ShouldReturnSameInventory()
        {
            var controller = new InventoriesController(new TestInventory());

            var item = GetInventoryItem();

            var result =
                controller.PostInventory(item) as CreatedAtRouteNegotiatedContentResult<Inventory>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.ID);
            Assert.AreEqual(result.Content.Name, item.Name);
        }

        [TestMethod]
        public void PutInventory_ShouldReturnStatusCode()
        {
            var controller = new InventoriesController(new TestInventory());

            var item = GetInventoryItem();

            var result = controller.PutInventory(item.ID, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutInventory_ShouldFail_WhenDifferentID()
        {
            var controller = new InventoriesController(new TestInventory());

            var badresult = controller.PutInventory(999, GetInventoryItem());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetInventory_ShouldReturnInventoryWithSameID()
        {
            var context = new TestInventory();
            context.InventoryList.Add(GetInventoryItem());

            var controller = new InventoriesController(context);
            var result = controller.GetInventory(3) as OkNegotiatedContentResult<Inventory>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.ID);
        }

        [TestMethod]
        public void GetInventoryList_ShouldReturnAllItems()
        {
            var context = new TestInventory();
            context.InventoryList.Add(new Inventory { ID = 1, Name = "Demo1", Description="desc1" ,Price = 20 });
            context.InventoryList.Add(new Inventory { ID = 2, Name = "Demo2", Description = "desc2", Price = 30 });
            context.InventoryList.Add(new Inventory { ID = 3, Name = "Demo3", Description = "desc3", Price = 40 });

            var controller = new InventoriesController(context);
            var result = controller.GetInventoryList() as TestInventoryDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteInventory_ShouldReturnOK()
        {
            var context = new TestInventory();
            var item = GetInventoryItem();
            context.InventoryList.Add(item);

            var controller = new InventoriesController(context);
            var result = controller.DeleteInventory(3) as OkNegotiatedContentResult<Inventory>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.ID, result.Content.ID);
        }

        Inventory GetInventoryItem()
        {
            return new Inventory() { ID = 3, Name = "Demo name", Description="test", Price = 5 };
        }
    }

}
