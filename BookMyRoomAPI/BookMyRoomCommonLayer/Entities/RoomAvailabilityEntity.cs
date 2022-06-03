using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class RoomAvailabilityEntity
    {
        public int HotelId { get; set; }
        public int NumberOfPremiumRoom { get; set; }
        public int NumberOfDeluxeRoom { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
