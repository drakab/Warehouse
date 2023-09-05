using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Common;

namespace Warehouse.Domain.Entity
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int Quantity { get; set; }
        protected bool isLowInWarehouse;

        public Item(int id, string name, int typeId)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
        }

        public Item()
        {
        }
    }
}
