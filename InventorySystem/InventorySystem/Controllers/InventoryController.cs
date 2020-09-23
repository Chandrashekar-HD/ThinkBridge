using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class InventoryController : Controller
    {
        /// <summary>
        /// GET: Index
        /// </summary>
        /// <returns>ActionResult</returns>
        public async Task<ActionResult> Index()
        {
            //string url = HttpContext.Request.Url.Authority;
            IEnumerable<Inventory> InventoryList = null;
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:59915//api/Inventories");  //making call to WebAPI
            if (response.IsSuccessStatusCode)
            {
                InventoryList = await response.Content.ReadAsAsync<IEnumerable<Inventory>>(); //fetchimg data
            }
            else
            {
                return RedirectToAction("Error", "NotFound");  //Redirect to error page
            }
            return View(InventoryList.ToList());

        }
    }
}
