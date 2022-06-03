using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class Search
    {
        
            public string City { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public int Infants { get; set; }
            public int Adults { get; set; }
            public int Children { get; set; }
        
    }
}
