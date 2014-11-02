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
    public class UserBLL : IUserBLL
    {

        private IUserDAL _dal;

        public UserBLL()
        {
            _dal = new UserDAL();
        }

        public UserBLL(IUserDAL stub)
        {
            _dal = stub;
        }

        public bool editUser(string email, User inUser)
        {
            return _dal.editUser(email, inUser);
        }

        public bool setIn(Users inUser)
        {
            return _dal.setIn(inUser);
        }

        public bool deleteUser(int id)
        {
            return _dal.deleteUser(id);
        }

        public bool userInDb(Users inUser)
        {
            return _dal.userInDb(inUser);
        }

        public Users getUser(int id)
        {
            return _dal.getUser(id);
        }

        public List<Item> getItems()
        {
            return _dal.getItems();
        }

    }
}
