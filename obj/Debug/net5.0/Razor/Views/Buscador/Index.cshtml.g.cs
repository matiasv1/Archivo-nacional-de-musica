#pragma checksum "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d85933dbec1a42b39a3dc102095f46999743e0d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Buscador_Index), @"mvc.1.0.view", @"/Views/Buscador/Index.cshtml")]
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
#line 1 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\_ViewImports.cshtml"
using AppV1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\_ViewImports.cshtml"
using AppV1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
using HtmlAgilityPack;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d85933dbec1a42b39a3dc102095f46999743e0d9", @"/Views/Buscador/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"044f14ecb40bc0d4f4a42870e1acff9bd61787e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Buscador_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dictionary<string,string>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
  
    ViewData["Title"] = "Resultados";

#line default
#line hidden
#nullable disable
            WriteLiteral("<section>\r\n\t<div class=\"shadow\">\r\n\t\t\r\n");
#nullable restore
#line 10 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
         if(Model is not null)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<h1 class=\"d-flex justify-content-center\">Resultados</h1>\r\n\t\t\t<br />\r\n\t\t\t<div class=\"m-4 p-3\">\r\n\t\t\t\t<h5>Se encontraron ");
#nullable restore
#line 15 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
                              Write(ViewBag.largo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" resultados</h5>
				<table>
					
					<thead  style=""background-color:#212529; color:white;"">
						<tr class=""p-2"">
							<th class=""p-2"">Id</th>
							<th class=""p-2"">Resultados</th>
							<th class=""p-2"">Acción</th>
						</tr>
						
					</thead>
					<tbody>	
");
#nullable restore
#line 27 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
                      
						var result = 1;
					

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
                     foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<td>");
#nullable restore
#line 31 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
                       Write(result);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<div class=\"shadow mt-4 mb-4 mx-4 p-3\">\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 35 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
                           Write(Html.Raw(item.Key));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t<!-- 1par = label, 2par = metodo, 3par parametros del metodo, 4par = css-->\r\n\t\t\t\t\t\t    ");
#nullable restore
#line 40 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
                       Write(Html.ActionLink("Guardar", "Guardar", new { s = @ViewBag.Peticion, url = @item.Value}, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n\t\t\t\t\t\t\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 44 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
								result += 1;
							}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</tbody>\r\n\t\t\t</table>\r\n\t\t\t</div>\r\n");
#nullable restore
#line 50 "C:\Users\SaaSan\Documents\ArchivosCompartidos\Programación\ASP.NET\AppV1\Views\Buscador\Index.cshtml"
			
				
			
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dictionary<string,string>> Html { get; private set; }
    }
}
#pragma warning restore 1591
