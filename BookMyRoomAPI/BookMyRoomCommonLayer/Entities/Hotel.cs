using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class Hotel
    {
        [Key]
        public int HotelID { get; set; }
        [Required]
        public string Hotel_Name { get; set; }
        [Required]
        public string Hotel_Address { get; set; }
        [Required]
        [Phone]
        public string Hotel_PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Hotel_EmailID { get; set; }
        [Required]
        public string Hotel_Status { get; set; }
        [Required]
        public float Hotel_Rating { get; set; }
        [Required]
        public bool Wifi { get; set; }
        [Required]
        [ForeignKey("City")]
        public City CityID { get; set; }
        [Required]
        [ForeignKey("HotelManager")]
        public HotelManager HotelManagerID { get; set; }
        [Required]
        public bool Pool { get; set; }
        [Required]
        public bool Parking { get; set; }
        [Required]
        public bool Restaurant { get; set; }
        [ForeignKey("Airports")]
        public Airports AirportID { get; set; }
        public double AirportDistance { get; set; }
        [ForeignKey("RailwayStation")]
        public RailwayStation RailwayStationID { get; set; }
        public double RailwayDistance { get; set; }
        public int DeluxeRoom { get; set; }
        public int PremiumRoom { get; set; }

    }
}
