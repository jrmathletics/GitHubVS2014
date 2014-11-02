/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;

namespace Oblig1.DAL
{
    public class ShoppingCart
    {
        
        PastaContext storeDB = new PastaContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";


        public ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddItem(int id, HttpContextBase context)
        {
            var addedItem = storeDB.Items.Single(
                item => item.Itemid == id);

            var cart = ShoppingCart.GetCart(context);

            cart.AddToCart(addedItem);
        }

        public void AddToCart(Items item)
        {
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.Remember == ShoppingCartId
                && c.Itemid == item.Itemid);

            if(cartItem == null)
            {
                cartItem = new Carts
                {
                    Itemid = item.Itemid,
                    Remember = ShoppingCartId,
                    Count = 1
                };
                storeDB.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            storeDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = storeDB.Carts.Single(
                cart => cart.Remember == ShoppingCartId
                && cart.Cartid == id);

            int itemCount = 0;

            if(cartItem != null)
            {
                if(cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(
                cart => cart.Remember == ShoppingCartId);

            foreach(var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            storeDB.SaveChanges();
        }

        public List<Carts> GetCartItems()
        {
            return storeDB.Carts.Where(
                cart => cart.Remember == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in storeDB.Carts
                         where cartItems.Remember == ShoppingCartId
                         select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public int GetTotal()
        {
            int? total = (from cartItems in storeDB.Carts
                          where cartItems.Remember == ShoppingCartId
                          select (int?)cartItems.Count *
                          cartItems.Items.Itemprice).Sum();

            return total ?? 0;
        }

        public int CreateOrder(Orders order)
        {
            int orderTotal = 0;

            var cartItems = GetCartItems();

            foreach(var i in cartItems)
            {
                var orderLine = new OrderLines
                {
                    Itemid = i.Itemid,
                    Orderid = order.Orderid,
                    Itemprice = i.Items.Itemprice,
                    Itemamount = i.Count
                };

                orderTotal += (i.Count * i.Items.Itemprice);

                storeDB.OrderLines.Add(orderLine);
            }

            order.Orderprice = orderTotal;

            storeDB.SaveChanges();

            EmptyCart();

            return order.Orderid;
        }

        public string GetCartId(HttpContextBase context)
        {
            if(context.Session[CartSessionKey] == null)
            {
                if(!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string email)
        {
            var shoppingCart = storeDB.Carts.Where(
                c => c.Remember == ShoppingCartId);

            Debug.WriteLine(ShoppingCartId);

            foreach(Carts i in shoppingCart)
            {
                i.Remember = email;
            }
            storeDB.SaveChanges();
        }
    }
}*/