#pragma checksum "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Imagen\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71e43b237507e7b6d10e8044f08c9e5a4506d218"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Entity_Imagen_Create), @"mvc.1.0.view", @"/Views/Entity_Imagen/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71e43b237507e7b6d10e8044f08c9e5a4506d218", @"/Views/Entity_Imagen/Create.cshtml")]
    #nullable restore
    public class Views_Entity_Imagen_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities_Hotel_5_Rosas.Entity_Imagen>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Imagen\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>Entity_Imagen</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Imagen"" class=""control-label""></label>
                <input asp-for=""Imagen"" class=""form-control"" />
                <span asp-validation-for=""Imagen"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""FK_Galeria"" class=""control-label""></label>
                <input asp-for=""FK_Galeria"" class=""form-control"" />
                <span asp-validation-for=""FK_Galeria"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
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
#line 37 "C:\Users\pisab\Desktop\Universidad\Cursos\Ingeniería de software\Hotel5Rosas-Net\Hotel_5_Rosas_Proyect\Views\Entity_Imagen\Create.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities_Hotel_5_Rosas.Entity_Imagen> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
