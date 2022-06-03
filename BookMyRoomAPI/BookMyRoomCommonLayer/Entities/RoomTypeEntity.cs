using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class RoomTypeEntity
    {
        [Key]
        public int RoomTypeid { get; set; }
        public string RoomType { get; set; }
    }
}
