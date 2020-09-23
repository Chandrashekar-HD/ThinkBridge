using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
  public  interface IInventoryDBContext
    {
        DbSet<Inventory> InventoryList { get; }
        int SaveChanges();
        void MarkAsModified(Inventory item);
        void Dispose();
    }
}
