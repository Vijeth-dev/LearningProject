using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Exceptions
{
    public class IncorrectCurrentPassword : Exception
    {
        public IncorrectCurrentPassword(string message) : base(message)
        {

        }
    }
}
