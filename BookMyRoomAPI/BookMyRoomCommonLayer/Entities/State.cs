using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        [Required]
        public string StateName { get; set; }
    }
}
