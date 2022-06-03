using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class HotelFeedback
    {
        [Key]
        public int FeedbackID { get; set; }
        public string Feedback { get; set; }
        [ForeignKey("_Hotel")]
        public int Hotel { get; set; }
        public double Rating { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public virtual Hotel _Hotel { get; set; }
    }
}
