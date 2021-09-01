using System;
using System.Collections.Generic;

#nullable disable

namespace BakeryShop.DataAccess.Entities
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int ShopCartId { get; set; }
        

        public virtual ShoppingCart ShopCart { get; set; }
    }
}
