using System;
using System.Collections.Generic;

#nullable disable

namespace BakeryShop.DataAccess.Entities
{
    public partial class Item
    {
        public Item()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public int ItemCategoryId { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
