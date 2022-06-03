using Autofac.Extras.Moq;
using BookMyRoomCommonLayer.Entities;
using BookMyRoomCommonLayer.Exceptions;
using BookMyRoomRepositoryLayer.Implementation;
using BookMyRoomRepositoryLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BookMyRoomTestLayer
{
    [TestClass]
    public class RepositoryLayerTests
    {
        [TestMethod]
        public void SearchCity_Valid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.SearchCity("delhi"))
                    .Returns(GetSampleData());

                var something = mock.Create<IRepository>();
                var expected = GetSampleData();
                var actual = something.SearchCity("delhi");

                Assert.IsTrue(actual != null);
                //Assert.IsTrue(expected != null);

                for (int i = 0; i < actual.Count; i++)
                {
                    Assert.AreEqual(actual[i].Hotel_Name, expected[i].Hotel_Name);
                }
            }
        }
        [TestMethod]
        public void SearchCity_Invalid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.SearchCity("delhi"))
                    .Returns(GetSampleData());

                var something = mock.Create<IRepository>();
                var actual = something.SearchCity("delhiss");
                Assert.AreEqual(null, actual);
            }
        }
        //[TestMethod]
        //public void SearchCity_Exception()
        //{
        //    SQLException sqlException = new SQLException("");
        //    using (var mock=AutoMock.GetLoose())
        //    {
        //        mock.Mock<IRepository>()
        //            .Setup(x => x.SearchCity("delhi"))
        //            .Returns(GetSampleData());
        //        var exceptionThrown = mock.Create<IRepository>();
        //        var actual = exceptionThrown.SearchCity("");
        //        Assert.
        //    }
        //}
        [TestMethod]
        public void AddUserProfiles_Valid()
        {
            UserProfiles userProfiles = new UserProfiles()
            {
                User_FirstName = "Peter",
                User_Lastname = "Sun",
                User_EmailID = "testmail@mail.com",
                User_Password = "testhashed"
            };

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.AddUserProfile(userProfiles))
                    .Returns(true);

                var something = mock.Create<IRepository>();
                var actual = something.AddUserProfile(userProfiles);
                Assert.AreEqual(true, actual);
            }
        }
        [TestMethod]
        public void AddUserProfiles_Invalid()
        {
            UserProfiles userProfiles = new UserProfiles();
            //{
            //    User_FirstName = "Peter",
            //    User_Lastname = "Sun",
            //    User_EmailID = "testmail@mail.com",
            //    User_Password = "testhashed"
            //};

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.AddUserProfile(userProfiles))
                    .Returns(false);

                var something = mock.Create<IRepository>();
                var actual = something.AddUserProfile(userProfiles);
                Assert.IsFalse(actual);
            }
        }
        [TestMethod]
        public void AddUserFeedback_Valid()
        {
            HotelFeedback hotelFeedback = new HotelFeedback()
            {

                Feedback = "It was a great experience"
            };

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.AddUserFeedback(hotelFeedback))
                    .Returns(true);
                var thisObject = mock.Create<IRepository>();
                var actualResult = thisObject.AddUserFeedback(hotelFeedback);
                Console.WriteLine(actualResult);
                Assert.IsNotNull(actualResult);
                Assert.IsTrue(actualResult);
            }
        }
        [TestMethod]
        public void AddUserFeedback_Invalid()
        {
            HotelFeedback hotelFeedback = new HotelFeedback();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.AddUserFeedback(hotelFeedback))
                    .Returns(false);
                var thisObject = mock.Create<IRepository>();
                var actualResult = thisObject.AddUserFeedback(hotelFeedback);
                Console.WriteLine(actualResult);
                Assert.IsNotNull(actualResult);
                Assert.IsFalse(actualResult);
            }
        }
        [TestMethod]
        public void AddHotelManager_Valid()
        {
            HotelManager hotelManager = new HotelManager()
            {
                HotelManager_Name = "Ramesh T",
                HotelManager_PhoneNumber = "9000012345",
                _Designation = "Manager",
                _EmailID = "ramesht@gmail.com",
                _Password = "Ramesh@2",
                _Status = "Active"
            };
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.AddHotelManager(hotelManager))
                    .Returns(true);
                var thisObject = mock.Create<IRepository>();
                var actualResult = thisObject.AddHotelManager(hotelManager);
                Console.WriteLine(actualResult);
                Assert.IsNotNull(actualResult);
                Assert.IsTrue(actualResult);
            }
        }
        [TestMethod]
        public void AddHotelManager_Invalid()
        {
            HotelManager hotelManager = new HotelManager();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.AddHotelManager(hotelManager))
                    .Returns(false);
                var thisObject = mock.Create<IRepository>();
                var actualResult = thisObject.AddHotelManager(hotelManager);
                Console.WriteLine(actualResult);
                Assert.IsNotNull(actualResult);
                Assert.IsFalse(actualResult);
            }
        }
        [TestMethod]
        public void GetHotelFeedbacks_Valid()
        {
            Hotel hotel = new Hotel()
            {
                HotelID = 3
            };
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.GetHotelFeedbacks(hotel))
                    .Returns(GetHotelFeedbacksData());
                var thisObject = mock.Create<IRepository>();
                var actualResult = thisObject.GetHotelFeedbacks(hotel);
                var expectedResult = GetHotelFeedbacksData();
                Console.WriteLine(actualResult[0].Feedback);
                Assert.IsNotNull(actualResult);
                Assert.AreEqual(actualResult[0].Feedback, expectedResult[0].Feedback);
            }
        }
        [TestMethod]
        public void GetHotelFeedbacks_Invalid()
        {
            Hotel hotel = new Hotel()
            {
                HotelID = 150
            };
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.GetHotelFeedbacks(hotel))
                    .Returns(GetHotelFeedbacksDataInvalid());
                var thisObject = mock.Create<IRepository>();
                var actualResult = thisObject.GetHotelFeedbacks(hotel);
                var expectedResult = GetHotelFeedbacksData();
                Console.WriteLine(expectedResult[0].Feedback);
                Console.WriteLine(actualResult[0].Feedback);
                Assert.IsNotNull(actualResult);
                Assert.AreNotEqual(expectedResult[0].Feedback, actualResult[0].Feedback);

            }
        }
        private List<SearchResult> GetSampleData()
        {
            List<SearchResult> searchResultsMockList = new List<SearchResult>
            {
                new SearchResult
                {
                    Hotel_Name="The Leela Ambience Convention",
                    Hotel_Email="leelaambience@gmail.com",
                    Hotel_Phone="9200093000",
                    Hotel_Rating=5,
                    Hotel_Status="Active",
                    Hotel_Address="Yamuna Sports Complex,Maharaja Surajmal Marg,Viswas nagar,Shahdara",
                    Pool=true,
                    Wifi=true,
                    Parking=true,
                    Restaurant=true,
                    CityName="Delhi",
                    AirportName="Indira Gandhi International Airport",
                    AirportDistance=32.6,
                    //RailwayStationName="New Delhi Railway Station",
                    RailwayDistance=12.5,
                    StateName="Delhi"

                }
            };
            return searchResultsMockList;
        }
        private List<HotelFeedback> GetHotelFeedbacksData()
        {
            List<HotelFeedback> hotelFeedbacksList = new List<HotelFeedback>()
            {
                new HotelFeedback
                {

                    Feedback="It was a great experience"
                }

            };
            return hotelFeedbacksList;
        }
        private List<HotelFeedback> GetHotelFeedbacksDataInvalid()
        {
            List<HotelFeedback> hotelFeedbacksList = new List<HotelFeedback>()
            {
                new HotelFeedback
                {

                    Feedback="It was a great exp"
                }

            };
            return hotelFeedbacksList;
        }
        [TestMethod]
        public void UpdatePassword_Valid()
        {
            Update_Password updatePassword = new Update_Password
            {
                Email = "naveena.vella@gmail.com",
                FirstName = "Naveena",
                LastName = "Vella",
                PhoneNo = "9897789767",
                Current_Password = "97e925c8fa68718d4f24040aac7da0b89c7392846d85aaba9a2e385ce269c07a",
                Password = "97e925c8fa68718d4f24040aac7da0b89c7392846d85aaba9a2e385ce269c07a",
            };
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.UpdateProfile(updatePassword.Email, updatePassword))
                    .Returns(updatePassword);

                var something = mock.Create<IRepository>();
                var expected = updatePassword;
                var actual = something.UpdateProfile(updatePassword.Email, updatePassword);

                Assert.IsTrue(actual != null);
                //Assert.IsTrue(expected != null);
                Assert.AreEqual(actual, expected);

            }
        }
        [TestMethod]
        public void UpdatePassword_InValid()
        {
            Update_Password updatePassword = new Update_Password
            {
                Email = "naveena.vella@gmail.com",
                FirstName = "Naveena",
                LastName = "Vella",
                PhoneNo = "9897789767",
                Current_Password = null,
                Password = "97e925c8fa68718d4f24040aac7da0b89c7392846d85aaba9a2e385ce269c07a",
            };
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.UpdateProfile(updatePassword.Email, updatePassword))
                    .Returns(updatePassword);

                var something = mock.Create<IRepository>();
                var expected = updatePassword;
                var actual = something.UpdateProfile("", updatePassword);

                Assert.IsTrue(actual == null);
                //Assert.IsTrue(expected != null);
                Assert.AreNotEqual(actual, expected);

            }
        }
        [TestMethod]
        public void AuthenticateUser_Valid()
        {
            LogInDetails logInDetails = new LogInDetails {
                UserEmail="naveena.vella@gmail.com",
                Password= "97e925c8fa68718d4f24040aac7da0b89c7392846d85aaba9a2e385ce269c07a",
                Designation="User"
            };
            using (var mock = AutoMock.GetLoose())
            {
                UserProfiles user = new UserProfiles();
                user = GetSampleUser();
                mock.Mock<IRepository>()
                    .Setup(x => x.AuthenticateUser(logInDetails))
                    .Returns(user);
                var something = mock.Create<IRepository>();
                var expected = user;
                var actual = something.AuthenticateUser(logInDetails);

                Assert.IsTrue(actual != null);
                //Assert.IsTrue(expected != null);
                Assert.AreEqual(actual, expected);

            }

        }
        [TestMethod]
        public void AuthenticateUser_Invalid()
        {
            LogInDetails logInDetails = new LogInDetails();
            using (var mock = AutoMock.GetLoose())
            {
                UserProfiles user = new UserProfiles();
                user = GetSampleUser();
                mock.Mock<IRepository>()
                    .Setup(x => x.AuthenticateUser(logInDetails))
                    .Returns(null);
                var something = mock.Create<IRepository>();
                var expected = user;
                var actual = something.AuthenticateUser(logInDetails);

                Assert.IsTrue(actual == null);
                //Assert.IsTrue(expected != null);
                Assert.AreNotEqual(actual, expected);

            }
        }
        public UserProfiles GetSampleUser()
        {
            UserProfiles user = new UserProfiles {
                User_EmailID = "naveena.vella@gmail.com",
                User_FirstName="Naveena",
                User_Lastname="Vella",
                User_PhoneNumber= "9096987"
            };
            return user;

        }
        [TestMethod]
        public void AuthenticateManager_Valid()
        {
            LogInDetails logInDetails = new LogInDetails
            {
                UserEmail = "suresht@gmail.com",
                Password = "a3f699667f0c12a4b2206e792af2e5bfeb1cd733acf1c3123ea04c4056663bbd",
                Designation = "Manager"
            };
            using (var mock = AutoMock.GetLoose())
            {
                HotelManager manager = new HotelManager();
                manager = GetSampleManager();
                mock.Mock<IRepository>()
                    .Setup(x => x.AuthenticateUser(logInDetails))
                    .Returns(manager);
                var something = mock.Create<IRepository>();
                var expected = manager;
                var actual = something.AuthenticateUser(logInDetails);

                Assert.IsTrue(actual != null);
                //Assert.IsTrue(expected != null);
                Assert.AreEqual(actual, expected);

            }
        }
        public HotelManager GetSampleManager()
        {
            HotelManager manager = new HotelManager {
                HotelManager_ID=4,
                HotelManager_Name= "Suresh T",
                HotelManager_PhoneNumber= "90111112346",
                _Designation="Manager",
                _EmailID="suresht@gmail.com",
                _Password=null,
                _Status="Active"
            };
            return manager;
        }
        [TestMethod]
        public void AuthenticateManager_Invalid()
        {
            LogInDetails logInDetails = new LogInDetails();
            using (var mock = AutoMock.GetLoose())
            {
                HotelManager manager = new HotelManager();
                 manager= GetSampleManager();
                mock.Mock<IRepository>()
                    .Setup(x => x.AuthenticateUser(logInDetails))
                    .Returns(null);
                var something = mock.Create<IRepository>();
                var expected = manager;
                var actual = something.AuthenticateUser(logInDetails);

                Assert.IsTrue(actual == null);
                //Assert.IsTrue(expected != null);
                Assert.AreNotEqual(actual, expected);

            }
        }
        [TestMethod]
        public void FetchHotels_Valid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.FetchHotels(4))
                    .Returns(GetSampleHotel());

                var something = mock.Create<IRepository>();
                var expected = GetSampleHotel();
                var actual = something.FetchHotels(4);

                Assert.IsTrue(actual != null);
                //Assert.IsTrue(expected != null);

                for (int i = 0; i < actual.Count; i++)
                {
                    Assert.AreEqual(actual[i].Hotel_Name, expected[i].Hotel_Name);
                }
            }
        }
        public List<Hotel> GetSampleHotel()
        {
            List<Hotel> searchResultsMockList = new List<Hotel>
            {
                new Hotel
                {
                    Hotel_Name="The Leela Ambience Convention",
                    Hotel_EmailID="leelaambience@gmail.com",
                    Hotel_PhoneNumber="9200093000",
                    Hotel_Rating=5,
                    Hotel_Status="Active",
                    Hotel_Address="Yamuna Sports Complex,Maharaja Surajmal Marg,Viswas nagar,Shahdara",
                    Pool=true,
                    Wifi=true,
                    Parking=true,
                    Restaurant=true,
                    AirportDistance=32.6,
                    //RailwayStationName="New Delhi Railway Station",
                    RailwayDistance=12.5

                }
            };
            return searchResultsMockList;
        }
        [TestMethod]
        public void FetchHotel_Invalid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.FetchHotels(90))
                    .Returns(GetSampleHotel());

                var something = mock.Create<IRepository>();
                var actual = something.FetchHotels(0);
                Assert.AreEqual(null, actual);
            }
        }
        [TestMethod]
        public void FetchHotelForManager_Valid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.FetchHotelsForManager("suresht@gmail.com"))
                    .Returns(GetSampleData());

                var something = mock.Create<IRepository>();
                var expected = GetSampleData();
                var actual = something.FetchHotelsForManager("suresht@gmail.com");

                Assert.IsTrue(actual != null);
                //Assert.IsTrue(expected != null);

                for (int i = 0; i < actual.Count; i++)
                {
                    Assert.AreEqual(actual[i].Hotel_Name, expected[i].Hotel_Name);
                }
            }
        }
        [TestMethod]
        public void FetchHotelForManager_Invalid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.FetchHotelsForManager("suresht@gmail.com"))
                    .Returns(GetSampleData());

                var something = mock.Create<IRepository>();
                var actual = something.FetchHotelsForManager(null);
                Assert.AreEqual(null, actual);
            }
        }
        [TestMethod]
        public void BookHotel_Valid()
        {
            BookingEntity book = new BookingEntity
            {
                BookId = 15,
                UserId = 3,
                Premium = 2,
                Deluxe = 1,
                NumberOfAdults=1,
                NumberOfChildren=1,
                NumberOfInfants=0
            };
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.BookHotel(book))
                    .Returns(book);
                var expected = book;
                var something = mock.Create<IRepository>();
                var actual = something.BookHotel(book);
                Assert.AreEqual(expected, actual);
            }
        }
        public BookingEntity GetSampleBook()
        {
            BookingEntity book = new BookingEntity
            {
                BookId = 15,
                UserId = 3,
                Premium = 2,
                Deluxe = 1,
                NumberOfAdults = 1,
                NumberOfChildren = 1,
                NumberOfInfants = 0
            };
            return book;
        }
        [TestMethod]
        public void BookHotel_InValid()
        {
            BookingEntity book = new BookingEntity();
            var expected = book;
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.BookHotel(book))
                    .Returns(GetSampleBook());

                var something = mock.Create<IRepository>();
                var actual = something.BookHotel(book);
                Assert.AreNotEqual(actual,expected);
            }
        }
        [TestMethod]
        public void ChangeHotelStatus_Valid()
        {

        }
    }
}
