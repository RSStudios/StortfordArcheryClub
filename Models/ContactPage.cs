using Piranha.AttributeBuilder;
using Piranha.Models;

namespace StortfordArchers.Models
{
    [PageType(Title = "Contact Page", UseBlocks = false)]
    [ContentTypeRoute(Title = "Default", Route = "/Contact")]

    public class ContactPage : Page<ContactPage>
    {
        // [BindProperty]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public string Response { get; set; }
    }
}