using System;
using System.Collections.Generic;

#nullable disable

namespace BakeryShop.DataAccess.Entities
{
    public partial class PurchOrder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
