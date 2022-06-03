using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyRoomAPILayer.Models
{
    public class RoomCostModel
    {
        public int HotelId { get; set; }
        public double PremiumRoomCost { get; set; }
        public double DeluxeRoomCost { get; set; }
        public bool AC { get; set; }
        public bool Geyser { get; set; }
        public bool TV { get; set; }
        public bool WIFI { get; set; }
        public bool RoomService { get; set; }
    }
}
