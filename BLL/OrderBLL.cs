using System.Diagnostics;
using Oblig1.Model;
using Oblig1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1.BLL
{
    public class OrderBLL
    {
        public bool editUser(string email, User inUser)
        {
            var userDal = new UserDAL();
            return userDal.editUser(email, inUser);
        }

        public bool setIn(Orders inOrder)
        {
            Debug.WriteLine("Inne i Orders BLL");
            var orderDal = new OrderDAL();
            return orderDal.setIn(inOrder);
        }

        public bool deleteOrder(int id)
        {
            var orderDal = new OrderDAL();
            return orderDal.deleteOrder(id);
        }

        public bool userInDb(Users inUser)
        {
            Debug.WriteLine("Inne i UserBLL.userInDb");
            var userDal = new UserDAL();
            return userDal.userInDb(inUser);
        }

        public Orders getOrder(int id)
        {
            var orderDal = new OrderDAL();
            return orderDal.getOrder(id);
        }
        
        public List<Item> getItems()
        {
            var userDal = new UserDAL();
            return userDal.getItems();
        }

    }
}
