using BakeryShop.DataAccess.Entities;
using BakeryShop.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryShop.DataAccess.Implementation
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private p1dbContext appContext
        {
            get { return _dbContext as p1dbContext; }
        }

        public ShoppingCartRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public ShoppingCart GetShoppingCart(int ShoppingCartId)
        {
            return appContext.ShoppingCarts.Include("CartItems")
                .Where(s => s.Id == ShoppingCartId && s.IsActive == true)
                .FirstOrDefault();
        }

        public int DeleteCartItem(int shoppingCartId, int cartItemId)
        {
            var item = appContext.CartItems.Where(ci => ci.ShopCartId == shoppingCartId && ci.Id == cartItemId)
                .FirstOrDefault();
            if (item != null)
            {
                appContext.CartItems.Remove(item);
                return appContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateQuantity(int shoppingCartId, int cartItemId, int Quantity)
        {
            bool flag = false;
            var cart = GetShoppingCart(shoppingCartId);
            if (cart != null)
            {
                for (int i = 0; i < cart.CartItems.Count; i++)
                {
                    if (cart.CartItems[i].Id == cartItemId)
                    {
                        flag = true;
                        //for minus quantity
                        if (Quantity < 0 && cart.CartItems[i].Quantity > 1)
                            cart.CartItems[i].Quantity += (Quantity);
                        else if (Quantity > 0)
                            cart.CartItems[i].Quantity += (Quantity);
                        break;
                    }
                }

                if (flag)
                    return appContext.SaveChanges();
            }

            return 0;
        }

        public int UpdateShoppingCart(int shoppingCartId, int userId)
        {
            ShoppingCart shoppingCart = GetShoppingCart(shoppingCartId);
            shoppingCart.UserId = userId;
            return appContext.SaveChanges();
        }

        //public CartModel GetCartDetails(int CartId)
        //{
        //    var model = (from cart in appContext.Carts
        //                 where cart.Id == CartId && cart.IsActive == true
        //                 select new CartModel
        //                 {
        //                     Id = cart.Id,
        //                     UserId = cart.UserId,
        //                     CreatedDate = cart.CreatedDate,
        //                     Items = (from cartItem in appContext.CartItems
        //                              join item in appContext.Items
        //                                  on cartItem.ItemId equals item.Id
        //                              where cartItem.CartId == CartId
        //                              select new ItemModel
        //                              {
        //                                  Id = cartItem.Id,
        //                                  Name = item.Name,
        //                                  Description = item.Description,
        //                                  ImageUrl = item.ImageUrl,
        //                                  Quantity = cartItem.Quantity,
        //                                  ItemId = item.Id,
        //                                  UnitPrice = cartItem.UnitPrice
        //                              }).ToList()
        //                 }).FirstOrDefault();
        //    return model;
        //}
    }
}


