using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Exceptions
{
    public class GeneralException : Exception
    {
        public GeneralException(string message) : base(message)
        {

        }
    }
}
