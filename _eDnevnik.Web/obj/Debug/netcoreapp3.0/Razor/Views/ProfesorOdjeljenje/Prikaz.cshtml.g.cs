#pragma checksum "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92167aa024f6e914658a3993fb80815e4bb2a515"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProfesorOdjeljenje_Prikaz), @"mvc.1.0.view", @"/Views/ProfesorOdjeljenje/Prikaz.cshtml")]
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
#nullable restore
#line 2 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
using _eDnevnik.Web.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
using _eDnevnik.Data.EntityModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
using _eDnevnik.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
using Microsoft.Extensions.DependencyInjection;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92167aa024f6e914658a3993fb80815e4bb2a515", @"/Views/ProfesorOdjeljenje/Prikaz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38dd9705558a3aeb8e61ab533b6648fd75201f3", @"/Views/_ViewImports.cshtml")]
    public class Views_ProfesorOdjeljenje_Prikaz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_eDnevnik.Web.ViewModel.PrikazOdjeljenjaVM>
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
#nullable restore
#line 7 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
  
    ViewData["Title"] = "PrikazOdjeljenja";
    Login login = Context.GetLogiraniKorisnik();
    MyDbContext _context = Context.RequestServices.GetService<MyDbContext>();

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
            <li class=""nav-item  "">
                <a class=""nav-link"" href=""/Home/Index"">
                    <i class=""material-icons"">dashboard</i>
                    <p>Početna</p>
                </a>
            </li>
");
#nullable restore
#line 34 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
             if (_context.Odjeljenje.Where(x => x.RazrednikID == _context.Profesor.Where(p => p.LoginID == login.ID).FirstOrDefault().ID).FirstOrDefault() != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <li class=""nav-item  "">
                    <a class=""nav-link"" href=""/Razrednik/Index"">
                        <i class=""material-icons"">
                            how_to_reg
                        </i>
                        <p>Razrednik</p>
                    </a>
                </li>
");
#nullable restore
#line 44 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <li class=""nav-item "">
                <a class=""nav-link"" href=""/ProfesorSekcija/Prikaz"">
                    <i class=""material-icons"">color_lens</i>
                    <p>Sekcija</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/ProfesorCas/Prikaz"">
                    <i class=""material-icons"">alarm_on</i>
                    <p>Cas</p>
                </a>
            </li>
            <li class=""nav-item active"">
                <a class=""nav-link"" href=""/ProfesorOdjeljenje/Prikaz"">
                    <i class=""material-icons"">collections_bookmark</i>
                    <p>Odjeljenje</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/ProfesorProfesor/PrikaziSveProfesore"">
                    <i class=""material-icons"">supervisor_account</i>
                    <p>Profesori</p>
                </a>
            </li>
            ");
            WriteLiteral(@"<li class=""nav-item "">
                <a class=""nav-link"" href=""/ProfesorRasporedKonsultacija/Prikaz"">
                    <i class=""material-icons"">event_available</i>
                    <p>Raspored konsultacija</p>
                </a>
            </li>

            <li class=""nav-item "">
                <a class=""nav-link"" href=""/ProfesorOcjena/Prikaz"">
                    <i class=""material-icons"">edit</i>
                    <p>Ocjene</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/ProfesorIzostanak/Prikaz"">
                    <i class=""material-icons"">event_busy</i>
                    <p>Izostanci</p>
                </a>
            </li>
            <li class=""nav-item "">
                <a class=""nav-link"" href=""/ProfesorZapisnik/Prikaz"">
                    <i class=""material-icons"">receipt</i>
                    <p>Zapisnici</p>
                </a>
            </li>
            <li class=""nav-ite");
            WriteLiteral(@"m "">
                <a class=""nav-link"" href=""/ProfesorSjednica/Prikaz"">
                    <i class=""material-icons"">update</i>
                    <p>Sjednica</p>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "92167aa024f6e914658a3993fb80815e4bb2a51510288", async() => {
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
                            <a class=""dropdown-item"" href=""/ProfesorProfesor/Info"">Profile</a>
                            <div class=""dropdown-divider""></div>
                            <a class=""dropdown-item"" href=""/Autentifikacija/Logout"">Log out</a>
                        </div>
                    </li>
                </ul><!-- ikonica u cosi za log out-->
            </div>
            <!----------------------");
            WriteLiteral(@"-------------------------------------------------------------------->
        </div>
    </nav>

    <!-- End Navbar -->
    <div class=""content"">
        <div class=""container-fluid"">
            <!--body-->

            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""card"">
                        <div class=""card-header card-header-primary"">
                            <h4 class=""card-title"">Odjeljenja</h4>
                            <p class=""card-category"">Opći podaci</p>
                        </div>
                        <div class=""card-body table-responsive"">
                            <table class=""table table-hover"" id=""dataTable"">
                                <thead>
                                    <tr>
                                        <th>Razred</th>
                                        <th>Oznaka</th>
                                        <th>Prebačen u više odjeljenje</th>
                                  ");
            WriteLiteral(@"      <th>Školska godina</th>
                                        <th>Razrednik</th>
                                        <th>Smjer</th>
                                        <th>Akcija</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 168 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
                                     foreach (var x in @Model.ListaOdjeljenja)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 171 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
                                           Write(x.Razred);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 172 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
                                           Write(x.Oznaka);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 173 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
                                            Write(x.PrebacenUViseOdjeljenje ? "DA" : "NE");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 174 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
                                           Write(x.SkolskaGodina);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 175 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
                                           Write(x.Razrednik);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 176 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
                                           Write(x.Smjer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                            <td>\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 8140, "\"", 8203, 2);
            WriteAttributeValue("", 8147, "/ProfesorOdjeljenje/Detalji?OdjeljenjeID=", 8147, 41, true);
#nullable restore
#line 179 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
WriteAttributeValue("", 8188, x.OdjeljenjeID, 8188, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">Detalji</a>\r\n                                            </td>\r\n\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 184 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Prikaz.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>

                        </div>
                    </div>
                </div>


            </div>


            <!--body-->
        </div>
    </div>


    <footer class=""footer"">
    </footer>
</div>






");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_eDnevnik.Web.ViewModel.PrikazOdjeljenjaVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
