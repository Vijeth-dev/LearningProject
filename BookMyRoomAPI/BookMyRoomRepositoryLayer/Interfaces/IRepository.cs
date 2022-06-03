using BookMyRoomCommonLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomRepositoryLayer.Interfaces
{
    public interface IRepository
    {
        bool AddUserProfile(UserProfiles userProfiles);
        bool AddHotelManager(HotelManager hotelManager);
        List<SearchResult> SearchCity(string search);
        Update_Password UpdateProfile(string id, Update_Password userProfile);
        List<HotelFeedback> GetHotelFeedbacks(Hotel hotel);
        bool AddUserFeedback(HotelFeedback hotelFeedback);
        dynamic AuthenticateUser(LogInDetails userProfiles);
        HotelManager HotelManagerLogIn(LogInDetails logInDetails);
        List<HotelFetch> GetHotelManagers();
        List<Hotel> FetchHotels(int x);
        List<SearchResult> FetchHotelsForManager(string hotelManagerEmail);
        BookingEntity BookHotel(BookingEntity bookingEntity);
        void ChangeManagerStatus(int id, string status);
        void ChangeHotelStatus(int id, string status);
        SearchResult GetParticularHotel(SearchResult searchResult);
        bool AddHotel(SearchResult hotel, string city,string hotelManagerName);
        List<RoomCostEntity> GetRoomCost(int id);
        RoomAvailabilityEntity CheckRoomAvailability(RoomAvailabilityEntity roomAvailabilityEntity);
        List<MyBookingsEntity> GetBookings(int UserID);
        bool UpdateHotel(SearchResult hotel);
    }
}
