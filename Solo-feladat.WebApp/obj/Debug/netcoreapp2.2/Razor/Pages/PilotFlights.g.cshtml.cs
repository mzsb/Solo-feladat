#pragma checksum "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91c34d5d90ffffcffe90bf5c676735350967a03b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Solo_feladat.WebApp.Pages.Pages_PilotFlights), @"mvc.1.0.razor-page", @"/Pages/PilotFlights.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/PilotFlights.cshtml", typeof(Solo_feladat.WebApp.Pages.Pages_PilotFlights), null)]
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
#line 1 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\_ViewImports.cshtml"
using Solo_feladat.WebApp;

#line default
#line hidden
#line 3 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
using Solo_feladat.Model.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91c34d5d90ffffcffe90bf5c676735350967a03b", @"/Pages/PilotFlights.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4769eb2f14f13aa26309f8765113726fbce25f8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PilotFlights : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "FlightDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
  
    ViewData["Title"] = "PilotFlights";

#line default
#line hidden
            BeginContext(141, 284, true);
            WriteLiteral(@"
<h1>Repüléseim</h1>

<table class=""table"">
    <thead>
        <tr>
            <th>Dátum</th>
            <th>Időtartam</th>
            <th>Felszállás helye</th>
            <th>Leszállás helye</th>
            <th>Státusz</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 21 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
         foreach (var flight in Model.Flights)
        {

#line default
#line hidden
            BeginContext(484, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(523, 33, false);
#line 24 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
               Write(Html.DisplayFor(m => flight.Date));

#line default
#line hidden
            EndContext();
            BeginContext(556, 55, true);
            WriteLiteral("</td>\r\n                <td>-</td>\r\n                <td>");
            EndContext();
            BeginContext(612, 47, false);
#line 26 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
               Write(Html.DisplayFor(m => flight.TakeOfAirport.Name));

#line default
#line hidden
            EndContext();
            BeginContext(659, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(687, 48, false);
#line 27 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
               Write(Html.DisplayFor(m => flight.LandingAirport.Name));

#line default
#line hidden
            EndContext();
            BeginContext(735, 9, true);
            WriteLiteral("</td>\r\n\r\n");
            EndContext();
#line 29 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
                 if (@flight.Status.Equals(FlightStatus.Wait))
                {

#line default
#line hidden
            BeginContext(827, 46, true);
            WriteLiteral("                    <td>Elfogadásra vár</td>\r\n");
            EndContext();
#line 32 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
                }
                else if (@flight.Status.Equals(FlightStatus.Accepted))
                {

#line default
#line hidden
            BeginContext(983, 40, true);
            WriteLiteral("                    <td>Elfogadva</td>\r\n");
            EndContext();
#line 36 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
                }
                else if (@flight.Status.Equals(FlightStatus.Denied))
                {

#line default
#line hidden
            BeginContext(1131, 41, true);
            WriteLiteral("                    <td>Elutasítva</td>\r\n");
            EndContext();
#line 40 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1232, 32, true);
            WriteLiteral("                    <td>-</td>\r\n");
            EndContext();
#line 44 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
                }

#line default
#line hidden
            BeginContext(1283, 23, true);
            WriteLiteral("\r\n                <td> ");
            EndContext();
            BeginContext(1306, 91, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91c34d5d90ffffcffe90bf5c676735350967a03b7933", async() => {
                BeginContext(1384, 9, true);
                WriteLiteral("Részletek");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
                                                   WriteLiteral(flight.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1397, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 48 "C:\Users\mozs.barnabas\Solo_feladat\Solo-feladat\Solo-feladat.WebApp\Pages\PilotFlights.cshtml"
        }

#line default
#line hidden
            BeginContext(1434, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Solo_feladat.WebApp.Pages.PilotFlightsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Solo_feladat.WebApp.Pages.PilotFlightsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Solo_feladat.WebApp.Pages.PilotFlightsModel>)PageContext?.ViewData;
        public Solo_feladat.WebApp.Pages.PilotFlightsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
