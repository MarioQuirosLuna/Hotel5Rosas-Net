#pragma checksum "C:\Users\pisab\Desktop\Hotel5Rosas\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Temporada\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8aab4456473f9af16c9de7c449d86e2a532e3b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Entity_Temporada_Details), @"mvc.1.0.view", @"/Views/Entity_Temporada/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8aab4456473f9af16c9de7c449d86e2a532e3b1", @"/Views/Entity_Temporada/Details.cshtml")]
    #nullable restore
    public class Views_Entity_Temporada_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities_Hotel_5_Rosas.Entity_Temporada>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pisab\Desktop\Hotel5Rosas\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Temporada\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Entity_Temporada</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\pisab\Desktop\Hotel5Rosas\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Temporada\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\pisab\Desktop\Hotel5Rosas\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Temporada\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\pisab\Desktop\Hotel5Rosas\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Temporada\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Fecha_Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\pisab\Desktop\Hotel5Rosas\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Temporada\Details.cshtml"
       Write(Html.DisplayFor(model => model.Fecha_Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\pisab\Desktop\Hotel5Rosas\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Temporada\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Fecha_Fin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\pisab\Desktop\Hotel5Rosas\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Temporada\Details.cshtml"
       Write(Html.DisplayFor(model => model.Fecha_Fin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 876, "\"", 910, 1);
#nullable restore
#line 34 "C:\Users\pisab\Desktop\Hotel5Rosas\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Temporada\Details.cshtml"
WriteAttributeValue("", 891, Model.PK_Temporada, 891, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities_Hotel_5_Rosas.Entity_Temporada> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
