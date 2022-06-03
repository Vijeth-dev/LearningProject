using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomCommonLayer.Entities
{
    public class ExceptionLog
    {
        public string ExceptionString { get; set; }
        public DateTime Exception_Date { get; set; }

        public ExceptionLog()
        {
            Exception_Date = new DateTime();
        }

    }
}
