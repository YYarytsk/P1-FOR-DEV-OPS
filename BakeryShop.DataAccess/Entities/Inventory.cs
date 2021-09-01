using System;
using System.Collections.Generic;

#nullable disable

namespace BakeryShop.DataAccess.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int ItemQuantity { get; set; }
        public int ItemId { get; set; }
        public int LocationId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Location Location { get; set; }
    }
}
