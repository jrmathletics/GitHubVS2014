using System;
using Oblig1.DAL;
using Oblig1.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1.BLL
{
    public class ItemBLL
    {
        public ItemDAL itemDAL;
        public bool registerItem(Items item)
        {
            itemDAL = new ItemDAL();
            return itemDAL.registerItem(item);
        }

        public bool deleteItem(int itemid)
        {
            var itemDal = new ItemDAL();
            return itemDal.deleteItem(itemid);
        }

        public Items getItem(int itemid)
        {
            var itemDal = new ItemDAL();
            return itemDal.getItem(itemid);
        }

        public List<Items> getAllItems()
        {
            var itemDal = new ItemDAL();
            return itemDal.getAllItems();
        }

    }
}
