using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class SearchResult
    {
        public int Hotel_Id { get; set; }
        public string Hotel_Name { get; set; }
        public string Hotel_Email { get; set; }
        public string Hotel_Phone { get; set; }
        public string Hotel_Address { get; set; }
        public float Hotel_Rating { get; set; }
        public string Hotel_Status { get; set; }
        
        public bool Parking { get; set; }
        public bool Wifi { get; set; }
        public bool Pool { get; set; }
        public bool Restaurant { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string AirportName { get; set; }
        public string RailwayStationName { get; set; }
        public double AirportDistance { get; set; }
        public double RailwayDistance { get; set; }
        public int BudgetRoomCount { get; set; }
        public double BudgetRoomPrice { get; set; }
        public int DeluxeRoomCount { get; set; }
        public double DeluxeRoomPrice { get; set; }
        public List<string> Pictures { get; set; }
        public List<HotelFeedback> FeedBacks { get; set; }
    }
}
