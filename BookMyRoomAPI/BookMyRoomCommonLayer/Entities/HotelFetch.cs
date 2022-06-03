using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class HotelFetch
    {
        public int HotelManager_ID { get; set; }
        public string HotelManager_Name { get; set; }
        public string HotelManager_PhoneNumber { get; set; }
        public string _EmailID { get; set; }
        public string _Password { get; set; }
        public string _Designation { get; set; }
        public string _Status { get; set; }
        public int Count_Hotel { get; set; }
    }
}
