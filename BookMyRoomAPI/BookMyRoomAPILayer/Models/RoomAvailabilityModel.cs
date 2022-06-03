using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyRoomAPILayer.Models
{
    public class RoomAvailabilityModel
    {
        public int HotelId { get; set; }
        public int NumberOfPremiumRoom { get; set; }
        public int NumberOfDeluxeRoom { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
    }
}
