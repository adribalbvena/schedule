#pragma checksum "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf44b6683e0cfd3b1e7b3ba6acf8abcb9746513d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Turns_MyTurns), @"mvc.1.0.view", @"/Views/Turns/MyTurns.cshtml")]
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
#line 1 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/_ViewImports.cshtml"
using tp_nt1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/_ViewImports.cshtml"
using tp_nt1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf44b6683e0cfd3b1e7b3ba6acf8abcb9746513d", @"/Views/Turns/MyTurns.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa23afcfec133fe9b3c60065fa05ff4749bd1e08", @"/Views/_ViewImports.cshtml")]
    public class Views_Turns_MyTurns : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<tp_nt1.Models.Turn>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SelectMedicalService", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cancel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
  
    ViewData["Title"] = "Mis Turnos";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!DOCTYPE html>\n\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf44b6683e0cfd3b1e7b3ba6acf8abcb9746513d5798", async() => {
                WriteLiteral("\n    <meta name=\"viewport\" content=\"width=device-width\" />\n    <title>");
#nullable restore
#line 12 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf44b6683e0cfd3b1e7b3ba6acf8abcb9746513d7061", async() => {
                WriteLiteral("\n    <p>\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf44b6683e0cfd3b1e7b3ba6acf8abcb9746513d7332", async() => {
                    WriteLiteral("Solicitar Turno");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    </p>\n    <table class=\"table table-striped\">\n        <thead>\n            <tr>\n                <th>\n                    ");
#nullable restore
#line 22 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
               Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </th>\n                <th>\n                    ");
#nullable restore
#line 25 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
               Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </th>\n                <th>\n                    ");
#nullable restore
#line 28 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
               Write(Html.DisplayNameFor(model => model.Professional));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </th>\n                <th>\n                    ");
#nullable restore
#line 31 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
               Write(Html.DisplayNameFor(model => model.Confirmed));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </th>\n                <th></th>\n            </tr>\n        </thead>\n        <tbody>\n");
#nullable restore
#line 37 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
             foreach (var item in Model)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                 if (item.Active)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\n                        <td>\n                            Activo\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 46 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 49 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Professional.FullName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        </td>\n                        <td>\n");
#nullable restore
#line 52 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                             if (item.Confirmed)
                            {
                                if (!string.IsNullOrWhiteSpace(item.CancelDescription))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p> Cancelado </p>\n");
#nullable restore
#line 57 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"

                                }
                                else

                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p>Confirmado</p>\n");
#nullable restore
#line 63 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                                }

                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(item.CancelDescription))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p> Cancelado </p>\n");
#nullable restore
#line 71 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"

                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p>No Confirmado</p>\n");
#nullable restore
#line 76 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"

                                }

                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\n                        <td class=\"btn-group-vertical\">\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf44b6683e0cfd3b1e7b3ba6acf8abcb9746513d13584", async() => {
                    WriteLiteral("Detalles");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf44b6683e0cfd3b1e7b3ba6acf8abcb9746513d15985", async() => {
                    WriteLiteral("Cancelar");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                                                                                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        </td>\n                    </tr>\n");
#nullable restore
#line 86 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                     if(item.Date >= DateTime.Today.AddDays(-7)) { 

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr class=\"text-muted\">\n                        <td>\n                            Inactivo\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 95 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 98 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Professional.FullName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        </td>\n                        <td>\n");
#nullable restore
#line 101 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                             if (item.Confirmed)
                            {
                                if (!string.IsNullOrWhiteSpace(item.CancelDescription))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p> Cancelado </p>\n");
#nullable restore
#line 106 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"

                                }
                                else

                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p>Confirmado</p>\n");
#nullable restore
#line 112 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                                }

                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(item.CancelDescription))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p> Cancelado </p>\n");
#nullable restore
#line 120 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"

                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p>No Confirmado</p>\n");
#nullable restore
#line 125 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"

                                }

                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\n                        <td class=\"btn-group-vertical\">\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf44b6683e0cfd3b1e7b3ba6acf8abcb9746513d21912", async() => {
                    WriteLiteral("Detalles");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 131 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        </td>\n                    </tr>\n");
#nullable restore
#line 134 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 134 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 135 "/Users/adrianabalbuena/Desktop/NT1_REPO/2021-2-BENT1A-1/tp-nt1/Views/Turns/MyTurns.cshtml"
                 

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\n    </table>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<tp_nt1.Models.Turn>> Html { get; private set; }
    }
}
#pragma warning restore 1591
