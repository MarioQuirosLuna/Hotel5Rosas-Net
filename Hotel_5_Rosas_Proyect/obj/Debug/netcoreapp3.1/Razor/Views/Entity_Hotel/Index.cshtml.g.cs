#pragma checksum "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Hotel\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "478d096b905fe26fd686cdd762eb796e9c303531"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Entity_Hotel_Index), @"mvc.1.0.view", @"/Views/Entity_Hotel/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"478d096b905fe26fd686cdd762eb796e9c303531", @"/Views/Entity_Hotel/Index.cshtml")]
    #nullable restore
    public class Views_Entity_Hotel_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities_Hotel_5_Rosas.Entity_Hotel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Hotel\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Hotel\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 22 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Hotel\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 25 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Hotel\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 584, "\"", 613, 1);
#nullable restore
#line 28 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Hotel\Index.cshtml"
WriteAttributeValue("", 599, item.PK_Hotel, 599, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 666, "\"", 695, 1);
#nullable restore
#line 29 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Hotel\Index.cshtml"
WriteAttributeValue("", 681, item.PK_Hotel, 681, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 750, "\"", 779, 1);
#nullable restore
#line 30 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Hotel\Index.cshtml"
WriteAttributeValue("", 765, item.PK_Hotel, 765, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 33 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Hotel\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities_Hotel_5_Rosas.Entity_Hotel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
