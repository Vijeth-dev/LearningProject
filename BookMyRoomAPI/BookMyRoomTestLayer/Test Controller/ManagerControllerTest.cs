using System;
using System.Collections.Generic;
using System.Text;
using BookMyRoomAPILayer.Controllers;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomCommonLayer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookMyRoomTestLayer.Test_Controller
{
    [TestClass]
    public class ManagerControllerTest
    {
        [TestMethod]
        public void AddManager()
        {
            HotelManager manager = new HotelManager
            {
                HotelManager_ID = 7,
                HotelManager_Name = "Narayan",
                HotelManager_PhoneNumber = "8987656789",
                _EmailID = "narayan@gmail.com",
                _Designation = "manager",
                _Password = "narayan123",
                _Status = "active"

            };
            Mock<IBusiness> mockObject = new Mock<IBusiness>();
            ManagerController managerController = new ManagerController(mockObject.Object);
            var result = managerController.AddHotelManager(manager);
            Assert.AreEqual("RanToCompletion", result.Status.ToString());
        }
        public void AddManager_Invalid()
        {
            HotelManager manager = new HotelManager
            {
                HotelManager_ID = 7,
                HotelManager_Name = "Narayan",
                HotelManager_PhoneNumber = "8987656789",
                _EmailID = "narayan@gmail.com",
                _Designation = "manager",
                _Password = "narayan123",
                _Status = "active"

            };
            Mock<IBusiness> mockObject = new Mock<IBusiness>();
            ManagerController managerController = new ManagerController(mockObject.Object);
            var result = managerController.AddHotelManager(manager);
            Assert.AreEqual("RanToCompletion", result.Status.ToString());
        }
    }
}
