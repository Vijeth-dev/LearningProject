using System;
using BookMyRoomAPILayer.Controllers;
using BookMyRoomAPILayer.Models;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomCommonLayer.Entities;
using BookMyRoomCommonLayer.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static System.Net.WebRequestMethods;

namespace BookMyRoomTestLayer.Test_Controller
{
    [TestClass]
    public class RegisterControllerTest
    {

        /// <summary>
        /// Test For Register User if manage sends false
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            UserModel user = new UserModel()
            {
                Email = "shashank@gmail.com",
                FirstName = "shashank",
                LastName = "dhanya",
                Password = "123123123",
                PhoneNo = "1234567890",
                Token = "1234567890qwertuiop"
            };
            Mock<IBusiness> mockmanager = new Mock<IBusiness>();
            RegisterController rc = new RegisterController(mockmanager.Object);
            var actionResult = rc.RegisterNormalUsers(user);
            Assert.AreEqual(409, (actionResult.Result as ConflictResult).StatusCode);
        }

        /// <summary>
        /// Test for the Exception thrown by manager class
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            dynamic excpetion=null;
            UserModel user = new UserModel()
            {
                Email = "shashank@gmail.com",
                FirstName = "shashank",
                LastName = "dhanya",
                Password = "123123123",
                PhoneNo = "1234567890",
                Token = "1234567890qwertuiop"
            };
            Mock<IBusiness> mockmanager = new Mock<IBusiness>();
            mockmanager.Setup(options => options.AddUserProfile(It.IsAny<UserProfiles>())).Throws(new Exception());
            RegisterController rc = new RegisterController(mockmanager.Object);
            //Mock<RegisterController> mock = new Mock<RegisterController>(mockmanager.Object);
            //mock.Setup(options => options.RegisterNormalUsers(It.IsAny<UserModel>())).Throws<Exception>();
            //mockmanager.Object.AddUserProfile(It.IsAny<UserProfiles>());
            //try
            //{
            //    mockmanager.Object.AddUserProfile(It.IsAny<UserProfiles>());
            //}
            //catch(Exception e)
            //{
            //    excpetion = e;
            //}
            //Assert.IsNotNull(excpetion);
            var actionResult = rc.RegisterNormalUsers(user);
            Assert.AreEqual(400, (actionResult.Result as BadRequestObjectResult).StatusCode);

        }

        /// <summary>
        /// test for the SQLException thrown by the manager class
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            UserModel user = new UserModel()
            {
                Email = "shashank@gmail.com",
                FirstName = "shashank",
                LastName = "dhanya",
                Password = "123123123",
                PhoneNo = "1234567890",
                Token = "1234567890qwertuiop"
            };
            Mock<IBusiness> mockmanager = new Mock<IBusiness>();
            mockmanager.Setup(options => options.AddUserProfile(It.IsAny<UserProfiles>())).Throws(new SQLException(""));
            RegisterController rc = new RegisterController(mockmanager.Object);
            var actionResult = rc.RegisterNormalUsers(user);
            Assert.AreEqual(400, (actionResult.Result as BadRequestObjectResult).StatusCode);
        }
        /// <summary>
        /// Test case for the manager returns true for some value
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            UserModel user = new UserModel()
            {
                Email = "shashank@gmail.com",
                FirstName = "shashank",
                LastName = "dhanya",
                Password = "123123123",
                PhoneNo = "1234567890",
                Token = "1234567890qwertuiop"
            };
            Mock<IBusiness> mockmanager = new Mock<IBusiness>();
            RegisterController rc = new RegisterController(mockmanager.Object);
            mockmanager.Setup(options => options.AddUserProfile(It.IsAny<UserProfiles>())).Returns(true);
            var actionResult = rc.RegisterNormalUsers(user);
            Assert.AreEqual(200, (actionResult.Result as OkResult).StatusCode);
        }
    }
}
