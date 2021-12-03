using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;

namespace StortfordArchers.Models
{
    [PageType(Title = "Standard page")]
    [BlockItemType(typeof(StortfordArchers.Blocks.TextWithImageBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.HtmlBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.ImageBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.ImageGalleryBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.QuoteBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.SeparatorBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.VideoBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.TextBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.HtmlColumnBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.ColumnBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.ImageAspect))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.PageBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.PostBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.ColumnBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.MarkdownBlock))]
    [BlockItemType(typeof(Piranha.Extend.Blocks.AudioBlock))]
    public class StandardPage  : Page<StandardPage>
    {
    }
}