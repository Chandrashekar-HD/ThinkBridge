using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class Inventory
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^-?(([1-9]\d*)|0)(.0*[1-9](0*[1-9])*)?$")]
        public decimal Price { get; set; }
    }
    public class InventoryDBContext : DbContext, IInventoryDBContext
    {
        public InventoryDBContext() : base("name=InventoryDBContext")
        {
        }
        public DbSet<Inventory> InventoryList { get; set; }
        public void MarkAsModified(Inventory item)
        {
            Entry(item).State = EntityState.Modified;
        }
        public void Dispose() { }
    }
}