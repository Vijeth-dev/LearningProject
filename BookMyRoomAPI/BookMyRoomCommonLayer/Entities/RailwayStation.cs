using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyRoomCommonLayer.Entities
{
    public class RailwayStation
    {
        [Key]
        public int RailwayStationID { get; set; }
        [Required]
        public string RailwayStationName { get; set; }
       
        [Required]
        public int CityID { get; set; }
        public City City { get; set; }
    }
}
