using Piranha.AttributeBuilder;
using Piranha.Extend;
using System.Collections.Generic;
using Piranha.Models;

namespace StortfordArchers.Models
{
    [PageType(Title = "The Committee", UseBlocks = false)]
    [ContentTypeRoute(Title = "Default", Route = "/quiver-committee")]

    public class CommitteeDetailsPage : Page<CommitteeDetailsPage>
    {
        [Region(Title = "The committee")]
       // [RegionDescription("committee member details")]
        //public CommitteeDetails CommitteeDetails {get; set;}
        public IList<CommitteeDetails> CommitteeDetails { get; set; } = new List<CommitteeDetails>();

    }
}