#pragma checksum "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1cdcdd17b5376f123417e383fb69dea8f1c7c80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProfesorProfesor_Info), @"mvc.1.0.view", @"/Views/ProfesorProfesor/Info.cshtml")]
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
#line 2 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
using _eDnevnik.Web.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
using _eDnevnik.Data.EntityModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
using _eDnevnik.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
using Microsoft.Extensions.DependencyInjection;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1cdcdd17b5376f123417e383fb69dea8f1c7c80", @"/Views/ProfesorProfesor/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38dd9705558a3aeb8e61ab533b6648fd75201f3", @"/Views/_ViewImports.cshtml")]
    public class Views_ProfesorProfesor_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_eDnevnik.Web.ViewModel.ProfesorInfo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("navbar-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
  
    ViewData["Title"] = "Info";
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
#line 34 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
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
#line 44 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
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
            <li class=""nav-item"">
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
            <li cla");
            WriteLiteral(@"ss=""nav-item "">
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
            <li class=""nav-item "">
 ");
            WriteLiteral(@"               <a class=""nav-link"" href=""/ProfesorSjednica/Prikaz"">
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1cdcdd17b5376f123417e383fb69dea8f1c7c8011059", async() => {
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
            </div><!------------------------------------");
            WriteLiteral(@"------------------------------------------------------>
        </div>
    </nav>

    <!-- End Navbar -->
    <div class=""content"">
        <div class=""container-fluid"">
            <!--body-->

            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""card card-profile"">
                        <div class=""card-avatar"">
                            <a href=""#pablo"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c1cdcdd17b5376f123417e383fb69dea8f1c7c8013951", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6550, "~/uploads/", 6550, 10, true);
#nullable restore
#line 151 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
AddHtmlAttributeValue("", 6560, Model.NazivSlike, 6560, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </a>\r\n                        </div>\r\n                        <div class=\"card-body\">\r\n                            <h6 class=\"card-category text-gray\">Profesor</h6>\r\n                            <h4 class=\"card-title\">");
#nullable restore
#line 156 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                              Write(Model.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 156 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                                         Write(Model.Prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""card"">
                        <div class=""card-header card-header-primary"">
                            <h4 class=""card-title"">Profesor</h4>
                            <p class=""card-category"">Lični podaci</p>
                        </div>
                        <div class=""card-body table-responsive"">
                            <table class=""table table-hover"">
                                <thead class=""text-primary"">
                                    <tr>
                                        <th>Ime</th>
                                        <th>Prezime</th>
                                        <th>Korisnicko ime</th>
                                        <th>Opcina</th>
                                        <th>Grad</th>
                                     ");
            WriteLiteral("   <th>Drzava</th>\r\n\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n                                    <tr>\r\n                                        <td>");
#nullable restore
#line 184 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 185 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.Prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 186 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.KorisničkoIme);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 187 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.Opcina);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 188 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.Grad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 189 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.Država);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>

                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <div class=""card"">
                        <div class=""card-header card-header-success"">
                            <h4 class=""card-title"">Odjeljenje</h4>
                            <p class=""card-category"">Opći podaci</p>
                        </div>
                        <div class=""card-body table-responsive"">
                            <table class=""table table-hover"">
                                <thead class=""text-primary"">
                                    <tr>
                                        <th>Razred</th>
                                        <th>Oznaka</th>
                                        <th>Smjer</th>
                                        <th>Skolska godina</th>

                 ");
            WriteLiteral("                   </tr>\r\n                                </thead>\r\n                                <tbody>\r\n                                    <tr>\r\n                                        <td>");
#nullable restore
#line 216 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.Razred);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 217 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.OdjeljenjeOznaka);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 218 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.Smjer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 219 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.SkolskaGodina);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <div class=""card"">
                        <div class=""card-header card-header-success"">
                            <h4 class=""card-title"">Raspored konsultacija</h4>
                            <p class=""card-category"">Opći podaci</p>
                        </div>
                        <div class=""card-body table-responsive"">
                            <table class=""table table-hover"">
                                <thead class=""text-primary"">
                                    <tr>
                                        <th>Napomena</th>
                                        <th>Raspored fajl</th>
                                        <th>Skolska godina</th>


                                    </tr>
          ");
            WriteLiteral("                      </thead>\r\n                                <tbody>\r\n                                    <tr>\r\n                                        <td>");
#nullable restore
#line 245 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.NapomenaRasporeda);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1cdcdd17b5376f123417e383fb69dea8f1c7c8023622", async() => {
                WriteLiteral("prikazi");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 11198, "~/uploads/", 11198, 10, true);
#nullable restore
#line 247 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
AddHtmlAttributeValue("", 11208, Model.Rasporedfajl, 11208, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>");
#nullable restore
#line 249 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorProfesor\Info.cshtml"
                                       Write(Model.SkolskaGodinaRaspored);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>

                                    </tr>
                                </tbody>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_eDnevnik.Web.ViewModel.ProfesorInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591
