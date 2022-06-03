using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyRoomAPILayer.Models
{
    public class HotelAndCityNameModel
    {
        [Required]
        public string CityName { get; set; }
        [Required]
        public string HotelName { get; set; }
    }
}
