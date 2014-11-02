using System.Collections.Generic;
using Oblig1.Model;

namespace Oblig1.DAL
{
    public interface IUserDAL
    {
        bool setIn(Users inUser);
        bool editUser(string email, User innUser);
        bool deleteUser(int id);
        Users getUser(int id);
        bool userInDb(Users user);
        List<Item> getItems();
    }
}