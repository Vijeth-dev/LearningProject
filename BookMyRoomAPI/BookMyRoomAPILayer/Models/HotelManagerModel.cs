using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyRoomAPILayer.Models
{
    public class HotelManagerModel
    {
        [Key]
        public int HotelManager_ID { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string HotelManager_Name { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        [Phone]
        public string HotelManager_PhoneNumber { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        [EmailAddress]
        public string _EmailID { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string _Password { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string _Designation { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string _Status { get; set; }
        public string Token { get; set; }
    }
}
