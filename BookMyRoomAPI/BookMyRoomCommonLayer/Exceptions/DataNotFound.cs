using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Exceptions
{
    public class DataNotFound:Exception
    {
        public DataNotFound(string message) : base(message)
        {

        }
    }
}
