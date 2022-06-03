using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyRoomAPILayer.Models
{
    public class HotelModel
    {
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelContact { get; set; }
        public string HotelEmailID { get; set; }
        public bool Wifi { get; set; }
        public bool Parking { get; set; }
        public bool Restaurant { get; set; }
        public bool Pool { get; set; }
        public int Rating { get; set; }
        public string City { get; set; }
        public string AirportDistance { get; set; }
        public string RailwayDistance { get; set; }
        public int BudgetRoomCount { get; set; }
        public double BudgetRoomPrice { get; set; }
        public int DeluxeRoomCount { get; set; }
        public double DeluxeRoomPrice { get; set; }
        public List<string> Images { get; set; }
    }
}
