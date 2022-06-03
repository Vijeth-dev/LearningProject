using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.Moq;
using BookMyRoomAPILayer.Controllers;
using BookMyRoomAPILayer.Models;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomCommonLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace BookMyRoomTestLayer.Test_Controller
{
    [TestClass]
    public class SearchControllerTest
    {
        [TestMethod]
        public void GetTheHotelList()
        {
            string search="Delhi";
            //Mock<IBusiness> mockManager = new Mock<IBusiness>();
            //SearchController searchController = new SearchController(mockManager.Object);
            //using (var mock = AutoMock.GetLoose())
            //{
            //    //mock.Mock<SearchController>()
            //    //    .Setup(x => x.UpdateProfile("123", userProfiles))
            //    //    .Returns(true);
            //    var upadateProfile = mock.Create<IBusiness>();
            //    var actual = upadateProfile.UpdateProfile("123", userProfiles);
            //    Assert.IsTrue(actual);




            //}

            //SearchModel searchModel = new SearchModel()
            //{
            //    Adult = 1,
            //    Children = 1,
            //    City = "Delhi",
            //    From = DateTime.Now,
            //    To = DateTime.Now,
            //    Infants = 1,
            //    State = "Delhi"
            //};
           




            Mock<IBusiness> mockManager = new Mock<IBusiness>();
            //SearchController searchController = new SearchController(mockManager.Object);
            //IActionResult actionResult = actionResult.Get(search);
           
           // Mock<SearchController> mock = new Mock<SearchController>();
            SearchController searchController = new SearchController(mockManager.Object);
            //IActionResult actionResult = actionResult.Get(search);
            // var controller = SearchController.searchlist(search);
            var res = searchController.Get(search);
         

        }
        public List<SearchResult> getHotelDetails()
        {
            List<SearchResult> searchResults = new List<SearchResult>();
            return searchResults;
        }
    }
}
