using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BookMyRoomAPILayer.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
         [Required]
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Current_Password { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Token { get; set; }
        public string UserType { get; set; }
    }
}
