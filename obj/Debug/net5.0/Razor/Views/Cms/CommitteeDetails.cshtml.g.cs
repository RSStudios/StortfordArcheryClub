#pragma checksum "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd26180a2bbb8c40c05df46036a9707b87dbc527"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_CommitteeDetails), @"mvc.1.0.view", @"/Views/Cms/CommitteeDetails.cshtml")]
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
#line 1 "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml"
using StortfordArchers.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd26180a2bbb8c40c05df46036a9707b87dbc527", @"/Views/Cms/CommitteeDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a4eb6421d7322b6890f0c89df497e796aa1663d", @"/Views/_ViewImports.cshtml")]
    public class Views_Cms_CommitteeDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CommitteeDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml"
  
    ViewBag.Title = Model.CommitteeDetailsPage.Title;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row justify-content-center\">\r\n        <div class=\"col-sm-10\">\r\n            <h1 class=\"display-3\">");
#nullable restore
#line 10 "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml"
                             Write(Model.CommitteeDetailsPage.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 14 "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml"
         foreach (CommitteeDetailsItem c in Model.CommitteeDetails)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-sm-8\">\r\n                <a class=\"card-link\"");
            BeginWriteAttribute("hreef", " hreef=\"", 511, "\"", 529, 1);
#nullable restore
#line 17 "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml"
WriteAttributeValue("", 519, c.PageUrl, 519, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"card border-dark\">\r\n                        <div class=\"card-body\">\r\n                            <div class=\"text-info\">");
#nullable restore
#line 20 "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml"
                                              Write(c.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"text-info\">");
#nullable restore
#line 21 "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml"
                                              Write(c.MemberName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"text-info\">");
#nullable restore
#line 22 "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml"
                                              Write(c.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n                </a>\r\n            </div>\r\n");
#nullable restore
#line 27 "D:\Projects\StortfordArchers\Views\Cms\CommitteeDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CommitteeDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
