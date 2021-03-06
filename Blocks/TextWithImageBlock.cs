using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Extend.Fields;

namespace StortfordArchers.Blocks
{
    //[BlockType(Name = "Card", Category = "Content", Icon = "fas fa-address-card", Component = "card-block")]
    //public class CardBlock : Block

    [BlockType(Name = "Text with image", Category = "Content", Icon = "fas fa-address-card", Component = "textwithimage-block")]
    public class TextWithImageBlock : Block
    {
        public ImageField ImgBody { get; set; }
        public SelectField<ImageAspect> Aspect { get; set; } = new SelectField<ImageAspect>();

        public HtmlField HtmlBody { get; set; }

      //  public ContentBlock TextBody { get; set; }

        public override string GetTitle()
        {
            if (ImgBody != null && ImgBody.Media != null)
            {
                return ImgBody.Media.Filename;
            }
            return "No image selected";
        }
    }
}
