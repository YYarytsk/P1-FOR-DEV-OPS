using System;
using System.Collections.Generic;

#nullable disable

namespace BakeryShop.DataAccess.Entities
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new List<CartItem>();
            CreatedDate = DateTime.Now;
            IsActive = true;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public virtual List<CartItem> CartItems { get; private set; }

        //public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
