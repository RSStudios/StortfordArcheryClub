using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Extend.Fields;
namespace StortfordArchers.Blocks
{
    [BlockType(Name = "Text with file", Category = "Content", Icon = "fas fa-address-card", Component = "textwithfile-block")]
    public class TextWithFileBlock :Block
    {

        public HtmlField HtmlBody { get; set; }
    }
}
