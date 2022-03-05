using StortfordArchers.Models.Calendar;
using System.Collections.Generic;

namespace StortfordArchers.Models.ViewModels
{
    public class CalendarViewModel
    {
        public List<CalendarDetails> CalendarDetails { get; set; }
        public string MonthName { get; set; }
    }
}
