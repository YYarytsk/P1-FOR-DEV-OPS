using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryShop.DataAccess.Entities;

namespace BakeryShop.DataAccess.Interfaces
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        ShoppingCart GetShoppingCart(int ShoppingCartId);
        //ShoppingCartModel GetCartDetails(int ShoppingCartId);
        int DeleteCartItem(int shoppingCartId, int itemId);
        int UpdateQuantity(int shoppingCartId, int itemId, int Quantity);
        int UpdateShoppingCart(int shoppingCartId, int userId);
    }
}