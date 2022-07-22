
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using StortfordArchers.Enumerations;
using System.Collections.Generic;

namespace StortfordArchers.Models
{
    [PageType(Title = "Entry Form", UseBlocks = false)]
    [ContentTypeRoute(Title = "Default", Route = "/EntryForm")]
    [BlockItemType(typeof(Piranha.Extend.Blocks.HtmlBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.SeparatorBlock))]
    public class EntryForm :Page<EntryForm>
    {
        public string ClubName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        public string Postcode { get; set; }

        // entrant details
       
        public List<EntryItems> EntryItems { get; set; }
        public string Response { get; set; }
    }
}
