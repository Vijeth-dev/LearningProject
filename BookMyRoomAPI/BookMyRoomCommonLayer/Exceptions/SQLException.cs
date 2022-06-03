using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Exceptions
{
    public class SQLException : Exception
    {
        public SQLException(string message) : base(message)
        {

        }
    }
}
