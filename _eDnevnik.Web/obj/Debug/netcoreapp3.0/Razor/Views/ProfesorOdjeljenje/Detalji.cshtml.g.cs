#pragma checksum "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbb270ea3e950acfb384bacba382df501959331a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProfesorOdjeljenje_Detalji), @"mvc.1.0.view", @"/Views/ProfesorOdjeljenje/Detalji.cshtml")]
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
#line 2 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
using _eDnevnik.Web.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
using _eDnevnik.Data.EntityModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
using _eDnevnik.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
using Microsoft.Extensions.DependencyInjection;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbb270ea3e950acfb384bacba382df501959331a", @"/Views/ProfesorOdjeljenje/Detalji.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38dd9705558a3aeb8e61ab533b6648fd75201f3", @"/Views/_ViewImports.cshtml")]
    public class Views_ProfesorOdjeljenje_Detalji : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_eDnevnik.Web.ViewModel.OdjeljenjeDetaljiVM>
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
#line 7 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
  
    ViewData["Title"] = "Detalji";
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
#line 37 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
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
#line 48 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbb270ea3e950acfb384bacba382df501959331a10301", async() => {
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
                    <div class=""card"">
                        <div class=""card-header card-header-primary"">
                            <h4 class=""card-title"">Odjeljenje</h4>
                            <p class=""card-category"">Detalji</p>
                        </div>
                        <div class=""card-body table-responsive"">
                            <table style=""width:100%"">
                                <tr>
                                    <td style=""padding-right:30px;"">
                                        <div class=""form-group"">
                                            <label>Razred: </label>
                                            <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 7074, "\"", 7095, 1);
#nullable restore
#line 163 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
WriteAttributeValue("", 7082, Model.Razred, 7082, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control"" readonly />
                                        </div>
                                    </td>
                                    <td style=""padding-right:30px;"">
                                        <div class=""form-group"">
                                            <label>Oznaka: </label>
                                            <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 7489, "\"", 7510, 1);
#nullable restore
#line 169 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
WriteAttributeValue("", 7497, Model.Oznaka, 7497, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control"" readonly />
                                        </div>
                                    </td>
                                    <td>
                                        <div class=""form-group"">
                                            <label>Razrednik: </label>
                                            <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 7879, "\"", 7903, 1);
#nullable restore
#line 175 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
WriteAttributeValue("", 7887, Model.Razrednik, 7887, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control"" readonly />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""padding-right:30px"">
                                        <div class=""form-group"">
                                            <label>Školska godina: </label>
                                            <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 8381, "\"", 8409, 1);
#nullable restore
#line 183 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
WriteAttributeValue("", 8389, Model.SkolskaGodina, 8389, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control"" readonly />
                                        </div>
                                    </td>
                                    <td colspan=""2"">
                                        <div class=""form-group"">
                                            <label>Smjer: </label>
                                            <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 8786, "\"", 8806, 1);
#nullable restore
#line 189 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
WriteAttributeValue("", 8794, Model.Smjer, 8794, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control"" readonly />
                                        </div>
                                    </td>
                                </tr>

                            </table>


                            <br />
                            <br />
                            <div class=""form-group""><b>Učenici:</b></div>
                            <div id=""prikazUcenika""></div>


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
<script>
    $(document).ready(function (p) {
        $.get(""/ProfesorOdjeljenje/PrikazUcenika?OdjeljenjeID=");
#nullable restore
#line 221 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\ProfesorOdjeljenje\Detalji.cshtml"
                                                         Write(Model.OdjeljenjeID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",function (rezultat, status) {\r\n            $(\"#prikazUcenika\").html(rezultat);\r\n        });\r\n    });\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_eDnevnik.Web.ViewModel.OdjeljenjeDetaljiVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
