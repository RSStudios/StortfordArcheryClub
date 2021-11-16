using Piranha.AttributeBuilder;
using Piranha.Models;

namespace StortfordArchers.Models
{
    [PageType(Title = "Quiver", UseBlocks = false)]
    [ContentTypeRoute(Title = "Default", Route = "/quiver")]
    public class QuiverPage : Page<QuiverPage>
    {

    }
}