using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tests
{
    class TestInventoryDbSet : TestDbSet<Inventory>
    {
        public override Inventory Find(params object[] keyValues)
        {
            return this.SingleOrDefault(inventory => inventory.ID == (int)keyValues.Single());
        }
    }
}
