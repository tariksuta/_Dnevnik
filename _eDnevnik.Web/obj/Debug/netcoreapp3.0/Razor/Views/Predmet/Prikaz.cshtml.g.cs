#pragma checksum "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1df5bfa757bae24c7659a731613f652b7e636aaf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Predmet_Prikaz), @"mvc.1.0.view", @"/Views/Predmet/Prikaz.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1df5bfa757bae24c7659a731613f652b7e636aaf", @"/Views/Predmet/Prikaz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38dd9705558a3aeb8e61ab533b6648fd75201f3", @"/Views/_ViewImports.cshtml")]
    public class Views_Predmet_Prikaz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_eDnevnik.Web.ViewModel.PredmetPrikazVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("navbar-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
  
    ViewData["Title"] = "Prikaz";
    string poruka = (string)TempData["greskaPoruka"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""sidebar"" data-color=""purple"" data-background-color=""white"" data-image=""/assets/img/sidebar-3.jpg"">
    <!--
        Tip 1: You can change the color of the sidebar using: data-color=""purple | azure | green | orange | danger""

        Tip 2: you can also add an image using data-image tag
    -->
    <div class=""logo "">
        <a href=""/Home/Index"" class=""simple-text logo-normal"">
            eDnevnik
        </a>
    </div>
    <div class=""sidebar-wrapper"">
        <ul class=""nav"">
            <li class=""nav-item"">
                <a class=""nav-link"" href=""/Home/Index"">
                    <i class=""material-icons"">dashboard</i>
                    <p>Početna</p>
                </a>
            </li>
            <li class=""nav-item  "">
                <a class=""nav-link"" href=""/Administrator/Prikaz"">
                    <!--Uvid u druge administratore-->
                    <i class=""material-icons"">person</i>
                    <p>Administratori</p>
                </");
            WriteLiteral(@"a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Login/Prikaz"">
                    <i class=""material-icons"">security</i>
                    <p>Login</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Profesor/Prikaz"">
                    <i class=""material-icons"">supervisor_account</i>
                    <p>Profesori</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Roditelj/Prikaz"">
                    <i class=""material-icons"">local_library</i>
                    <p>Roditelji</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Odjeljenje/Prikaz"">
                    <!--Unutra dodavanje u ucenika-->
                    <i class=""material-icons"">collections_bookmark</i>
                    <p>Odjeljenja</p>
                ");
            WriteLiteral(@"</a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Ucenik/Prikaz"">
                    <i class=""material-icons"">school</i>
                    <p>Učenici</p>
                </a>
            </li>
            <li class=""nav-item active"">
                <a class=""nav-link"" href=""/Predmet/Prikaz"">
                    <i class=""material-icons"">translate</i>
                    <p>Predmeti</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/SlusaPredmet/Prikaz"">
                    <i class=""material-icons"">input</i>
                    <p>Zaključne ocjene</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Predaje/Prikaz"">
                    <i class=""material-icons"">people</i>
                    <p>Predavači</p>
                </a>
            </li>

            <li class=""nav-item "">
         ");
            WriteLiteral(@"       <a class=""nav-link"" href=""/Smjer/Prikaz"">
                    <i class=""material-icons"">directions</i>
                    <p>Smjerovi</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Vladanje/Prikaz"">
                    <i class=""material-icons"">policy</i>
                    <p>Vladanja</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Sekcija/PrikazSekcija"">
                    <!--Unutra dodavanje-->
                    <i class=""material-icons"">color_lens</i>
                    <p>Sekcije</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/SkolskaGodina/Prikaz"">
                    <i class=""material-icons"">date_range</i>
                    <p>Školske godine</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""n");
            WriteLiteral(@"av-link"" href=""/RasporedKonsultacija/Prikaz"">
                    <i class=""material-icons"">event_available</i>
                    <p>Raspored konsultacija</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Sjednica/Prikaz"">
                    <i class=""material-icons"">update</i>
                    <p>Sjednice</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Zapisnik/Prikaz"">
                    <i class=""material-icons"">receipt</i>
                    <p>Zapisnici sa sjednica</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Opcina/Prikaz"">
                    <i class=""material-icons"">where_to_vote</i>
                    <p>Općine</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/Grad/Prikaz"">
      ");
            WriteLiteral(@"              <i class=""material-icons"">location_city</i>
                    <p>Gradovi</p>
                </a>
            </li>
            <li class=""nav-item"">
                <a class=""nav-link"" href=""/Drzava/Prikaz"">
                    <i class=""material-icons"">language</i>
                    <p>Države</p>
                </a>
            </li>
        </ul>
    </div>
</div>
<div class=""main-panel"">
    <!-- Navbar -->
    <nav class=""navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top "">
        <div class=""container-fluid"">
            <div class=""navbar-wrapper"">
                <a class=""navbar-brand"" href=""#pablo"">");
            WriteLiteral(@" </a><!--tu cemokorisnicko ime-->
            </div>


            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" aria-controls=""navigation-index"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                <span class=""sr-only"">Toggle navigation</span>
                <span class=""navbar-toggler-icon icon-bar""></span>
                <span class=""navbar-toggler-icon icon-bar""></span>
                <span class=""navbar-toggler-icon icon-bar""></span>
            </button><!--na smanjenom ekranu ikonica-->
            <!------------------------------------------------------------------------------------------>
            <div class=""collapse navbar-collapse justify-content-end"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1df5bfa757bae24c7659a731613f652b7e636aaf10854", async() => {
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <ul class=""navbar-nav"">
                    <li class=""nav-item dropdown"">
                        <a class=""nav-link"" href=""#pablo"" id=""navbarDropdownProfile"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            <i class=""material-icons"">person</i>
                            <p class=""d-lg-none d-md-block"">
                                Account
                            </p>
                        </a>
                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""navbarDropdownProfile"">
                            <a class=""dropdown-item"" href=""/Administrator/LicniPrikaz"">Profile</a>
                            <div class=""dropdown-divider""></div>
                            <a class=""dropdown-item"" href=""/Autentifikacija/Logout"">Log out</a>
                        </div>
                    </li>
                </ul><!-- ikonica u cosi za log out-->
            </div>
            <!------------------");
            WriteLiteral(@"------------------------------------------------------------------------>
        </div>
    </nav>

    <!-- End Navbar -->
    <div class=""content"">
        <div class=""container-fluid"">
            <!--body-->

            <div class=""row"">
                <!-- Izgled tabele -->
                <div class=""col-md-9"">
                    <div class=""card"">
                        <div class=""card-header card-header-primary"">
                            <h4 class=""card-title"">Predmeti</h4>
                            <p class=""card-category"">Prikaz</p>
                        </div>
                        <div class=""card-body table-responsive"">
                            <table class=""table table-hover"">
                                <thead class=""text-primary"">
                                    <!-- Izgled tabele -->
                                    <tr>
                                        <th>Naziv</th>
                                        <th>Oznaka</th>
          ");
            WriteLiteral("                              <th>Razred</th>\r\n                                        <th class=\"text-center\">Akcija</th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 213 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
                                     foreach (var x in @Model.ListaPredmeta)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 216 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
                                           Write(x.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                            <td>");
#nullable restore
#line 217 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
                                           Write(x.Oznaka);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                            <td>");
#nullable restore
#line 218 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
                                           Write(x.Razred);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                            <td class=\"text-center\">\r\n                                                <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 9575, "\"", 9617, 2);
            WriteAttributeValue("", 9582, "/Predmet/DodajUredi?PredmetID=", 9582, 30, true);
#nullable restore
#line 220 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
WriteAttributeValue("", 9612, x.ID, 9612, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Uredi</a>\r\n                                                <a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 9703, "\"", 9741, 2);
            WriteAttributeValue("", 9710, "/Predmet/Obrisi?PredmetID=", 9710, 26, true);
#nullable restore
#line 221 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
WriteAttributeValue("", 9736, x.ID, 9736, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Obriši</a>\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 224 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table><!-- Izgled tabele -->
                        </div>
                    </div>
                </div>
            </div><!-- Izgled tabele -->

            <a href=""/Predmet/DodajUredi"" class=""btn btn-success"">Dodaj</a>
");
#nullable restore
#line 233 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
             if (poruka != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <br />\r\n                <br />\r\n                <div class=\"col-md-6\">\r\n\r\n                    <div class=\"alert alert-light\">");
#nullable restore
#line 239 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
                                              Write(poruka);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </div>\r\n");
#nullable restore
#line 241 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\Predmet\Prikaz.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <!--body-->\r\n        </div>\r\n    </div>\r\n\r\n    <footer class=\"footer\">\r\n    </footer>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_eDnevnik.Web.ViewModel.PredmetPrikazVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
