using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Oblig1.Model;

namespace Oblig1.DAL
{
    public class OrderDAL
    {

        PastaContext db = new PastaContext();
        public List<Orders> getAll()
        {
            var db = new PastaContext();
            List<Orders> allOrders = new List<Orders>(db.Orders.Select(k => new Orders()
            {
                Orderid = k.Orderid,
                Orderlines = k.Orderlines,
                Orderprice = k.Orderprice/*,
                users = k.users*/
            }));
            
            return allOrders;
        }

        public bool setIn(Orders inOrders)
        {
            Debug.WriteLine("Inne i ordersDAL");
            PastaContext db = new PastaContext();

            var newOrder = new Orders()
            {
                Orderid = inOrders.Orderid,
                Orderlines = inOrders.Orderlines,
                Orderprice = inOrders.Orderprice,
                //users = inOrders.users
            };
/*
            var exPostcode = db.Cities.Find(inOrders.users.cities.Postcode);

            if (exPostcode == null)
            {
                var newCity = new Cities()
                {
                    Postcode = inOrders.users.cities.Postcode,
                    Cityname = inOrders.users.cities.Cityname
                };
                newOrder.users.cities = newCity;
            }*/
            
                db.Orders.Add(inOrders);
                db.SaveChanges();
                return true;
            
        }
        public bool deleteOrder(int id)
        {
            Debug.WriteLine("Inne i deleteorderDal");
            Debug.WriteLine(id);
            var db = new PastaContext();
            try
            {
                Orders removeOrder = db.Orders.Find(id);
                Debug.WriteLine(removeOrder.Orderprice);
                db.Orders.Remove(removeOrder);
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }

        public Orders getOrder(int id)
        {
            var db = new PastaContext();

            var aDbOrder = db.Orders.Find(id);

            if (aDbOrder == null)
            {
                return null;
            }
            else
            {

                var outOrder = new Orders()
                {
                    Orderid = aDbOrder.Orderid,
                    Orderlines = aDbOrder.Orderlines,
                    Orderprice = aDbOrder.Orderprice
                };
                return outOrder;
            }
        }

        public List<Item> getItems()
        {
            var db = new PastaContext();
            List<Item> allItems = db.Items.Select(k => new Item()
            {
                itemname = k.Itemname,
                itemprice = k.Itemprice,
                currentstock = k.Currentstock,
                pictureURL = k.PictureURL
            }).ToList();
            return allItems;
        }

    }
}
