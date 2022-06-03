using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyRoomAPILayer.Models
{
    public class HotelManagerlogin
    {

        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string PhoneNo { get; set; }
        public string Current_Password { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Token { get; set; }
        public string UserType { get; set; }
        public string ReTypePassword { get; set; }
    }
}
