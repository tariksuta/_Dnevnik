#pragma checksum "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "966d8236354c2f724ad99a5d980a808ca2493572"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cas_Prikaz), @"mvc.1.0.view", @"/Views/Cas/Prikaz.cshtml")]
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
#line 1 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\_ViewImports.cshtml"
using _eDnevnik.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\_ViewImports.cshtml"
using _eDnevnik.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"966d8236354c2f724ad99a5d980a808ca2493572", @"/Views/Cas/Prikaz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38dd9705558a3aeb8e61ab533b6648fd75201f3", @"/Views/_ViewImports.cshtml")]
    public class Views_Cas_Prikaz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_eDnevnik.Web.ViewModel.CasPrikazVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
  
    ViewData["Title"] = "Prikaz";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table"">
    <thead>
        <tr>
            <th>Broj casa</th>
            <th>Nastavna jedinica</th>
            <th>Datum održavanja</th>
            <th>Predmet</th>
            <th>Odjeljenje</th>
            <th>Profesor</th>
            <th colspan=""2"">Akcija</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
         foreach (var x in Model.casovi)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
           Write(x.BrojCasa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 23 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
           Write(x.NastavnaJedinica);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
           Write(x.DatumOdrzavanja);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
           Write(x.Predmet);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
           Write(x.Odjeljenje);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
           Write(x.Profesor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 749, "\"", 786, 2);
            WriteAttributeValue("", 756, "/Cas/DodajUredi?CasID=", 756, 22, true);
#nullable restore
#line 29 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
WriteAttributeValue("", 778, x.CasID, 778, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Uredi</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 817, "\"", 850, 2);
            WriteAttributeValue("", 824, "/Cas/Obrisi?CasID=", 824, 18, true);
#nullable restore
#line 30 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
WriteAttributeValue("", 842, x.CasID, 842, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Obrisi</a>\r\n\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 34 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Cas\Prikaz.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<a href=\"/Cas/DodajUredi\" class=\"btn btn-secondary\">Dodaj</a>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_eDnevnik.Web.ViewModel.CasPrikazVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
