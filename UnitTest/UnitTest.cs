using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oblig1.BLL;
using Oblig1.Controllers;
using Oblig1.DAL;
//using SessionMockUnitTest;
using MvcContrib.TestHelper;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void List()
        {
            /*
            var controller = new UserController(new UserBLL(new UserDALStub()));

            var result = new List<Users>();
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

            result.Add(user);
            result.Add(user);

            var actionResult = (ViewResult)controller.List();
            var res = (List<Users>)actionResult.Model;

            Assert.AreEqual(actionResult.ViewName, "");


            */
        }

        [TestMethod]
        public void Register()
        {
            var controller = new UserController(new UserBLL(new UserDALStub()));

            var actionResult = (ViewResult)controller.Register();

            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void ItemEdit()
        {
            var controller = new UserController(new UserBLL(new UserDALStub()));

            var actionResult = (ViewResult)controller.ItemEdit();

            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void Admin_True()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController();
            SessionMock.InitializeController(controller);

            controller.Session["Admin"] = true;

            var result = (ViewResult)controller.Admin();

            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void Admin_False()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController();
            SessionMock.InitializeController(controller);

            controller.Session["Admin"] = false;

            var result = (ViewResult)controller.Admin();

            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void ItemCreate_True()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController();
            SessionMock.InitializeController(controller);

            controller.Session["Admin"] = true;

            var result = (ViewResult)controller.ItemCreate();

            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void ItemCreate_False()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController();
            SessionMock.InitializeController(controller);

            controller.Session["Admin"] = false;

            var result = (ViewResult)controller.ItemCreate();

            Assert.AreEqual("", result.ViewName);
        }
    }
}
