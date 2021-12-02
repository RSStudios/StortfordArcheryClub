using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace StortfordArchers.Models
{
    [PageType(Title = "Tabular", UseBlocks = false)]
    [BlockItemType(typeof(Piranha.Extend.Blocks.HtmlBlock))]
    [ContentTypeRoute(Title = "Default", Route = "/TabularPage")]

    public class PageWithTable : Page<PageWithTable>
    {

        public HtmlField HtmlBody { get; set; }

        // excel file
        public string uploadedFile { get; set; }

        public string TableData { get; set; }
    }
}
