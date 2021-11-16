using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using Piranha.Extend.Fields;

[SiteType(Title = "SAC")]
public class SAC : SiteContent<SAC>
{
    [Region(Title = "Footer", Display = RegionDisplayMode.Setting)]
    public Footer FooterContents { get; set; }
}

public class Footer
{
    [Field(Title = "Footer logo")]
    public ImageField Logo { get; set; }

    [Field(Title = "Footer text")]
    public HtmlField Text { get; set; }


}