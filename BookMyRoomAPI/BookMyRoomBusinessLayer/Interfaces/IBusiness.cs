using BookMyRoomCommonLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomBusinessLayer.Interfaces
{
    public interface IBusiness
    {
        bool AddUserProfile(UserProfiles userProfiles);
        List<SearchResult> SearchHotel(string search);
        Update_Password UpdateProfile(string id, Update_Password userProfile);
        bool AddHotelManager(HotelManager hotelManager);
        bool AddUserFeedback(HotelFeedback hotelFeedback);
        dynamic AuthenticateUser(LogInDetails loginProfiles);
        HotelManager HotelManagerLogIn(LogInDetails logInDetails);
        List<HotelFetch> GetHotelManagers();
        List<Hotel> FetchHotels(int x);
        List<SearchResult> FetchHotelsForManagers(string hotelManagerEmail);
        bool AuthorizeGoogleUser(string token, UserProfiles email);
        BookingEntity BookHotel(BookingEntity bookingEntity);
        void ChangeManagerStatus(int id, string status);
        void ChangeHotelStatus(int id, string status);
        SearchResult GetParticularHotel(SearchResult searchResult);
        bool AddHotel(SearchResult hotel, string city, string hotelManagerName);
        List<RoomCostEntity> GetRoomCost(int id);
        RoomAvailabilityEntity CheckRoomAvailability(RoomAvailabilityEntity hotelId);
        List<MyBookingsEntity> GetBookings(int UserID);
        bool UpdateHotel(SearchResult hotel);
    }
}
