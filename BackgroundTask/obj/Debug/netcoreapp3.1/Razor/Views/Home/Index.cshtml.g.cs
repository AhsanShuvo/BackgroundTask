#pragma checksum "C:\Users\tomal\source\repos\BackgroundTask\BackgroundTask\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7bdc3abd25d6fdf744f1ddb769ec2605dd5e9b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\tomal\source\repos\BackgroundTask\BackgroundTask\Views\_ViewImports.cshtml"
using BackgroundTask;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tomal\source\repos\BackgroundTask\BackgroundTask\Views\_ViewImports.cshtml"
using BackgroundTask.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7bdc3abd25d6fdf744f1ddb769ec2605dd5e9b4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b6dc7bfd8a36d1d1008f45d2137ca9fda1777fe", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\tomal\source\repos\BackgroundTask\BackgroundTask\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n</div>\r\n\r\n<div>\r\n    <input type=\"button\" class=\"btn btn-primary\" value=\"Start Processing\" id=\"processing-btn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 224, "\"", 287, 3);
            WriteAttributeValue("", 234, "location.href=\'", 234, 15, true);
#nullable restore
#line 10 "C:\Users\tomal\source\repos\BackgroundTask\BackgroundTask\Views\Home\Index.cshtml"
WriteAttributeValue("", 249, Url.Action("StartUploading", "Home"), 249, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 286, "\'", 286, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n</div>\r\n<script type=\"text/javascript\">\r\n    $(function () {\r\n        $(\"#processing-btn\").click(function () {\r\n            $(this).prop(\"disabled\", true);\r\n        });\r\n    });\r\n\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
