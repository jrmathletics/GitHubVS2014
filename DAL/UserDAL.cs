using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Oblig1.Model;

namespace Oblig1.DAL
{
    public class UserDAL : IUserDAL
    {

        PastaContext db = new PastaContext();
        public bool setIn(Users inUser)
        {
            inUser.Postcode = inUser.cities.Postcode;
            PastaContext db = new PastaContext();

            var newUser = new Users()
            {
                Firstname = inUser.Firstname,
                Surname = inUser.Surname,
                Address = inUser.Address,
                Postcode = inUser.Postcode,
                Phonenr = inUser.Phonenr,
                Email = inUser.Email,
                Password = inUser.Password
            };

            byte[] passwordDb = createHash(inUser.Password);
            newUser.Password = "11111111111";

            var newDbUser = new dbUsers()
            {
                Password = passwordDb,
                Email = inUser.Email
            };

            try
            {
                var exPostcode = db.Cities.Find(inUser.Postcode);

                if (exPostcode == null)
                {
                    var newCity = new Cities()
                    {
                        Postcode = inUser.Postcode,
                        Cityname = inUser.cities.Cityname
                    };
                    newUser.cities = newCity;
                }
                db.Users.Add(inUser);
                db.dbUsers.Add(newDbUser);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        public bool editUser(string email, User innUser)
        {
            var db = new PastaContext();
            try
            {
                Users editUser = db.Users.Find(email);
                editUser.Firstname = innUser.firstname;
                editUser.Surname = innUser.surname;
                editUser.Address = innUser.address;
                editUser.Phonenr = innUser.phonenr;
                var newUser = new dbUsers();
                byte[] passwordDb = createHash(innUser.password);
                newUser.Password = passwordDb;
                innUser.password = "11111111111";
                newUser.Email = email;


                if (editUser.Postcode != innUser.postcode)
                {
                    Cities existingCity = db.Cities.Find(innUser.postcode);
                    if (existingCity == null)
                    {
                        var newCity = new Cities()
                        {
                            Postcode = innUser.postcode,
                            Cityname = innUser.city
                        };
                        db.Cities.Add(newCity);
                    }
                    else
                    {
                        editUser.Postcode = innUser.postcode;
                    }
                };
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static byte[] createHash(string inPassword)
        {
            byte[] inData, outData;
            var algorithm = System.Security.Cryptography.SHA256.Create();
            inData = System.Text.Encoding.ASCII.GetBytes(inPassword);
            outData = algorithm.ComputeHash(inData);
            return outData;
        }

        public bool deleteUser(int id)
        {
            Debug.WriteLine("inne i userDal deleteuser");
            Debug.WriteLine(id);
            var db = new PastaContext();
            try
            {
                Users removeUser = db.Users.Find(id);
                db.Users.Remove(removeUser);
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }

        public Users getUser(int id)
        {
            var db = new PastaContext();

            var aDbUser = db.Users.Find(id);
            
            if(aDbUser == null)
            {
                return null;
            }
            else
            {
                var city1 = new Cities();
                city1.Cityname = aDbUser.cities.Cityname;
                city1.Postcode = aDbUser.cities.Postcode;

                var outUser = new Users()
                {
                    Firstname = aDbUser.Firstname,
                    Surname = aDbUser.Surname,
                    Address = aDbUser.Address,
                    Postcode = aDbUser.Postcode,
                    cities = city1,
                    Email = aDbUser.Email,
                    Phonenr = aDbUser.Phonenr
                };
                return outUser;
            }
        }

        public bool userInDb(Users user)
        {
            Debug.WriteLine("Inne i UserDAL.userInDb");
            byte[] passordDb = createHash(user.Password);

            dbUsers foundUser = db.dbUsers.FirstOrDefault
                    (b => b.Password == passordDb && b.Email == user.Email);
            Debug.WriteLine("vvvvvvvvvv");
            Debug.WriteLine(foundUser);
            Debug.WriteLine("^^^^^^^^^^");

            if(foundUser == null)
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
