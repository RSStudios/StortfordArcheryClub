using Piranha.Extend;
using Piranha.Extend.Fields;

namespace StortfordArchers.Blocks
{
    [BlockType(Name = "Upcoming Events", Category = "Content", Icon = "fas fa-address-card", Component = "upcomingevents-block")]
    public class UpcomingEventsBlock: Block
    {
        public HtmlField HtmlBody { get; set; }

    }
}
