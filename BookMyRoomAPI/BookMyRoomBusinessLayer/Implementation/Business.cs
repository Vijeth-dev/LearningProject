using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomCommonLayer.Entities;
using BookMyRoomCommonLayer.Exceptions;
using BookMyRoomRepositoryLayer.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace BookMyRoomBusinessLayer.Implementation
{
    public class Business : IBusiness
    {
        IRepository repository;
        private string salt = "WQfVv2nO0sFmsTMsSHJo";
        public Business(IRepository _repository)
        {
            this.repository = _repository;
        }
        public bool AuthorizeGoogleUser(string token, UserProfiles userRegisterModel)
        {
            var result = JObject.Parse(new WebClient().DownloadString("https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=" + token));
            foreach (KeyValuePair<string, JToken> res in result)
            {
                if (res.Key == "email" && res.Value.ToString() == userRegisterModel.User_EmailID)
                {
                    userRegisterModel.User_Type = "Google";
                    userRegisterModel.User_PhoneNumber = "";
                    AddUserProfile(userRegisterModel);
                    return true;
                }
            }
            return false;
        }

        public bool AddUserProfile(UserProfiles userProfiles)
        {
            if (userProfiles.User_Password != "")
            {
                userProfiles.User_Password = hashPassword(userProfiles.User_Password);
            }
            try
            {
                return repository.AddUserProfile(userProfiles);
            }
            catch (SQLException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SearchResult> SearchHotel(string search)//search city  get the list of hotels with various featurs
        {
            List<SearchResult> searchResults;
            try
            {
                searchResults = repository.SearchCity(search);
            }
            catch (DataNotFound e)
            {
                throw;
            }
            catch (SQLException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return searchResults;
        }

        public Update_Password UpdateProfile(string id, Update_Password userProfile)
        {
            if (userProfile.Password != "")
            {
                userProfile.Current_Password = hashPassword(userProfile.Current_Password);
                userProfile.Password = hashPassword(userProfile.Password);
            }
            try
            {
                return repository.UpdateProfile(id, userProfile);
            }
            catch (IncorrectCurrentPassword)
            {
                throw;
            }
        }


        public bool AddHotelManager(HotelManager hotelManager)
        {
            return repository.AddHotelManager(hotelManager);
        }

        public bool AddUserFeedback(HotelFeedback hotelFeedback)
        {
            return repository.AddUserFeedback(hotelFeedback);
        }
        public bool AddHotel(SearchResult hotel, string city, string hotelManagerEmail)
        {
            try
            {
                return repository.AddHotel(hotel, city, hotelManagerEmail);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool UpdateHotel(SearchResult hotel)
        {
            try
            {
                return repository.UpdateHotel(hotel);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public dynamic AuthenticateUser(LogInDetails loginProfiles)
        {
            loginProfiles.Password = hashPassword(loginProfiles.Password);
            return repository.AuthenticateUser(loginProfiles);
        }

        public HotelManager HotelManagerLogIn(LogInDetails logInDetails)
        {
            try
            {
                return repository.HotelManagerLogIn(logInDetails);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        private string hashPassword(string password)
        {
            password += salt;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public List<HotelFetch> GetHotelManagers()
        {
            return repository.GetHotelManagers();
        }

        public List<Hotel> FetchHotels(int x)
        {
            return repository.FetchHotels(x);
        }


        public BookingEntity BookHotel(BookingEntity bookingEntity)
        {
            try
            {
                repository.BookHotel(bookingEntity);
            }
            catch (RoomNotavailable )
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
            

            return bookingEntity;
        }

        public void ChangeManagerStatus(int id, string status)
        {
            repository.ChangeManagerStatus(id, status);
        }

        public void ChangeHotelStatus(int id, string status)
        {
            repository.ChangeHotelStatus(id, status);
        }
        public SearchResult GetParticularHotel(SearchResult searchResult)
        {
            try
            {
                return repository.GetParticularHotel(searchResult);
            }
            catch (SQLException sqlException)
            {
                throw new SQLException(sqlException.Message);
            }
            catch (Exception exception)
            {
                throw new SQLException(exception.Message);
            }
        }

        public List<SearchResult> FetchHotelsForManagers(string hotelManagerEmail)
        {
            try
            {
                return repository.FetchHotelsForManager(hotelManagerEmail);
            }
            catch (SQLException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<RoomCostEntity> GetRoomCost(int hotelId)
        {
            try
            {
                return repository.GetRoomCost(hotelId);
            }
            catch (SQLException sqlException)
            {
                throw new SQLException(sqlException.Message);
            }
            catch (Exception exception)
            {
                throw new SQLException(exception.Message);
            }
        }

        public RoomAvailabilityEntity CheckRoomAvailability(RoomAvailabilityEntity roomAvailabilityEntity)
        {
            try
            {
                return repository.CheckRoomAvailability(roomAvailabilityEntity);
            }
            catch (SQLException sqlException)
            {
                throw new SQLException("Rooms not available");
            }
            catch (Exception e)
            {
                throw new SQLException("Rooms not available"+e);
            }
        }

        public List<MyBookingsEntity> GetBookings(int UserID)
        {
            return repository.GetBookings(UserID);
        }
    }
}

