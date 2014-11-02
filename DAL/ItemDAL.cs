using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Oblig1.Model;
using Oblig1.DAL;

namespace Oblig1.DAL
{
    public class ItemDAL
    {
        public bool registerItem(Items item)
        {
            PastaContext storeDB = new PastaContext();
            try
            {
                storeDB.Items.Add(item);
                storeDB.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }

        public List<Items> getAllItems()
        {
            var db = new PastaContext();
            List<Items> allItems = db.Items.Select(k => new Items()
            {
                Currentstock = k.Currentstock,
                Itemid = k.Itemid,
                Itemprice = k.Itemprice,
                Itemname = k.Itemname,
                Itemtype = k.Itemtype,
                PictureURL = k.PictureURL
            }).ToList();
            return allItems;
        }


        public Items getItem(int itemid)
        {
            var db = new PastaContext();

            var aDbItem = db.Items.Find(itemid);

            if (aDbItem != null)
            {
                var outItem = new Items()
                {
                    Currentstock = aDbItem.Currentstock,
                    Itemid = aDbItem.Itemid,
                    Itemname = aDbItem.Itemname,
                    Itemprice = aDbItem.Itemprice,
                    Itemtype = aDbItem.Itemtype,
                    PictureURL = aDbItem.PictureURL
                };
                return outItem;
            }
            else
            {
                return null;
            }
        }

        public bool deleteItem(int itemid)
        {
            var db = new PastaContext();
            try
            {
                Items removeItems = db.Items.Find(itemid);
                db.Items.Remove(removeItems);
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }
    }
}
