using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class MyBookingsEntity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Premium { get; set; }
        public int Deluxe { get; set; }
        public int HotelID { get; set; }
        public string HotelName { get; set; }
        public DateTime DateOfBilling { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfInfants { get; set; }
        public double TotalCost { get; set; }
        public string HotelPicture { get; set; }
    }
}
