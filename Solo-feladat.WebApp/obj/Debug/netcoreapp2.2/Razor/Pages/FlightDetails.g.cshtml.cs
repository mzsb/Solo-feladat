#pragma checksum "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f16094062a9324984caf5ab50a1434a4fd6477d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Solo_feladat.WebApp.Pages.Pages_FlightDetails), @"mvc.1.0.razor-page", @"/Pages/FlightDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/FlightDetails.cshtml", typeof(Solo_feladat.WebApp.Pages.Pages_FlightDetails), null)]
namespace Solo_feladat.WebApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\_ViewImports.cshtml"
using Solo_feladat.WebApp;

#line default
#line hidden
#line 3 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
using Solo_feladat.Model.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f16094062a9324984caf5ab50a1434a4fd6477d7", @"/Pages/FlightDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4769eb2f14f13aa26309f8765113726fbce25f8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_FlightDetails : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Accept", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Denied", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 4 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
  
    ViewData["Title"] = "FlightDetails";

#line default
#line hidden
            BeginContext(143, 133, true);
            WriteLiteral("\r\n    <h1>Repülés részletes nézete</h1>\r\n\r\n    <table class=\"table\">\r\n        <tbody>\r\n            <tr>\r\n                <td>Pilóta: ");
            EndContext();
            BeginContext(277, 29, false);
#line 13 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                       Write(Model.Flight.AppUser.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(306, 80, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Repülés dátuma: ");
            EndContext();
            BeginContext(387, 17, false);
#line 16 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                               Write(Model.Flight.Date);

#line default
#line hidden
            EndContext();
            BeginContext(404, 82, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Felszállás helye: ");
            EndContext();
            BeginContext(487, 31, false);
#line 19 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                                 Write(Model.Flight.TakeOfAirport.Name);

#line default
#line hidden
            EndContext();
            BeginContext(518, 81, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Leszállás helye: ");
            EndContext();
            BeginContext(600, 32, false);
#line 22 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                                Write(Model.Flight.LandingAirport.Name);

#line default
#line hidden
            EndContext();
            BeginContext(632, 44, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n");
            EndContext();
#line 25 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                 if (@Model.Flight.Status.Equals(FlightStatus.Wait))
                {

#line default
#line hidden
            BeginContext(765, 55, true);
            WriteLiteral("                    <td>Státusz: Elfogadásra vár</td>\r\n");
            EndContext();
#line 28 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                }
                else if (@Model.Flight.Status.Equals(FlightStatus.Accepted))
                {

#line default
#line hidden
            BeginContext(936, 49, true);
            WriteLiteral("                    <td>Státusz: Elfogadva</td>\r\n");
            EndContext();
#line 32 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                }
                else if (@Model.Flight.Status.Equals(FlightStatus.Denied))
                {

#line default
#line hidden
            BeginContext(1099, 50, true);
            WriteLiteral("                    <td>Státusz: Elutasítva</td>\r\n");
            EndContext();
#line 36 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1209, 41, true);
            WriteLiteral("                    <td>Státusz: -</td>\r\n");
            EndContext();
#line 40 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                }

#line default
#line hidden
            BeginContext(1269, 19, true);
            WriteLiteral("            </tr>\r\n");
            EndContext();
#line 42 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
             if (User.IsInRole("Administrator") && @Model.Flight.Status.Equals(FlightStatus.Wait))
            {

#line default
#line hidden
            BeginContext(1403, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1475, 183, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f16094062a9324984caf5ab50a1434a4fd6477d78639", async() => {
                BeginContext(1553, 98, true);
                WriteLiteral("\r\n                            <button class=\"btn-light\">Elfogad</button>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                                                          WriteLiteral(Model.Flight.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1658, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(1684, 184, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f16094062a9324984caf5ab50a1434a4fd6477d711590", async() => {
                BeginContext(1762, 99, true);
                WriteLiteral("\r\n                            <button class=\"btn-light\">Elutasít</button>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 49 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
                                                          WriteLiteral(Model.Flight.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1868, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 54 "U:\solo-feladat\solo-feladat\Solo-feladat.WebApp\Pages\FlightDetails.cshtml"
            }

#line default
#line hidden
            BeginContext(1935, 42, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Solo_feladat.WebApp.Pages.FlightDetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Solo_feladat.WebApp.Pages.FlightDetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Solo_feladat.WebApp.Pages.FlightDetailsModel>)PageContext?.ViewData;
        public Solo_feladat.WebApp.Pages.FlightDetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
