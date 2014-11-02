using System.Collections.Generic;
using Oblig1.DAL;
using Oblig1.Model;

namespace Oblig1.BLL
{
    public interface IUserBLL
    {
        bool editUser(string email, User inUser);
        bool setIn(Users inUser);
        bool deleteUser(int id);
        bool userInDb(Users inUser);
        Users getUser(int id);
        List<Item> getItems();
    }
}