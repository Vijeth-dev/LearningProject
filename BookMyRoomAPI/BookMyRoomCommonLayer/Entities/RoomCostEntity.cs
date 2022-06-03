using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class RoomCostEntity
    {
        public int HotelId { get; set; }
        public double PremiumRoomCost { get; set; }
        public bool AC { get; set; }
        public bool Geyser { get; set; }
        public bool TV { get; set; }
        public bool WIFI { get; set; }
        public bool RoomService { get; set; }
        public double DeluxeRoomCost { get; set; }
    }
}
