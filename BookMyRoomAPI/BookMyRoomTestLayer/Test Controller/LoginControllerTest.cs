using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using BookMyRoomAPILayer.Models;
using BookMyRoomAPILayer.Controllers;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomRepositoryLayer.Interfaces;
using BookMyRoomCommonLayer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;

namespace BookMyRoomTestLayer.Test_Controller
{
    [TestClass]
    public class LoginControllerTest
    {
        public IBusiness LoginControllerExceptionSetup()
        {
            Mock<IBusiness> mockBusiness = new Mock<IBusiness>();
            mockBusiness.Setup(mock => mock.AuthenticateUser(It.IsAny<LogInDetails>())).Throws(new Exception("Oops"));
            return mockBusiness.Object;
        }

        [TestMethod]
        public void LoginExceptionTest()
        {
            UserLoginModel user = new UserLoginModel
            {
                Email = "testmail@mail.com",
                Password = "testhashed",
                Designation = "User"
            };
            Exception expected = new Exception("Oops");
            LoginController loginController = new LoginController(LoginControllerExceptionSetup());

            Assert.ThrowsException<Exception>(() => loginController.Post(user));

        }

        public IBusiness LoginControllerSetup()
        {
            UserProfiles userProfile = new UserProfiles
            {
                User_EmailID = "testmail@mail.com",
                User_FirstName = "Peter",
                User_Lastname = "Sun",
                User_PhoneNumber = "1111111111"
            };
            Mock<IBusiness> mockBusiness = new Mock<IBusiness>();
            mockBusiness.Setup(mock => mock.AuthenticateUser(It.IsAny<LogInDetails>())).Returns(userProfile);
            return mockBusiness.Object;
        }

        [TestMethod]
        public void LoginTest()
        {
            UserLoginModel user = new UserLoginModel
            {
                Email = "testmail@mail.com",
                Password = "testhashed",
                Designation = "User"
            };
            UserModel expected = new UserModel
            {
                Email = "testmail@mail.com",
                FirstName = "Peter",
                LastName = "Sun",
                PhoneNo = "1111111111"
            };
            LoginController loginController = new LoginController(LoginControllerSetup());
            var actionResult = loginController.Post(user);
            var content = actionResult as OkObjectResult;
            UserModel actual = content.Value as UserModel;

            Assert.AreEqual(200, content.StatusCode);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.PhoneNo, actual.PhoneNo);  
        }
    }
}
