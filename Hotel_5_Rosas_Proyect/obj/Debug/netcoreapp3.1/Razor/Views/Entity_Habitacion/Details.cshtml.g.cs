#pragma checksum "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "967fbe9ffce9adab0f14846d080261261392c98a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Entity_Habitacion_Details), @"mvc.1.0.view", @"/Views/Entity_Habitacion/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"967fbe9ffce9adab0f14846d080261261392c98a", @"/Views/Entity_Habitacion/Details.cshtml")]
    #nullable restore
    public class Views_Entity_Habitacion_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities_Hotel_5_Rosas.Entity_Habitacion>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Entity_Habitacion</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FK_Tipo_Habitacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
       Write(Html.DisplayFor(model => model.FK_Tipo_Habitacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FK_Hotel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
       Write(Html.DisplayFor(model => model.FK_Hotel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Numero_Habitacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
       Write(Html.DisplayFor(model => model.Numero_Habitacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
       Write(Html.DisplayFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1117, "\"", 1152, 1);
#nullable restore
#line 40 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Details.cshtml"
WriteAttributeValue("", 1132, Model.PK_Habitacion, 1132, 20, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities_Hotel_5_Rosas.Entity_Habitacion> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
