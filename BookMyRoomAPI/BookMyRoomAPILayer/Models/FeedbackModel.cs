using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyRoomAPILayer.Models
{
    public class FeedbackModel
    {
        public int HotelID { get; set; }
        public string Title { get; set; }
        public string Nickname { get; set; }
        public float Rating { get; set; }
        public string Feedback { get; set; }
    }
}
