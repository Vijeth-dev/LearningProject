using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class Pictures
    {
        [Key]

        public int PicturesID { get; set; }
        public int HotelID { get; set; }
        public Hotel Hotels { get; set; }
        
        public string Picture { get; set; }
    }
}
