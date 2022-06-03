using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyRoomCommonLayer.Entities
{
    [Table("UserProfiles")]
    public class UserProfiles
    {
        [Key]
        public int User_ID { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string User_FirstName { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string User_Lastname { get; set; }
        [Phone]
        public string User_PhoneNumber { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        [EmailAddress]
        public string User_EmailID { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string User_Password { get; set; }
        public string User_Type { get; set; }
    }
}
