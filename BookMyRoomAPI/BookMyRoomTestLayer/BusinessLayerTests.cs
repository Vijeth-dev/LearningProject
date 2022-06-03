using Autofac.Extras.Moq;
using BookMyRoomBusinessLayer.Implementation;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomCommonLayer.Entities;
using BookMyRoomCommonLayer.Exceptions;
using Castle.DynamicProxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BookMyRoomTestLayer
{
    [TestClass]
    public class BusinessLayerTests
    {
        [TestMethod]
        public void AddProfileTestTrue()
        {
            UserProfiles userProfiles = new UserProfiles();
            userProfiles.User_EmailID = "vijethGod@gmail.com";
            userProfiles.User_FirstName = "Vijeth";
            userProfiles.User_Lastname = "YO";
            userProfiles.User_Password = "KalingaLOl";
            userProfiles.User_PhoneNumber = "1234567891";

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBusiness>()
                    .Setup(x => x.AddUserProfile(userProfiles))
                    .Returns(true);

                var addUserProfile = mock.Create<IBusiness>();
                var actual = addUserProfile.AddUserProfile(userProfiles);
                Assert.IsTrue(actual);

            }
        }
        [TestMethod]
        public void AddProfileTestFalse()
        {
            UserProfiles userProfiles = new UserProfiles();
            userProfiles.User_EmailID = "vijethGod@gmail.com";
            userProfiles.User_FirstName = "Vijeth";
            userProfiles.User_Lastname = "YO";
            userProfiles.User_Password = "KalingaLOl";
            userProfiles.User_PhoneNumber = "1234567891";

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBusiness>()
                    .Setup(x => x.AddUserProfile(userProfiles))
                    .Returns(false);

                var addUserProfile = mock.Create<IBusiness>();
                var actual = addUserProfile.AddUserProfile(userProfiles);
                Assert.IsFalse(actual);

            }

        }
        [TestMethod]
        public void AddProfileTest()
        {
            UserProfiles userProfiles = new UserProfiles();
            // userProfiles.User_ID = Convert.ToInt32("jkkjkjk");
            Mock<Business> exception = new Mock<Business>();
            Assert.ThrowsException<InvalidProxyConstructorArgumentsException>(() => exception.Object.AddUserProfile(userProfiles));
        }


        [TestMethod]

        public void SearchHotelTrue()
        {
            SearchResult searchResult = new SearchResult();
            searchResult.AirportDistance = 14;
            searchResult.AirportName = "KolkataAirport";

            List<SearchResult> searchResults = new List<SearchResult>();
            searchResults.Add(searchResult);

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBusiness>()
                    .Setup(x => x.SearchHotel("Delhi"))
                    .Returns(searchResults);

                var updateProfile = mock.Create<IBusiness>();
                var actual = updateProfile.SearchHotel("Delhi");
                Assert.AreSame(searchResults, actual);

            }

        }
        [TestMethod]
        public void SearchHotelFalse()
        {
            SearchResult searchResult = new SearchResult();
            searchResult.AirportDistance = 14;
            searchResult.AirportName = "KolkataAirport";

            List<SearchResult> searchResults = new List<SearchResult>();
            searchResults.Add(searchResult);

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBusiness>()
                    .Setup(x => x.SearchHotel("Delhi"))
                    .Returns(searchResults);

                var searchHotel = mock.Create<IBusiness>();
                var actual = searchHotel.SearchHotel("Delhi");
                Assert.AreNotSame(null, actual);

            }

        }


        [TestMethod]
        public void UpdateProfileTrue()
        {
            UserProfiles userProfiles = new UserProfiles();
            using (var mock = AutoMock.GetLoose())
            {
                //mock.Mock<IBusiness>()
                //    .Setup(x => x.UpdateProfile("123", userProfiles))
                //    .Returns(true);
                //var upadateProfile = mock.Create<IBusiness>();
                //var actual = upadateProfile.UpdateProfile("123", userProfiles);
                //Assert.IsTrue(actual);


            }


        }

        [TestMethod]
        public void UpdateProfileFalse()
        {
            UserProfiles userProfiles = new UserProfiles();
            using (var mock = AutoMock.GetLoose())
            {
                //mock.Mock<IBusiness>()
                //    .Setup(x => x.UpdateProfile("123", userProfiles))
                //    .Returns(false);
                //var upadateProfile = mock.Create<IBusiness>();
                //var actual = upadateProfile.UpdateProfile("123", userProfiles);
                //Assert.IsFalse(actual);


            }
        }

        [TestMethod]
        public void AddHotelManagerTrue()
        {
            HotelManager hotelManager = new HotelManager();
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBusiness>()
                    .Setup(x => x.AddHotelManager(hotelManager))
                    .Returns(true);

                var addHotelManagerTrue = mock.Create<IBusiness>();
                var actual = addHotelManagerTrue.AddHotelManager(hotelManager);
                Assert.IsTrue(actual);
            }

        }
        [TestMethod]
        public void AddHotelManagerFalse()
        {
            HotelManager hotelManager = new HotelManager();
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBusiness>()
                    .Setup(x => x.AddHotelManager(hotelManager))
                    .Returns(false);

                var addHotelManagerTrue = mock.Create<IBusiness>();
                var actual = addHotelManagerTrue.AddHotelManager(hotelManager);
                Assert.IsFalse(actual);
            }
        }

        //[TestMethod]
        //public void AuthenticateUserTrue()
        //{
        //    UserProfiles userProfiles = new UserProfiles();
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        mock.Mock<IBusiness>()
        //            .Setup(x => x.AuthenticateUser(userProfiles))
        //            .Returns(userProfiles);

        //        var addHotelManagerTrue = mock.Create<IBusiness>();
        //        var actual = addHotelManagerTrue.AuthenticateUser(userProfiles);
        //        Assert.AreEqual(userProfiles, actual);
        //    }



        //}

        //[TestMethod]
        //public void AuthenticateUserFalse()
        //{
        //    UserProfiles userProfiles = new UserProfiles();
        //    UserProfiles userProfiles1 = new UserProfiles();
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        mock.Mock<IBusiness>()
        //            .Setup(x => x.AuthenticateUser(userProfiles))
        //            .Returns(userProfiles);

        //        var addHotelManagerTrue = mock.Create<IBusiness>();
        //        var actual = addHotelManagerTrue.AuthenticateUser(userProfiles1);
        //        Assert.AreNotEqual(userProfiles, actual);
        //    }





        //}




    }
}
