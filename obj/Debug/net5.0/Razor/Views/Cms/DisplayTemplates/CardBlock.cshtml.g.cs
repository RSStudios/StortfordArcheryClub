#pragma checksum "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\CardBlock.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f34e02b2fea6e07a7abbbc6140b3b397fdaca65d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_DisplayTemplates_CardBlock), @"mvc.1.0.view", @"/Views/Cms/DisplayTemplates/CardBlock.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f34e02b2fea6e07a7abbbc6140b3b397fdaca65d", @"/Views/Cms/DisplayTemplates/CardBlock.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a4eb6421d7322b6890f0c89df497e796aa1663d", @"/Views/_ViewImports.cshtml")]
    public class Views_Cms_DisplayTemplates_CardBlock : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StortfordArchers.Blocks.CardBlock>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-4\">\r\n");
#nullable restore
#line 5 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\CardBlock.cshtml"
         if (Model.ImgBody.HasValue)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div style=\"width: 100px;\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 198, "\"", 231, 1);
#nullable restore
#line 8 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\CardBlock.cshtml"
WriteAttributeValue("", 204, Url.Content(Model.ImgBody), 204, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n");
#nullable restore
#line 10 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\CardBlock.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"col-8\">\r\n        ");
#nullable restore
#line 14 "D:\Projects\StortfordArchers\Views\Cms\DisplayTemplates\CardBlock.cshtml"
   Write(Html.Raw(Model.HtmlBody));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StortfordArchers.Blocks.CardBlock> Html { get; private set; }
    }
}
#pragma warning restore 1591
