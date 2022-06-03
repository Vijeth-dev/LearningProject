using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Exceptions
{
    public class WrongUser : Exception
    {
        public WrongUser(string message) : base(message)
        {

        }
    }
}
