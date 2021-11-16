using System.Collections.Generic;

namespace  StortfordArchers.Models
{
    public class CommitteeDetailsViewModel
    {
        public CommitteeDetailsPage CommitteeDetailsPage {get; set;}

        public IEnumerable<CommitteeDetailsItem> CommitteeDetails {get; set;}
    }
}