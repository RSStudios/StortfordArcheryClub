using Piranha.Extend;
using Piranha.Extend.Fields;

namespace StortfordArchers.Blocks
{
    [BlockType(Name = "Upcoming Events", Category = "Media", Icon = "fas fa-address-card", Component = "upcomingevents-block")]
    public class UpcomingEventsBlock: Block
    {
        [Field(Placeholder = "Select an Excel format calendar file to  upload")]

        public DocumentField Upload { get; set; }


        public override string GetTitle()
        {
            if (Upload != null && Upload.Media != null)
            {
                return Upload.Media.Filename;
            }
            return "No file selected";
        }

    }
}
