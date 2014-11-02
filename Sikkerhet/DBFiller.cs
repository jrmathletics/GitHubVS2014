using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1.BLL;
using Oblig1.Model;
using Oblig1.DAL;

namespace Oblig1
{
    public class DBFiller
    {
        public void Filler()
        {
            var userDb = new UserBLL();
            var itemDb = new ItemBLL();
            var orderDb = new OrderBLL();

            var city1 = new Cities();
            var city2 = new Cities();
            var city3 = new Cities();

            city1.Cityname = "Oslo";
            city1.Postcode = "9382";

            city2.Cityname = "Trondheim";
            city2.Postcode = "2301";

            city3.Cityname = "Bergen";
            city3.Postcode = "1723";

            var user1 = new Users()
            {
                Address = "Moroveien 7",
                Firstname = "Martin",
                Surname = "Hermansen",
                Email = "mh@mh.no",
                Password = "mhmhmh",
                Phonenr = "93929392",
                Postcode = "9382",
                cities = city1
            };

            var user2 = new Users()
            {
                Address = "Bakvendtgata 8",
                Firstname = "Hanne",
                Surname = "Lande",
                Email = "hl@hl.no",
                Password = "hlhlhl",
                Phonenr = "82711212",
                Postcode = "2301",
                cities = city2
            };

            var user3 = new Users()
            {
                Address = "Fisefin Aveny 14",
                Firstname = "Voldemort",
                Surname = "Olsen",
                Email = "vo@vo.no",
                Password = "vovovo",
                Phonenr = "12672891",
                Postcode = "1723",
                cities = city3
            };

            var item1 = new Items()
            {
                Currentstock = 40,
                Itemname = "Blanding",
                Itemprice = 99,
                Itemtype = "Pasta",
                PictureURL = "/img/pasta_blanding.png",
                Itemid = 78
            };

            var item2 = new Items()
            {
                Currentstock = 17,
                Itemname = "Fusilli",
                Itemprice = 119,
                Itemtype = "Pasta",
                PictureURL = "/img/pasta_fusilli.png",
                Itemid = 63
            };
            var item3 = new Items()
            {
                Currentstock = 80,
                Itemname = "Farfalle",
                Itemprice = 69,
                Itemtype = "Pasta",
                PictureURL = "/img/pasta_farfalle.png",
                Itemid = 30
            };
            var item4 = new Items()
            {
                Currentstock = 63,
                Itemname = "Colored Fusilli #1",
                Itemprice = 45,
                Itemtype = "Pasta",
                PictureURL = "/img/pasta_fusilli_farget.png",
                Itemid = 22
            };
            var item5 = new Items()
            {
                Currentstock = 3,
                Itemname = "Colored Fusilli #2",
                Itemprice = 33,
                Itemtype = "Pasta",
                PictureURL = "/img/pasta_fusilli_farget2.png",
                Itemid = 98
            };
            var item6 = new Items()
            {
                Currentstock = 77,
                Itemname = "Macaroni",
                Itemprice = 25,
                Itemtype = "Pasta",
                PictureURL = "/img/pasta_macaroni.png",
                Itemid = 76
            };
            var item7 = new Items()
            {
                Currentstock = 80,
                Itemname = "Measure",
                Itemprice = 299,
                Itemtype = "Tools",
                PictureURL = "/img/pasta_messure.png",
                Itemid = 59
            };
            var item8 = new Items()
            {
                Currentstock = 14,
                Itemname = "Multitool",
                Itemprice = 499,
                Itemtype = "Tool",
                PictureURL = "/img/pasta_multitool.png",
                Itemid = 69
            };
            var item9 = new Items()
            {
                Currentstock = 88,
                Itemname = "Penne",
                Itemprice = 19,
                Itemtype = "Pasta",
                PictureURL = "/img/pasta_penne.png",
                Itemid = 79
            };
            var item10 = new Items()
            {
                Currentstock = 45,
                Itemname = "Roller",
                Itemprice = 59,
                Itemtype = "Tool",
                PictureURL = "/img/pasta_ruller.png",
                Itemid = 79
            };
            var item11 = new Items()
            {
                Currentstock = 179,
                Itemname = "Spoon",
                Itemprice = 39,
                Itemtype = "Tool",
                PictureURL = "/img/pasta_sleiv.png",
                Itemid = 110
            };
            var item12 = new Items()
            {
                Currentstock = 17,
                Itemname = "Spagetti",
                Itemprice = 9,
                Itemtype = "Pasta",
                PictureURL = "/img/pasta_penne.png",
                Itemid = 79
            };


            var orderline1 = new OrderLines()
            {
                Itemamount = 3,
                Items = item12,
                Orderlineid = 1
            };
            var orderline2 = new OrderLines()
            {
                Itemamount = 3,
                Items = item6,
                Orderlineid = 2
            };
            var orderline3 = new OrderLines()
            {
                Itemamount = 3,
                Items = item9,
                Orderlineid = 3
            };
            var orderline4 = new OrderLines()
            {
                Itemamount = 3,
                Items = item7,
                Orderlineid = 4
            };
            var orderline5 = new OrderLines()
            {
                Itemamount = 3,
                Items = item3,
                Orderlineid = 5
            };
            
            List<OrderLines> orderlist1 = new List<OrderLines>();
            orderlist1.Add(orderline1);
            orderlist1.Add(orderline3);
            orderlist1.Add(orderline2);
            orderlist1.Add(orderline4);

            List<OrderLines> orderlist3 = new List<OrderLines>();
            orderlist3.Add(orderline5);
            orderlist3.Add(orderline3);
            orderlist3.Add(orderline2);
            orderlist3.Add(orderline4);

            List<OrderLines> orderlist2 = new List<OrderLines>();
            orderlist2.Add(orderline1);
            orderlist2.Add(orderline5);
            orderlist2.Add(orderline2);
            orderlist2.Add(orderline4);

            var order1 = new Orders()
            {
                Orderid = 1,
                Orderlines = orderlist1,
                Orderprice = 299,
                //users = user1
            };

            var order2 = new Orders()
            {
                Orderid = 2,
                Orderlines = orderlist2,
                Orderprice = 799,
              //  users = user2
            };
            var order3 = new Orders()
            {
                Orderid = 3,
                Orderlines = orderlist3,
                Orderprice = 599,
               // users = user3
            };



            itemDb.registerItem(item1);
            itemDb.registerItem(item2);
            itemDb.registerItem(item3);
            itemDb.registerItem(item4);
            itemDb.registerItem(item5);
            itemDb.registerItem(item6);
            itemDb.registerItem(item7);
            itemDb.registerItem(item8);
            itemDb.registerItem(item9);
            itemDb.registerItem(item10);
            itemDb.registerItem(item11);
            itemDb.registerItem(item12);
            userDb.setIn(user1);
            userDb.setIn(user2);
            userDb.setIn(user3);

            orderDb.setIn(order1);
            orderDb.setIn(order2);
            orderDb.setIn(order3);

        }

    }
}