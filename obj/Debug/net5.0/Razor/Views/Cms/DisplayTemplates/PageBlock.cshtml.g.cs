#pragma checksum "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "222a47fb8de3b1efc1ae612c4e11f41b7740eae5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_DisplayTemplates_PageBlock), @"mvc.1.0.view", @"/Views/Cms/DisplayTemplates/PageBlock.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projects\StortfordArchers\Views\_ViewImports.cshtml"
using Piranha.AspNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\StortfordArchers\Views\_ViewImports.cshtml"
using StortfordArchers.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"222a47fb8de3b1efc1ae612c4e11f41b7740eae5", @"/Views/Cms/DisplayTemplates/PageBlock.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a4eb6421d7322b6890f0c89df497e796aa1663d", @"/Views/_ViewImports.cshtml")]
    public class Views_Cms_DisplayTemplates_PageBlock : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Piranha.Extend.Blocks.PageBlock>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml"
 if (Model.Body.Page != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\n");
#nullable restore
#line 6 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml"
         if (Model.Body.Page.PrimaryImage.HasValue)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 171, "\"", 196, 1);
#nullable restore
#line 8 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml"
WriteAttributeValue("", 178, WebApp.Url(Model), 178, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 240, "\"", 324, 1);
#nullable restore
#line 9 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml"
WriteAttributeValue("", 246, Url.Content(WebApp.Media.ResizeImage(Model.Body.Page.PrimaryImage, 540, 200)), 246, 78, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            </a>\n");
#nullable restore
#line 11 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card-body\">\n            <h5>");
#nullable restore
#line 13 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml"
           Write(Model.Body.Page.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n            <p>");
#nullable restore
#line 14 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml"
          Write(Html.Raw(Model.Body.Page.Excerpt));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            <a");
            BeginWriteAttribute("href", " href=\"", 498, "\"", 523, 1);
#nullable restore
#line 15 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml"
WriteAttributeValue("", 505, WebApp.Url(Model), 505, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-primary\">Read more</a>\n        </div>\n    </div>\n");
#nullable restore
#line 18 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\PageBlock.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Authorization.IAuthorizationService Auth { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Piranha.AspNetCore.Services.IApplicationService WebApp { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Piranha.Extend.Blocks.PageBlock> Html { get; private set; }
    }
}
#pragma warning restore 1591
