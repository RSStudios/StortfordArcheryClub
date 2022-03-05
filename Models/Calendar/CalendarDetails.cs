using System;
using System.Collections.Generic;

namespace StortfordArchers.Models.Calendar
{
    public class CalendarDetails
    {
        public DateTime DateVal { get; set; }
        public List<CalendarItem> CalItem { get; set; }
    }
}
