#pragma checksum "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11a1b985eca0dfa06934bde6c3de118123a4d535"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Entity_Habitacion_Edit), @"mvc.1.0.view", @"/Views/Entity_Habitacion/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11a1b985eca0dfa06934bde6c3de118123a4d535", @"/Views/Entity_Habitacion/Edit.cshtml")]
    #nullable restore
    public class Views_Entity_Habitacion_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities_Hotel_5_Rosas.Entity_Habitacion>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>Entity_Habitacion</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""PK_Habitacion"" />
            <div class=""form-group"">
                <label asp-for=""FK_Tipo_Habitacion"" class=""control-label""></label>
                <input asp-for=""FK_Tipo_Habitacion"" class=""form-control"" />
                <span asp-validation-for=""FK_Tipo_Habitacion"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""FK_Hotel"" class=""control-label""></label>
                <input asp-for=""FK_Hotel"" class=""form-control"" />
                <span asp-validation-for=""FK_Hotel"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Numero_Habitacion"" class=""control-label""></label>
                <input asp-for=""Nume");
            WriteLiteral(@"ro_Habitacion"" class=""form-control"" />
                <span asp-validation-for=""Numero_Habitacion"" class=""text-danger""></span>
            </div>
            <div class=""form-group form-check"">
                <label class=""form-check-label"">
                    <input class=""form-check-input"" asp-for=""Estado"" /> ");
#nullable restore
#line 33 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Edit.cshtml"
                                                                   Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </label>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Habitacion\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
