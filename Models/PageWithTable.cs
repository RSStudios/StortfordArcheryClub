using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace StortfordArchers.Models
{
    [PageType(Title = "Tabular", UseBlocks = false)]
    [BlockItemType(typeof(StortfordArchers.Blocks.ExcelBlock))]
    [BlockItemType(typeof(StortfordArchers.Blocks.CalendarBlock))]
    [BlockItemType( typeof(Piranha.Extend.Blocks.HtmlBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.SeparatorBlock))]
    [ContentTypeRoute(Title = "Default", Route = "/TabularPage")]

    public class PageWithTable : Page<PageWithTable>
    {

      
        public string TableData { get; set; }

        public string Message { get; set;}
    }
}
