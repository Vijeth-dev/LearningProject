using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class RoomEntity
    {
        [Key]
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public bool AC { get; set; }
        public bool RoomService { get; set; }
        public bool WIFI { get; set; }
        public bool TV { get; set; }
        public bool Geyser { get; set; }
        public double Cost { get; set; }
        [ForeignKey("_HotelId")]
        public int HotelId { get; set; }
        public virtual Hotel _HotelId { get; set; }
        

    }
}
