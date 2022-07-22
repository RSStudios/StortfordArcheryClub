using StortfordArchers.Enumerations;

namespace StortfordArchers.Models.ViewModels
{
    public class PageWithEntryFormViewModel
    {
        public PageWithTableTypes PageWithTableTypes { get; set; }

        public string Html { get; set; }


        public Piranha.Extend.Block Block { get; set; }
    }
}
