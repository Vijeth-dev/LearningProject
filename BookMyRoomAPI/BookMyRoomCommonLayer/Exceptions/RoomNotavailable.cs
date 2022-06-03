using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Exceptions
{
    public class RoomNotavailable : Exception
    {
        public RoomNotavailable(string message) : base(message)
        {

        }
    }
}
