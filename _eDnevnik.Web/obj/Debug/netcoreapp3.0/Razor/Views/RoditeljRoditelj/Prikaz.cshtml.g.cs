#pragma checksum "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e8e83954b772516aff48081dd43855a52ade786"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoditeljRoditelj_Prikaz), @"mvc.1.0.view", @"/Views/RoditeljRoditelj/Prikaz.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e8e83954b772516aff48081dd43855a52ade786", @"/Views/RoditeljRoditelj/Prikaz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38dd9705558a3aeb8e61ab533b6648fd75201f3", @"/Views/_ViewImports.cshtml")]
    public class Views_RoditeljRoditelj_Prikaz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_eDnevnik.Web.ViewModel.RoditeljRoditeljPrikazVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("navbar-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
  
    ViewData["Title"] = "Prikaz";

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
                <li class=""nav-item "">
                    <a class=""nav-link"" href=""/Home/Index"">
                        <i class=""material-icons"">dashboard</i>
                        <p>Početna</p>
                    </a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" href=""/UcenikRoditelj/Prikaz"">
                        <i class=""material-icons"">school</i>
                        <p>Podaci o učeniku</p>");
            WriteLiteral(@"
                    </a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" href=""/SekcijaRoditelj/Prikaz"">
                        <i class=""material-icons"">content_paste</i>
                        <p>Sekcije</p>
                    </a>
                </li>
                <li class=""nav-item "">
                    <a class=""nav-link"" href=""/RasporedKonsultacijaRoditelj/Prikaz"">
                        <i class=""material-icons"">event_available</i>
                        <p>Raspored konsultacija</p>
                    </a>
                </li>
                <li class=""nav-item "">
                    <a class=""nav-link"" href=""/ProfesorRoditelj/Prikaz"">
                        <i class=""material-icons"">people</i>
                        <p>Zaključne ocjene</p>
                    </a>
                </li>
            </ul>
        </div>
    </div>
<div class=""main-panel"">
    <!-- Navbar -->
    <nav class=""navbar navbar-expan");
            WriteLiteral("d-lg navbar-transparent navbar-absolute fixed-top \">\r\n        <div class=\"container-fluid\">\r\n            <div class=\"navbar-wrapper\">\r\n                <a class=\"navbar-brand\" href=\"#pablo\">");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e8e83954b772516aff48081dd43855a52ade7867596", async() => {
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
                            <a class=""dropdown-item"" href=""/RoditeljRoditelj/Prikaz"">Profile</a>
                            <div class=""dropdown-divider""></div>
                            <a class=""dropdown-item"" href=""/Autentifikacija/Logout"">Log out</a>
                        </div>
                    </li>
                </ul><!-- ikonica u cosi za log out-->
            </div>
            <!--------------------");
            WriteLiteral(@"---------------------------------------------------------------------->
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2e8e83954b772516aff48081dd43855a52ade78610503", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4696, "~/uploads/", 4696, 10, true);
#nullable restore
#line 102 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
AddHtmlAttributeValue("", 4706, Model.NazivSlike, 4706, 17, false);

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
            WriteLiteral("\r\n                            </a>\r\n                        </div>\r\n                        <div class=\"card-body\">\r\n                            <h6 class=\"card-category text-gray\">Roditelj</h6>\r\n                            <h4 class=\"card-title\">");
#nullable restore
#line 107 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
                                              Write(Model.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 107 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
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
                            <h4 class=""card-title"">Lični podaci</h4>
                            <p class=""card-category""></p>
                        </div>
                        <div class=""card-body table-responsive"">
                            <table class=""table table-hover"">
                                <thead class=""text-primary"">
                                    <tr>
                                        <th>Ime</th>
                                        <th>Prezime</th>
                                        <th>Spol</th>
                                        <th>Datum rodjenja</th>
                                        <th>JMBG</th>
                                        <th>Tel");
            WriteLiteral(@"efon</th>
                                        <th>Email</th>
                                        <th>Opcina</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>");
#nullable restore
#line 136 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
                                       Write(Model.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        <td>");
#nullable restore
#line 137 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
                                       Write(Model.Prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        <td>");
#nullable restore
#line 138 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
                                       Write(Model.Spol);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        <td>");
#nullable restore
#line 139 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
                                       Write(Model.DatumRodjenja);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        <td>");
#nullable restore
#line 140 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
                                       Write(Model.JMBG);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        <td>");
#nullable restore
#line 141 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
                                       Write(Model.Telefon);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        <td>");
#nullable restore
#line 142 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
                                       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        <td>");
#nullable restore
#line 143 "C:\Users\Tarik\Desktop\webapp\_eDnevnik\_eDnevnik.Web\Views\RoditeljRoditelj\Prikaz.cshtml"
                                       Write(Model.Opcina);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </td>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_eDnevnik.Web.ViewModel.RoditeljRoditeljPrikazVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
