using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        [Required]
        public string CityName { get; set; }
        
        [Required]
        //public int StateID { get; set; }
        public State StateID { get; set; }
    }
}
