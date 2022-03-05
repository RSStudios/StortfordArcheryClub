using System;

namespace StortfordArchers.Models
{
    public class CalendarItem
    {
        public int Id { get; set; }

        public string Theme { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }
        public string MapPostcode { get; set; }
    }
}
