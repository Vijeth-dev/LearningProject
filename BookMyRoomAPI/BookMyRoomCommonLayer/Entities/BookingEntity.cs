using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class BookingEntity
    {
        [Key]
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Premium { get; set; }
        public int Deluxe { get; set; }
        [ForeignKey("_Hotel")]
        public int HotelID { get; set; }
        public virtual Hotel _Hotel { get; set; }
        public DateTime DateOfBilling { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfInfants { get; set; }
        public double TotalCost { get; set; }
    }
}
