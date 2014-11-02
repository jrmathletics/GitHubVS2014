using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1.DAL;
using Oblig1.Model;

namespace DAL
{
    public class UserDALStub : IUserDAL
    {
        public List<Users> getAll()
        {/*
            var userList = new List<Users>();
            var user = new Users()
            {
                Firstname = "Per",
                Surname = "Olsen",
                Address = "Osloveien 12",
                Postcode = "1234",
                cities.Cityname = "Oslo",
                Email = "per@olsen.no",
                Password = "111111",
                Phonenr = "12345678"
            };
            userList.Add(user);
            userList.Add(user);
            return userList;
          */
            throw new NotImplementedException();
        }

        public bool setIn(Users inUser)
        {
            if (inUser.Firstname == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool editUser(string email, User innUser)
        {
            throw new NotImplementedException();
        }

        public bool editUser(string email, Users innUser)
        {
            if (email == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool deleteUser(int id)
        {
            if (id == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public Users getUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool userInDb(Users user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Item> getItems()
        {
            throw new NotImplementedException();
        }
    }
}
