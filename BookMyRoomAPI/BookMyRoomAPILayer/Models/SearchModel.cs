using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyRoomAPILayer.Models
{
    public class SearchModel
    {
        public string City { get; set; }
        public string State { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Adult { get; set; }
        public int Children { get; set; }
        public int  Infants { get; set; }
    }
}
