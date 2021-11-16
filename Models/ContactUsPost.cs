using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace StortfordArchers.Models
{
    [PostType(Title = "Contact Us Post")]
    [ContentTypeRoute(Title = "Default", Route = "/contactuspost")]
    public class ContactUsPost : Post<ContactUsPost>
    {
        public class ContactUsRegion
        {
            [Field]
            public StringField Name { get; set; }
        }

        [Region]
        public ContactUsRegion ContactUs { get; set; }
    }
}
