#pragma checksum "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e68de48cbf7c38d212d59ecb87aa7ee9aca1a92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Entity_TipoHabitacion_Index), @"mvc.1.0.view", @"/Views/Entity_TipoHabitacion/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e68de48cbf7c38d212d59ecb87aa7ee9aca1a92", @"/Views/Entity_TipoHabitacion/Index.cshtml")]
    #nullable restore
    public class Views_Entity_TipoHabitacion_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities_Hotel_5_Rosas.Entity_TipoHabitacion>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Tarifa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Tarifa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 993, "\"", 1032, 1);
#nullable restore
#line 40 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
WriteAttributeValue("", 1008, item.PK_Tipo_Habitacion, 1008, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1085, "\"", 1124, 1);
#nullable restore
#line 41 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
WriteAttributeValue("", 1100, item.PK_Tipo_Habitacion, 1100, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1179, "\"", 1218, 1);
#nullable restore
#line 42 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
WriteAttributeValue("", 1194, item.PK_Tipo_Habitacion, 1194, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\josep\Desktop\Universidad\Ingenieria de software\Proyecto\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_TipoHabitacion\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities_Hotel_5_Rosas.Entity_TipoHabitacion>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
