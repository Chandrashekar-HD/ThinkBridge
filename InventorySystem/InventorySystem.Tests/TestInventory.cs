using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tests
{
   public class TestInventory : IInventoryDBContext
    {
        public TestInventory()
        {
            this.InventoryList = new TestInventoryDbSet();
        }

       public DbSet<Inventory> InventoryList { get;}

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Inventory item) { }
        public void Dispose() { }
    }
}
