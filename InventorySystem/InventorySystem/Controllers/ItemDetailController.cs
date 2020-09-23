using InventorySystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class ItemDetailController : Controller
    {
        /// <summary>
        /// GET: Detail
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>ActionResult</returns>
        public async Task<ActionResult>Detail(int id)
        {
            //string url = HttpContext.Request.Url.Authority;
            Inventory InventoryList = null;
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:59915/api/Inventories/"+id);   //making call to WebAPI
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;   //fetchimg data
                InventoryList = JsonConvert.DeserializeObject<Inventory>(data);

            }
            else
            {
                 return RedirectToAction("Error", "NotFound");  //Redirect to error page

            }

            return View(InventoryList);

        }
    }
}