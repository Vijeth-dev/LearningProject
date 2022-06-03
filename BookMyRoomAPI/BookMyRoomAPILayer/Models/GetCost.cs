using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyRoomAPILayer.Models
{
    public class GetCost
    {
        public int HotelId { get; set; }
        public int Budget { get; set; }
        public int Deluxe { get; set; }
    }
}
