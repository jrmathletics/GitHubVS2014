using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Oblig1.BLL;
using Oblig1.Model;
using Oblig1.DAL;


namespace Oblig1.Controllers
{
    public class UserController : Controller
    {
        private IUserBLL _userBLL;
        public UserController()
        {
            _userBLL = new UserBLL();
        }

        public UserController(IUserBLL stub)
        {
            _userBLL = stub;
        }

        public ActionResult Index()
        {
            var model = new UserBLL();
            //var filler = new DBFiller();
           // filler.Filler();
            List<Item> allItems = model.getItems();
            if (Session["LoggedIn"] == null)
            {
                Session["LoggedIn"] = false;
            }
            else if ((bool)Session["LoggedIn"] == false)
            {
                Session["LoggedIn"] = false;
            }
            else
            {
                Session["LoggedIn"] = true;
            }
            
            if (Session["Admin"] == null)
            {
                Session["Admin"] = false;
            }else if ((bool) Session["Admin"] == false)
            {
                Session["Admin"] = false;
            }
            else
            {
                Session["Admin"] = true;
            }

            return PartialView(allItems);
        }

        [HttpPost]
        public ActionResult Index(Users user)
        {

            if (user.Email == "admin@pastasjappa.no" && user.Password == "adminadmin")
            {
                Session["Admin"] = true;
                return View("Admin");
            }

            if (Bruker_i_DB(user))
            {
                Session["LoggedIn"] = true;
                string userEmail = user.Email;
                Session["User"] = userEmail;
                return View();
            }
            else
            {
                Session["LoggedIn"] = false;
                return View();
            }

        }

       public void Filler()
        {
            var filler = new DBFiller();
            filler.Filler();
        }

        public ActionResult Admin()
        {
            if (Session["Admin"] != null)
            {
                bool loggedIn = (bool)Session["Admin"];
                if (loggedIn)
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult AdminItems()
        {
            var db = new PastaContext();
            var items = new ItemBLL();

            if (Session["Admin"] != null)
            {
                bool loggedIn = (bool)Session["Admin"];
                if (loggedIn)
                {
                    return View(db.Items);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult AdminUsers()
        {
            var db = new PastaContext();

            if (Session["Admin"] != null)
            {
                bool loggedIn = (bool)Session["Admin"];
                if (loggedIn)
                {
                    return View(db.Users);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult AdminOrders()
        {
            var db = new PastaContext();

            if (Session["Admin"] != null)
            {
                bool loggedIn = (bool)Session["Admin"];
                if (loggedIn)
                {
                    return View(db.Orders);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult OrderDelete()
        {
            String id = (String)RouteData.Values["id"];
            var orderid = Convert.ToInt32(id);
            var orderDb = new OrderBLL();
            Orders order = orderDb.getOrder(orderid);
            return View(order);
            
        }

        [HttpPost]
        public ActionResult OrderDelete(Orders order)
        {
            String id = (String)RouteData.Values["id"];
            var orderid = Convert.ToInt32(id);
            var orderDb = new OrderBLL();
            bool slettOK = orderDb.deleteOrder(orderid);
            if (slettOK)
            {
                return RedirectToAction("Admin");
            }
            return View();

        }

        public ActionResult ItemCreate()
        {
            if (Session["Admin"] != null)
            {
                bool loggedIn = (bool)Session["Admin"];
                if (loggedIn)
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult ItemEdit()
        {
            return View();
        }

        public ActionResult ItemDelete()
        {
            String id = (String)RouteData.Values["id"];
            var itemid = Convert.ToInt32(id);
            var itemDb = new ItemBLL();
            Items item = itemDb.getItem(itemid);
            return View(item);
        }

        [HttpPost]
        public ActionResult ItemDelete(Items item)
        {
            String id = (String)RouteData.Values["id"];
            var itemid = Convert.ToInt32(id);
            var itemDb = new ItemBLL();
            bool slettOK = itemDb.deleteItem(itemid);
            if (slettOK)
            {
                return RedirectToAction("Admin");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ItemCreate(Items item)
        {

            if (ModelState.IsValid)
            {
                var model = new ItemBLL();
                model.registerItem(item);
                return RedirectToAction("AdminItems");
            }
            return View();
        }

        public ActionResult UserDelete()
        {
            String id = (String)RouteData.Values["id"];
            Debug.WriteLine(id);
            var userid = Convert.ToInt32(id);
            var userDb = new UserBLL();
            Users user = userDb.getUser(userid);
            return View(user);
        }
        [HttpPost]
        public ActionResult UserDelete(Users user)
        {
            String id = (String)RouteData.Values["id"];
            var userid = Convert.ToInt32(id);
            var userDb = new UserBLL();
            bool slettOK = userDb.deleteUser(userid);
            if (slettOK)
            {
                return RedirectToAction("Admin");
            }
            return View();
        }


        public ActionResult LogOut()
        {
            Session["LoggedIn"] = false;
            Session["Admin"] = false;
            return RedirectToAction("Index");
        }
        

        

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
            if(ModelState.IsValid)
            {
                var userDb = new UserBLL();
                bool insertOk = userDb.setIn(user);
                if(insertOk)
                {
                    Debug.WriteLine(userDb.userInDb(user));
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        private static bool Bruker_i_DB(Users user)
        {
            Debug.WriteLine("inne i Bruker_i_DB");
            var userDb = new UserBLL();

            Debug.WriteLine(userDb.userInDb(user));

            return userDb.userInDb(user);
        }

        public ActionResult LoggedInSite()
        {
            if (Session["LoggedIn"] != null)
            {
                bool loggedIn = (bool)Session["LoggedIn"];
                if(loggedIn)
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        /*
        public ActionResult Minside()
        {

            string compareEmail = (string)Session["User"];
            var userDb = new UserBLL();

            Users foundUser = userDb.getUser(compareEmail);

            if (foundUser == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(foundUser);
            }
        }

        public ActionResult _Minside()
        {
            string compareEmail = (string)Session["User"];
            var userDb = new UserBLL();

            Users foundUser = userDb.getUser(compareEmail);
            return View();

        }*/
        /*
        public ActionResult EditUser()
        {
            string compareEmail = (string)Session["User"];

            var userDb = new UserBLL();

            Users foundUser = userDb.getUser(compareEmail);
            return View(foundUser);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditUser(string email, User editUser)
        {
            
            if (ModelState.IsValid)
            {
                var userDb = new UserBLL();
                bool endringOK = userDb.editUser(email, editUser);
                if (endringOK)
                {
                    return RedirectToAction("Minside");
                }
            }
            return View();
        }*/
    }
}
