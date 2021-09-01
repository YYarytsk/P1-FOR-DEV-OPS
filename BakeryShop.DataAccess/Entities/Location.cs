using System;
using System.Collections.Generic;

#nullable disable

namespace BakeryShop.DataAccess.Entities
{
    public partial class Location
    {
        public Location()
        {
            Inventories = new HashSet<Inventory>();
            PurchOrders = new HashSet<PurchOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<PurchOrder> PurchOrders { get; set; }
    }
}
