using BookMyRoomCommonLayer.Entities;
using BookMyRoomCommonLayer.Exceptions;
using BookMyRoomRepositoryLayer.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace BookMyRoomRepositoryLayer.Implementation
{
    public class RepositoryClass : IRepository
    {
        private RepositoryContext repositoryContext;
        public RepositoryClass(RepositoryContext _repositoryContext)
        {
            repositoryContext = _repositoryContext;
        }
        public bool CheckEmailID(string email)
        {
            UserProfiles userProfiles = repositoryContext.UserProfiles.FirstOrDefault(
               x => x.User_EmailID == email);
            if (userProfiles == null)
                return true;
            else
                return false;
        }
        public bool CheckEmailIDForHotel(string email)
        {
            Hotel hotelDetails = repositoryContext.Hotels.FirstOrDefault(
               x => x.Hotel_EmailID == email);
            if (hotelDetails == null)
                return true;
            else
                return false;
        }
        public bool CheckHotelManagerEmailID(string email)
        {
            HotelManager userProfiles = repositoryContext.HotelManagers.FirstOrDefault(
               x => x._EmailID == email);
            if (userProfiles == null)
                return true;
            else
                return false;
        }
        public bool AddUserProfile(UserProfiles userProfiles)
        {
            try
            {
                bool flag = CheckEmailID(userProfiles.User_EmailID);
                if (flag)
                {
                    repositoryContext.UserProfiles.Add(userProfiles);
                    repositoryContext.SaveChanges();
                }
                else
                    return false;
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("There seems to be an error with the connectivity. Try again");
            }
            catch (Exception exception)
            {
                throw new GeneralException("There was an error with the data. Please try again");
            }
            return true;
        }
        public bool AddUserFeedback(HotelFeedback hotelFeedback)
        {
            try
            {
                repositoryContext.Feedbacks.Add(hotelFeedback);
                repositoryContext.SaveChanges();
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("There seems to be an error with the connectivity. Try again");
            }
            catch (Exception exception)
            {
                throw new GeneralException("There was an error with the data. Please try again");
            }
            return true;
        }
        public bool AddHotelManager(HotelManager hotelManager)
        {
            try
            {
                if (CheckHotelManagerEmailID(hotelManager._EmailID))
                {
                    repositoryContext.HotelManagers.Add(hotelManager);
                    repositoryContext.SaveChanges();
                }
                else
                    return false;
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("There seems to be an error with the connectivity. Try again");
            }
            catch (Exception exception)
            {
                throw new GeneralException("There was an error with the data. Please try again");
            }
            return true;
        }
        public List<SearchResult> SearchCity(string search)
        {
            List<SearchResult> searchResultsList = new List<SearchResult>();
            SearchResult searchResult;
            try
            {
                var hotelDetails = (from h in repositoryContext.Hotels
                                    join manager in repositoryContext.HotelManagers on h.HotelManagerID.HotelManager_ID equals manager.HotelManager_ID
                                    join city in repositoryContext.City on h.CityID.CityID equals city.CityID
                                    join state in repositoryContext.State on city.StateID.StateID equals state.StateID
                                    join airport in repositoryContext.Airports on h.AirportID.AirportID equals airport.AirportID
                                    join rail in repositoryContext.RailwayStation on h.RailwayStationID.RailwayStationID equals rail.RailwayStationID

                                    where (city.CityName.Contains(search) || state.StateName.Contains(search) || h.Hotel_Name.Contains(search)) && !manager._Status.Equals("Deactivated") && !h.Hotel_Status.Equals("Deactivated")
                                    select new
                                    {
                                        h.HotelID,
                                        h.Hotel_Name,
                                        h.Hotel_EmailID,
                                        h.Hotel_Address,
                                        h.Hotel_Rating,
                                        h.Hotel_PhoneNumber,
                                        h.Hotel_Status,
                                        h.Parking,
                                        h.Pool,
                                        h.Wifi,
                                        h.Restaurant,
                                        city.CityName,
                                        state.StateName,
                                        airport.AirportName,
                                        rail.RailwayStationName,
                                        h.AirportDistance,
                                        h.RailwayDistance,

                                    }).ToList();

                foreach (var a in hotelDetails)
                {
                    searchResult = new SearchResult();
                    searchResult.Hotel_Id = a.HotelID;
                    searchResult.Hotel_Name = a.Hotel_Name;
                    searchResult.Hotel_Address = a.Hotel_Address;
                    searchResult.Hotel_Email = a.Hotel_EmailID;
                    searchResult.Hotel_Status = a.Hotel_Status;
                    searchResult.Hotel_Phone = a.Hotel_PhoneNumber;
                    searchResult.Parking = a.Parking;
                    searchResult.Pool = a.Pool;
                    searchResult.Wifi = a.Wifi;
                    searchResult.Restaurant = a.Restaurant;
                    searchResult.CityName = a.CityName;
                    searchResult.StateName = a.StateName;
                    searchResult.AirportName = a.AirportName;
                    searchResult.AirportDistance = a.AirportDistance;
                    searchResult.RailwayStationName = a.RailwayStationName;
                    searchResult.RailwayDistance = a.RailwayDistance;
                    var hotelPics = (from h in repositoryContext.Hotels

                                     join pics in repositoryContext.Pictures on h.HotelID equals pics.Hotels.HotelID
                                     where a.HotelID == pics.Hotels.HotelID
                                     select

                                         pics.Picture
                                     ).ToList();
                    var hotelFeedback = (from h in repositoryContext.Hotels
                                         join hotelFeedbacks in repositoryContext.Feedbacks on h.HotelID equals hotelFeedbacks._Hotel.HotelID
                                         where a.HotelID == hotelFeedbacks._Hotel.HotelID
                                         select
                                             hotelFeedbacks
                                    ).ToList();
                    List<HotelFeedback> feedbacklist = new List<HotelFeedback>();
                    double feedbackRatingSum = 0;
                    foreach (var item in hotelFeedback)
                    {
                        HotelFeedback feedback = new HotelFeedback();
                        feedback.Feedback = item.Feedback;
                        feedback.Rating = item.Rating;
                        feedbackRatingSum = feedbackRatingSum + item.Rating;
                        feedback.Nickname = item.Nickname;
                        feedbacklist.Add(feedback);
                    }
                    searchResult.Pictures = hotelPics;
                    searchResult.Hotel_Rating = (float)Math.Round((feedbackRatingSum / feedbacklist.Count()), 1, MidpointRounding.ToEven);
                    //searchResult.Hotel_Rating=(float) Math.Round(feedbackRatingSum/ feedbacklist.Count());
                    searchResult.FeedBacks = feedbacklist;
                    searchResultsList.Add(searchResult);
                }
                if (searchResultsList.Count() == 0)
                    throw new DataNotFound("Data Not Found!!!");
            }



            catch (DataNotFound dataNotFound)
            {
                throw new DataNotFound("Data Not Found!!!");
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("There seems to be an error with the connectivity. Try again");
            }
            catch (Exception exception)
            {
                throw new GeneralException("There was an error with the data. Please try again");
            }
            return searchResultsList;
        }
        public Update_Password UpdateProfile(string id, Update_Password userProfile)
        {
            try
            {
                if (userProfile.LastName != null)
                {
                    var std = repositoryContext.UserProfiles.First(i => i.User_EmailID == id);

                    if (userProfile.Password == "")
                    {
                        //std = repositoryContext.UserProfiles.First(i => i.User_EmailID == id);
                        std.User_FirstName = userProfile.FirstName;
                        std.User_Lastname = userProfile.LastName;
                        std.User_PhoneNumber = userProfile.PhoneNo;
                        repositoryContext.SaveChanges();
                    }
                    else
                    {
                        if (std.User_Password.Equals(userProfile.Current_Password))
                        {
                            std.User_FirstName = userProfile.FirstName;
                            std.User_Lastname = userProfile.LastName;
                            std.User_PhoneNumber = userProfile.PhoneNo;
                            std.User_Password = userProfile.Password;
                            repositoryContext.SaveChanges();
                        }
                        else
                        {
                            throw new IncorrectCurrentPassword("Entered current password is not matching with your password");
                        }
                    }
                }
                else
                {
                    var hotelManager = repositoryContext.HotelManagers.First(x => x._EmailID== id);
                    if (userProfile.Password == "")
                    {
                        
                        hotelManager.HotelManager_Name = userProfile.FirstName;
                        hotelManager.HotelManager_PhoneNumber = userProfile.PhoneNo;
                        repositoryContext.SaveChanges();
                    }
                    else
                    {
                        if (hotelManager._Password.Equals(userProfile.Current_Password))
                        {
                            hotelManager.HotelManager_Name = userProfile.FirstName;
                            hotelManager.HotelManager_PhoneNumber = userProfile.PhoneNo;
                            
                            hotelManager._Password = userProfile.Password;
                            repositoryContext.SaveChanges();
                        }
                        else
                        {
                            throw new IncorrectCurrentPassword("Entered current password is not matching with your password");
                        }
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("There seems to be an error with the connectivity. Try again");
            }
            catch (Exception exception)
            {
                throw new GeneralException("There was an error with the data. Please try again");
            }
            return userProfile;
        }
        public List<HotelFeedback> GetHotelFeedbacks(Hotel hotel)
        {
            HotelFeedback hotelFeedback = new HotelFeedback();
            List<HotelFeedback> hotelFeedbacksList = new List<HotelFeedback>();
            try
            {
                var list = from h in repositoryContext.Hotels
                           join feed in repositoryContext.Feedbacks on h.HotelID equals feed._Hotel.HotelID
                           where h.HotelID == hotel.HotelID
                           select new
                           {
                               feed.FeedbackID,
                               feed.Feedback
                           };
                foreach (var item in list)
                {
                    hotelFeedback.FeedbackID = item.FeedbackID;
                    hotelFeedback.Feedback = item.Feedback;
                    hotelFeedbacksList.Add(hotelFeedback);
                }
                return hotelFeedbacksList;
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("There seems to be an error with the connectivity. Try again");
            }
            catch (Exception exception)
            {
                throw new GeneralException("There was an error with the data. Please try again");
            }
        }


        public HotelManager HotelManagerLogIn(LogInDetails logInDetails)
        {
            HotelManager hotelProfiles = repositoryContext.HotelManagers.FirstOrDefault(
            x => x._EmailID == logInDetails.UserEmail && x._Password == logInDetails.Password);
            if (hotelProfiles != null)
            {
                hotelProfiles._Password = null;
            }
            return hotelProfiles;
        }

        public dynamic AuthenticateUser(LogInDetails user)
        {
            if (user.Designation == "User")
            {
                UserProfiles userProfiles = repositoryContext.UserProfiles.FirstOrDefault(
                    x => x.User_EmailID == user.UserEmail && x.User_Password == user.Password);
                if (userProfiles != null)
                {
                    userProfiles.User_Password = null;
                }
                else
                {
                    throw new InvalidUserException("Invalid login information");
                }
                return userProfiles;
            }
            else
            {
                HotelManager hotelManager = repositoryContext.HotelManagers.FirstOrDefault(
                   x => x._EmailID == user.UserEmail && x._Password == user.Password);
                if (hotelManager != null)
                    hotelManager._Password = null;
                else
                {
                    throw new InvalidUserException("Invalid login information");
                }
                return hotelManager;
            }
        }

        public List<HotelFetch> GetHotelManagers()
        {
            var manager = (from d in repositoryContext.HotelManagers where d._Designation != "admin" select d).ToList();
            List<HotelFetch> list = new List<HotelFetch>();
            foreach (var a in manager)
            {
                HotelFetch temp = new HotelFetch();
                temp.HotelManager_ID = a.HotelManager_ID;
                temp.HotelManager_Name = a.HotelManager_Name;
                temp.HotelManager_PhoneNumber = a.HotelManager_PhoneNumber;
                temp._EmailID = a._EmailID;
                temp._Status = a._Status;
                temp.Count_Hotel = (from h in repositoryContext.HotelManagers
                                    join feed in repositoryContext.Hotels on h.HotelManager_ID equals feed.HotelManagerID.HotelManager_ID
                                    where h.HotelManager_ID == a.HotelManager_ID
                                    select feed).ToList().Count;
                list.Add(temp);
            }
            return list;
        }

        public List<Hotel> FetchHotels(int x)
        {
            List<Hotel> list = new List<Hotel>();
            list = (from h in repositoryContext.HotelManagers
                    join feed in repositoryContext.Hotels on h.HotelManager_ID equals feed.HotelManagerID.HotelManager_ID
                    where h.HotelManager_ID == x
                    select feed).ToList();
            return list;
        }

        public List<SearchResult> FetchHotelsForManager(string Email)
        {
            List<SearchResult> searchResultsList = new List<SearchResult>();
            SearchResult searchResult;
            try
            {
                var hotelDetails = (from h in repositoryContext.Hotels
                                    join city in repositoryContext.City on h.CityID.CityID equals city.CityID
                                    join state in repositoryContext.State on city.StateID.StateID equals state.StateID
                                    join airport in repositoryContext.Airports on h.AirportID.AirportID equals airport.AirportID
                                    join rail in repositoryContext.RailwayStation on h.RailwayStationID.RailwayStationID equals rail.RailwayStationID
                                    join hotelManager in repositoryContext.HotelManagers on h.HotelManagerID.HotelManager_ID equals hotelManager.HotelManager_ID
                                    where hotelManager._EmailID == Email
                                    select new
                                    {
                                        h.HotelID,
                                        h.Hotel_Name,
                                        h.Hotel_EmailID,
                                        h.Hotel_Address,
                                        h.Hotel_Rating,
                                        h.Hotel_PhoneNumber,
                                        h.Hotel_Status,
                                        h.Parking,
                                        h.Pool,
                                        h.Wifi,
                                        h.Restaurant,
                                        city.CityName,
                                        state.StateName,
                                        airport.AirportName,
                                        rail.RailwayStationName,
                                        h.AirportDistance,
                                        h.RailwayDistance,
                                    }).ToList();

                foreach (var a in hotelDetails)
                {
                    searchResult = new SearchResult();
                    searchResult.Hotel_Name = a.Hotel_Name;
                    searchResult.Hotel_Address = a.Hotel_Address;
                    searchResult.Hotel_Email = a.Hotel_EmailID;
                    searchResult.Hotel_Rating = a.Hotel_Rating;
                    searchResult.Hotel_Status = a.Hotel_Status;
                    searchResult.Hotel_Phone = a.Hotel_PhoneNumber;
                    searchResult.Parking = a.Parking;
                    searchResult.Pool = a.Pool;
                    searchResult.Wifi = a.Wifi;
                    searchResult.Restaurant = a.Restaurant;
                    searchResult.CityName = a.CityName;
                    searchResult.StateName = a.StateName;
                    searchResult.AirportName = a.AirportName;
                    searchResult.AirportDistance = a.AirportDistance;
                    searchResult.RailwayStationName = a.RailwayStationName;
                    searchResult.RailwayDistance = a.RailwayDistance;
                    var hotelPics = (from h in repositoryContext.Hotels

                                     join pics in repositoryContext.Pictures on h.HotelID equals pics.Hotels.HotelID
                                     where a.HotelID == pics.Hotels.HotelID
                                     select

                                         pics.Picture
                                     ).ToList();
                    var hotelFeedback = (from h in repositoryContext.Hotels
                                         join hotelFeedbacks in repositoryContext.Feedbacks on h.HotelID equals hotelFeedbacks.Hotel
                                         where a.HotelID == hotelFeedbacks.Hotel
                                         select
                                             hotelFeedbacks
                                    ).ToList();
                    searchResult.Pictures = hotelPics;
                    searchResult.FeedBacks = hotelFeedback;
                    searchResultsList.Add(searchResult);
                }
                if (searchResultsList.Count() == 0)
                    throw new DataNotFound("Data Not Found!!!");
            }
            catch (DataNotFound dataNotFound)
            {
                throw new DataNotFound("Data Not Found!!!");
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("There seems to be an error with the connectivity. Try again");
            }
            catch (Exception exception)
            {
                throw new GeneralException("There was an error with the data. Please try again");
            }
            return searchResultsList;
        }

        public BookingEntity BookHotel(BookingEntity bookingEntity)
        {
            try
            {
                repositoryContext.Booking.Add(bookingEntity);
                repositoryContext.SaveChanges();
            }
            catch (RoomNotavailable e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Something Went Wrong!!!!" + e);
            }
            return bookingEntity;
        }

        public void ChangeManagerStatus(int id, string status)
        {
            var std = repositoryContext.HotelManagers.First(i => i.HotelManager_ID == id);
            std._Status = status;

            if (status == "Active")
            {
                std._Status = "Deactivated";
            }
            else
            {
                std._Status = "Active";
            }
            repositoryContext.SaveChanges();
        }

        public void ChangeHotelStatus(int id, string status)
        {
            var std = repositoryContext.Hotels.First(i => i.HotelID == id);
            if (status == "Active")
            {
                std.Hotel_Status = "Deactivated";
            }
            else
            {
                std.Hotel_Status = "Active";
            }

            repositoryContext.SaveChanges();
        }
        /// <summary>
        /// Adds a hotel in deactivated mode to the database.
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="city"></param>
        /// <param name="hotelManagerEmail"></param>
        /// <returns>If hotel is added successfully then returns true</returns>
        public bool AddHotel(SearchResult hotel, string city, string hotelManagerEmail)
        {
            try
            {
                Hotel hotels = new Hotel();
                bool flag = CheckEmailIDForHotel(hotel.Hotel_Email);
                if (flag)
                {
                    City cityvalue = repositoryContext.City.First(i => i.CityName == city);
                    Airports airportsName = repositoryContext.Airports.First(i => i.CityID == cityvalue.CityID);
                    RailwayStation railwayStationName = repositoryContext.RailwayStation.First(i => i.CityID == cityvalue.CityID);
                    HotelManager hotelManager = repositoryContext.HotelManagers.First(i => i._EmailID == hotelManagerEmail);
                    hotels.Hotel_Name = hotel.Hotel_Name;
                    hotels.Hotel_PhoneNumber = hotel.Hotel_Phone;
                    hotels.Hotel_EmailID = hotel.Hotel_Email;
                    hotels.Hotel_Address = hotel.Hotel_Address;
                    hotels.Parking = hotel.Parking;
                    hotels.Pool = hotel.Pool;
                    hotels.Restaurant = hotel.Restaurant;
                    hotels.RailwayDistance = hotel.RailwayDistance;
                    hotels.AirportDistance = hotel.AirportDistance;
                    hotels.Hotel_Rating = hotel.Hotel_Rating;
                    hotels.Wifi = hotel.Wifi;
                    hotels.HotelManagerID = new HotelManager();
                    hotels.HotelManagerID.HotelManager_ID = hotelManager.HotelManager_ID;
                    hotels.CityID = new City();
                    hotels.CityID.CityID = cityvalue.CityID;
                    hotels.AirportID = new Airports();
                    hotels.AirportID.AirportID = airportsName.AirportID;
                    hotels.RailwayStationID = new RailwayStation();
                    hotels.RailwayStationID.RailwayStationID = railwayStationName.RailwayStationID;
                    hotels.Hotel_Status = "Deactivated";
                    hotels.PremiumRoom = hotel.BudgetRoomCount;
                    hotels.DeluxeRoom = hotel.DeluxeRoomCount;
                    repositoryContext.Hotels.Add(hotels);
                    repositoryContext.SaveChanges();
                    Hotel fetchingDetails = repositoryContext.Hotels.First(x => x.Hotel_EmailID == hotels.Hotel_EmailID);
                    foreach (var pic in hotel.Pictures)
                    {
                        Pictures addingPics = new Pictures();
                        addingPics.HotelID = fetchingDetails.HotelID;
                        addingPics.Picture = pic;
                        repositoryContext.Pictures.Add(addingPics);
                        repositoryContext.SaveChanges();
                    }
                    for(int i=1;i<=hotel.BudgetRoomCount;i++)
                    {
                        RoomEntity budgetRoom = new RoomEntity();
                        budgetRoom.HotelId = fetchingDetails.HotelID;
                        budgetRoom.RoomTypeId = 1;
                        budgetRoom.Cost = hotel.BudgetRoomPrice;
                        budgetRoom.WIFI = false;
                        budgetRoom.TV = true;
                        budgetRoom.RoomService = true;
                        budgetRoom.Geyser = false;
                        budgetRoom.AC = false;
                        repositoryContext.RoomTable.Add(budgetRoom);
                        repositoryContext.SaveChanges();
                    }
                    for (int i = 1; i <= hotel.DeluxeRoomCount; i++)
                    {
                        RoomEntity deluxeRoom = new RoomEntity();
                        deluxeRoom.HotelId = fetchingDetails.HotelID;
                        deluxeRoom.RoomTypeId = 2;
                        deluxeRoom.Cost = hotel.DeluxeRoomPrice;
                        deluxeRoom.WIFI = true;
                        deluxeRoom.TV = true;
                        deluxeRoom.RoomService = true;
                        deluxeRoom.Geyser = true;
                        deluxeRoom.AC = true;
                        repositoryContext.RoomTable.Add(deluxeRoom);
                        repositoryContext.SaveChanges();
                    }
                }
                else
                    return false;
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("There seems to be an error with the connectivity. Try again");
            }
            catch (Exception exception)
            {
                throw new GeneralException("There was an error with the data. Please try again");
            }
            return true;
        }
        /// <summary>
        /// Updates the hotel already present in the database.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Returns true if the hotel is updated correctly</returns>
        public bool UpdateHotel(SearchResult hotel)
        {
            try
            {
                Hotel hotels = repositoryContext.Hotels.First(x => x.Hotel_EmailID == hotel.Hotel_Email);
                 //City cityvalue = repositoryContext.City.First(i => i.CityName == city);
                 //   Airports airportsName = repositoryContext.Airports.First(i => i.CityID == cityvalue.CityID);
                 //   RailwayStation railwayStationName = repositoryContext.RailwayStation.First(i => i.CityID == cityvalue.CityID);
                 //   HotelManager hotelManager = repositoryContext.HotelManagers.First(i => i._EmailID == hotelManagerEmail);
                    hotels.Hotel_Name = hotel.Hotel_Name;
                    hotels.Hotel_PhoneNumber = hotel.Hotel_Phone;
                    hotels.Hotel_Address = hotel.Hotel_Address;
                    hotels.Parking = hotel.Parking;
                    hotels.Pool = hotel.Pool;
                    hotels.Restaurant = hotel.Restaurant;
                    hotels.RailwayDistance = hotel.RailwayDistance;
                    hotels.AirportDistance = hotel.AirportDistance;
                    hotels.Hotel_Rating = hotel.Hotel_Rating;
                    hotels.Wifi = hotel.Wifi;
                    hotels.Hotel_Status = "Deactivate";
                    repositoryContext.SaveChanges();
                    foreach (var pic in hotel.Pictures)
                    {
                    Pictures addingPics = new Pictures();
                    addingPics.HotelID = hotels.HotelID;
                    addingPics.Picture = pic;
                    repositoryContext.Pictures.Add(addingPics);
                    repositoryContext.SaveChanges();
                }
               

            }
            catch (SqlException sqlException)
            {
                //StreamWriter streamWriter = new StreamWriter(@"D:\\BookMyRoomExceptions.txt");
                //ExceptionLog exceptionCaught = new ExceptionLog();
                //exceptionCaught.ExceptionString = sqlException.Message;
                //exceptionCaught.Exception_Date = DateTime.Now;
                //streamWriter.Write("\n");
                //streamWriter.Write(exceptionCaught.ExceptionString + "\t");
                //streamWriter.Write(exceptionCaught.Exception_Date + "\n");
                //streamWriter.Flush();
                //streamWriter.Close();
                throw new SQLException("There seems to be an error with the connectivity. Try again");
            }
            catch (Exception exception)
            {
                //StreamWriter streamWriter = new StreamWriter(@"D:\\BookMyRoomExceptions.txt");
                //ExceptionLog exceptionCaught = new ExceptionLog();
                //exceptionCaught.ExceptionString = exception.Message;
                //exceptionCaught.Exception_Date = DateTime.Now;
                //streamWriter.Write("\n");
                //streamWriter.Write(exceptionCaught.ExceptionString + "\t");
                //streamWriter.Write(exceptionCaught.Exception_Date + "\n");
                //streamWriter.Flush();
                //streamWriter.Close();
                throw new GeneralException("There was an error with the data. Please try again");
            }
            return true;
        }
        /// <summary>
        /// Getting Particular Hotel based on Hotel Name and City Name
        /// </summary>
        /// <param name="searchResult"></param>
        /// <returns></returns>
        public SearchResult GetParticularHotel(SearchResult searchResult)
        {
            dynamic result, hotelPics, hotelFeedback;
            try
            {
                result = (from hotels in repositoryContext.Hotels
                          join city in repositoryContext.City on hotels.CityID.CityID equals city.CityID
                          join state in repositoryContext.State on city.StateID.StateID equals state.StateID
                          join airport in repositoryContext.Airports on hotels.AirportID.AirportID equals airport.AirportID
                          join rail in repositoryContext.RailwayStation on hotels.RailwayStationID.RailwayStationID equals rail.RailwayStationID
                          where hotels.CityID.CityName.Equals(searchResult.CityName) && hotels.Hotel_Name.Equals(searchResult.Hotel_Name)
                          select new
                          {
                              hotels.HotelID,
                              hotels.Hotel_Name,
                              hotels.Hotel_EmailID,
                              hotels.Hotel_Address,
                              hotels.Hotel_Rating,
                              hotels.Hotel_PhoneNumber,
                              hotels.Hotel_Status,
                              hotels.Parking,
                              hotels.Pool,
                              hotels.Wifi,
                              hotels.Restaurant,
                              city.CityName,
                              state.StateName,
                              airport.AirportName,
                              rail.RailwayStationName,
                              hotels.AirportDistance,
                              hotels.RailwayDistance,
                          }).ToList();
                hotelPics = (from hotel in repositoryContext.Hotels
                             join pics in repositoryContext.Pictures on hotel.HotelID equals pics.Hotels.HotelID
                             where hotel.Hotel_Name == searchResult.Hotel_Name && hotel.HotelID == pics.Hotels.HotelID
                             select

                                 pics.Picture
                                         ).ToList();
                hotelFeedback = (from hotel in repositoryContext.Hotels
                                 join hotelFeedbacks in repositoryContext.Feedbacks on hotel.HotelID equals hotelFeedbacks.Hotel
                                 where hotel.Hotel_Name == searchResult.Hotel_Name && hotel.HotelID == hotelFeedbacks.Hotel
                                 select
                                     hotelFeedbacks
                                ).ToList();
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("Error while retrieving particular hotel details" + sqlException);
            }
            catch (Exception)
            {
                throw new SQLException("Exception occured while retrieving particular hotel details");
            }
            SearchResult hotelResult = new SearchResult();
            foreach (var hoteldetails in result)
            {
                hotelResult.AirportDistance = hoteldetails.AirportDistance;
                hotelResult.AirportName = hoteldetails.AirportName;
                hotelResult.CityName = hoteldetails.CityName;
                hotelResult.Hotel_Id = hoteldetails.HotelID;
                hotelResult.Hotel_Address = hoteldetails.Hotel_Address;
                hotelResult.Hotel_Email = hoteldetails.Hotel_EmailID;
                hotelResult.Hotel_Name = hoteldetails.Hotel_Name;
                hotelResult.Pictures = hotelPics;
                hotelResult.FeedBacks = hotelFeedback;
                hotelResult.Hotel_Phone = hoteldetails.Hotel_PhoneNumber;
                hotelResult.Hotel_Rating = hoteldetails.Hotel_Rating;
                hotelResult.Hotel_Status = hoteldetails.Hotel_Status;
                hotelResult.Parking = hoteldetails.Parking;
                hotelResult.Pool = hoteldetails.Pool;
                hotelResult.RailwayDistance = hoteldetails.RailwayDistance;
                hotelResult.RailwayStationName = hoteldetails.RailwayStationName;
                hotelResult.Restaurant = hoteldetails.Restaurant;
                hotelResult.StateName = hoteldetails.StateName;
                hotelResult.Wifi = hoteldetails.Wifi;
            }
            return hotelResult;

        }

        public List<RoomCostEntity> GetRoomCost(int id)
        {




            dynamic premiumRoomCost, deluxeRoomCost;
            try
            {
                premiumRoomCost = (from cost in repositoryContext.RoomTable
                                   join roomtid in repositoryContext.RoomTypeTable on cost.RoomTypeId equals roomtid.RoomTypeid
                                   where cost.HotelId == id && cost.RoomTypeId == 1
                                   select new
                                   {
                                       cost.Cost,
                                       cost.AC,
                                       cost.Geyser,
                                       cost.TV,
                                       cost.WIFI,
                                       cost.RoomService
                                   }).ToList();
                deluxeRoomCost = (from cost in repositoryContext.RoomTable
                                  join roomtid in repositoryContext.RoomTypeTable on cost.RoomTypeId equals roomtid.RoomTypeid
                                  where cost.HotelId == id && cost.RoomTypeId == 2
                                  select new
                                  {
                                      cost.Cost,
                                      cost.AC,
                                      cost.Geyser,
                                      cost.TV,
                                      cost.WIFI,
                                      cost.RoomService
                                  }).ToList();

            }
            catch (SqlException sqlException)
            {
                throw new SQLException(sqlException.Message);
            }
            catch (Exception exception)
            {
                throw new SQLException(exception.Message);
            }
            List<RoomCostEntity> roomCostEntity = new List<RoomCostEntity>();
            RoomCostEntity room = new RoomCostEntity()
            {
                HotelId = id,
                PremiumRoomCost = Convert.ToDouble(premiumRoomCost[0].Cost),
                AC = premiumRoomCost[0].AC,
                Geyser = premiumRoomCost[0].Geyser,
                TV = premiumRoomCost[0].TV,
                WIFI = premiumRoomCost[0].WIFI,
                RoomService = premiumRoomCost[0].RoomService
            };
            roomCostEntity.Add(room);
            room = new RoomCostEntity()
            {
                HotelId = id,
                DeluxeRoomCost = Convert.ToDouble(deluxeRoomCost[0].Cost),
                AC = deluxeRoomCost[0].AC,
                Geyser = deluxeRoomCost[0].Geyser,
                TV = deluxeRoomCost[0].TV,
                WIFI = deluxeRoomCost[0].WIFI,
                RoomService = deluxeRoomCost[0].RoomService
            };
            roomCostEntity.Add(room);
            return roomCostEntity;
        }

        public RoomAvailabilityEntity CheckRoomAvailability(RoomAvailabilityEntity roomAvailabilityEntity)
        {
            dynamic totalrooms, resultPremium, resultDeluxe;
            try
            {
                totalrooms = (from rooms in repositoryContext.Hotels
                              where rooms.HotelID == roomAvailabilityEntity.HotelId
                              select new { rooms.PremiumRoom, rooms.DeluxeRoom }).ToList();
                resultPremium = (from rooms in repositoryContext.Booking
                                 where rooms.HotelID == roomAvailabilityEntity.HotelId &&
                                 rooms.CheckInDate.ToShortDateString() == roomAvailabilityEntity.CheckIn.ToShortDateString() &&
                                 rooms.CheckOutDate.ToShortDateString() == roomAvailabilityEntity.CheckOut.ToShortDateString()
                                 group rooms.Premium by new { rooms.CheckInDate, rooms.CheckOutDate }
                                 into premiumroomcount
                                 select premiumroomcount.Sum()
                                  ).ToList();
                resultDeluxe = (from rooms in repositoryContext.Booking
                                where rooms.HotelID == roomAvailabilityEntity.HotelId &&
                                 rooms.CheckInDate.ToShortDateString() == roomAvailabilityEntity.CheckIn.ToShortDateString() &&
                                 rooms.CheckOutDate.ToShortDateString() == roomAvailabilityEntity.CheckOut.ToShortDateString()
                                group rooms.Deluxe by new { rooms.CheckInDate, rooms.CheckOutDate }
                                into deluxeroomcount
                                select deluxeroomcount.Sum()
                                ).ToList();
            }
            catch (SqlException sqlException)
            {
                throw new SQLException(sqlException.Message);
            }
            RoomAvailabilityEntity _roomAvailabilityEntity = new RoomAvailabilityEntity()
            {
                NumberOfDeluxeRoom = totalrooms[0].DeluxeRoom,
                NumberOfPremiumRoom = totalrooms[0].PremiumRoom
            };
            if (resultDeluxe.Count != 0 && resultPremium.Count != 0)
            {
                _roomAvailabilityEntity.NumberOfDeluxeRoom = totalrooms[0].DeluxeRoom - resultDeluxe[0];
                _roomAvailabilityEntity.NumberOfPremiumRoom = totalrooms[0].PremiumRoom - resultPremium[0];
            }

            return _roomAvailabilityEntity;
        }

        public List<MyBookingsEntity> GetBookings(int UserID)
        {
            List<MyBookingsEntity> bookings;
            try
            {
                bookings = repositoryContext.Booking.
                    Where(booking => booking.UserId == UserID).
                    Select(booking => new MyBookingsEntity()
                    {
                        BookId = booking.BookId,
                        UserId = booking.UserId,
                        UserName = repositoryContext.UserProfiles.
                            Where(user => user.User_ID == UserID).
                            Select(user => user.User_FirstName).
                            FirstOrDefault(),
                        Premium = booking.Premium,
                        Deluxe = booking.Deluxe,
                        HotelID = booking.HotelID,
                        HotelName = booking._Hotel.Hotel_Name,
                        DateOfBilling = booking.DateOfBilling,
                        CheckInDate = booking.CheckInDate,
                        CheckOutDate = booking.CheckOutDate,
                        NumberOfAdults = booking.NumberOfAdults,
                        NumberOfChildren = booking.NumberOfChildren,
                        NumberOfInfants = booking.NumberOfInfants,
                        TotalCost = booking.TotalCost,
                        HotelPicture = repositoryContext.Pictures.
                            Where(pic => pic.HotelID == booking.HotelID).
                            Select(pic => pic.Picture).
                            FirstOrDefault(),
                    }).ToList();
            }
            catch (SqlException sqlException)
            {
                throw new SQLException("Error while retrieving particular hotel details" + sqlException);
            }
            catch (Exception e)
            {
                throw new SQLException("Exception occured while retrieving particular hotel details");
            }
            return bookings;
        }
    }
}
