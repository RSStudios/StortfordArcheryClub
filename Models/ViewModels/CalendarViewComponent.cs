using System;
using System.Collections.Generic;
using StortfordArchers.Blocks;

namespace StortfordArchers.Models.ViewModels
{
    public class CalendarViewComponent

    {
        public CalendarBlock Block { get; set; }

        public class CalendarDetails
        {
            public DateTime DateVal { get; set; }
            public List<CalendarItem> CalItem { get; set; }
        }

        public string MonthName { get; set; }
        public List<CalendarDetails> Calendar { get; set; }
    }
}
