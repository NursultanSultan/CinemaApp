#pragma checksum "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\Shared\_MoviePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07b3e2fd5b78373a3a4a2f7ba957d6549236ec87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MoviePartial), @"mvc.1.0.view", @"/Views/Shared/_MoviePartial.cshtml")]
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
#line 1 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\_ViewImports.cshtml"
using CinemaApp.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\_ViewImports.cshtml"
using CinemaApp.Business.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\_ViewImports.cshtml"
using CinemaApp.Entity.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07b3e2fd5b78373a3a4a2f7ba957d6549236ec87", @"/Views/Shared/_MoviePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7ef1b620fb44008169c455b3553d1d308f574c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MoviePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Movie>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Movie", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card__cover"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\Shared\_MoviePartial.cshtml"
 foreach (var movie in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-12 col-md-6 col-xl-4\">\r\n        <div class=\"card card--big\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07b3e2fd5b78373a3a4a2f7ba957d6549236ec874595", async() => {
                WriteLiteral("\r\n                <img");
                BeginWriteAttribute("src", " src=\"", 270, "\"", 307, 2);
                WriteAttributeValue("", 276, "./assets/image/", 276, 15, true);
#nullable restore
#line 8 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\Shared\_MoviePartial.cshtml"
WriteAttributeValue("", 291, movie.PosterUrl, 291, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 308, "\"", 314, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                <svg width=""22"" height=""22"" viewBox=""0 0 22 22"" fill=""none"" xmlns=""http://www.w3.org/2000/svg""><path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""M11 1C16.5228 1 21 5.47716 21 11C21 16.5228 16.5228 21 11 21C5.47716 21 1 16.5228 1 11C1 5.47716 5.47716 1 11 1Z"" stroke-linecap=""round"" stroke-linejoin=""round"" /><path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""M14.0501 11.4669C13.3211 12.2529 11.3371 13.5829 10.3221 14.0099C10.1601 14.0779 9.74711 14.2219 9.65811 14.2239C9.46911 14.2299 9.28711 14.1239 9.19911 13.9539C9.16511 13.8879 9.06511 13.4569 9.03311 13.2649C8.93811 12.6809 8.88911 11.7739 8.89011 10.8619C8.88911 9.90489 8.94211 8.95489 9.04811 8.37689C9.07611 8.22089 9.15811 7.86189 9.18211 7.80389C9.22711 7.69589 9.30911 7.61089 9.40811 7.55789C9.48411 7.51689 9.57111 7.49489 9.65811 7.49789C9.74711 7.49989 10.1091 7.62689 10.2331 7.67589C11.2111 8.05589 13.2801 9.43389 14.0401 10.2439C14.1081 10.3169 14.2951 10.5129 14.3261 10.5529C14.3971 10.6429 14.4321 10.7519 14.4321 10.8619C14.4321 ");
                WriteLiteral("10.9639 14.4011 11.0679 14.3371 11.1549C14.3041 11.1999 14.1131 11.3999 14.0501 11.4669Z\" stroke-linecap=\"round\" stroke-linejoin=\"round\" /></svg>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 7 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\Shared\_MoviePartial.cshtml"
                                                            WriteLiteral(movie.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <button class=""card__add"" type=""button""><svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><path d=""M16,2H8A3,3,0,0,0,5,5V21a1,1,0,0,0,.5.87,1,1,0,0,0,1,0L12,18.69l5.5,3.18A1,1,0,0,0,18,22a1,1,0,0,0,.5-.13A1,1,0,0,0,19,21V5A3,3,0,0,0,16,2Zm1,17.27-4.5-2.6a1,1,0,0,0-1,0L7,19.27V5A1,1,0,0,1,8,4h8a1,1,0,0,1,1,1Z"" /></svg></button>
            <span class=""card__rating""><svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><path d=""M22,9.67A1,1,0,0,0,21.14,9l-5.69-.83L12.9,3a1,1,0,0,0-1.8,0L8.55,8.16,2.86,9a1,1,0,0,0-.81.68,1,1,0,0,0,.25,1l4.13,4-1,5.68A1,1,0,0,0,6.9,21.44L12,18.77l5.1,2.67a.93.93,0,0,0,.46.12,1,1,0,0,0,.59-.19,1,1,0,0,0,.4-1l-1-5.68,4.13-4A1,1,0,0,0,22,9.67Zm-6.15,4a1,1,0,0,0-.29.88l.72,4.2-3.76-2a1.06,1.06,0,0,0-.94,0l-3.76,2,.72-4.2a1,1,0,0,0-.29-.88l-3-3,4.21-.61a1,1,0,0,0,.76-.55L12,5.7l1.88,3.82a1,1,0,0,0,.76.55l4.21.61Z"" /></svg> ");
#nullable restore
#line 12 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\Shared\_MoviePartial.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     Write(movie.ImdbPoint);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <div class=\"card__content\">\r\n                <h3 class=\"card__title\"><a href=\"./movie.html\">");
#nullable restore
#line 14 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\Shared\_MoviePartial.cshtml"
                                                          Write(movie.MovieName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                <ul class=\"card__list\">\r\n                    <li>");
#nullable restore
#line 16 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\Shared\_MoviePartial.cshtml"
                   Write(movie.AgeLimit);

#line default
#line hidden
#nullable disable
            WriteLiteral(" +</li>\r\n                    <li>Comedy</li>\r\n                    <li>2012</li>\r\n                </ul>\r\n                <ul class=\"card__info\">\r\n                    <li>\r\n                        <span>Director:</span>\r\n                        <span>");
#nullable restore
#line 23 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\Shared\_MoviePartial.cshtml"
                         Write(movie.Director);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </li>\r\n                </ul>\r\n                <p class=\"card__tagline\">«The story of a man who was too proud to run»</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 30 "C:\Users\Home\source\repos\CinemaApp\CinemaApp.UI\Views\Shared\_MoviePartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591