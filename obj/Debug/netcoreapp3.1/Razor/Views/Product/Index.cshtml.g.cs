#pragma checksum "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aaf789774561d8dc6dc89a7d0e153bd9fac4967c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 1 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\_ViewImports.cshtml"
using BlueFlamePizza;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\_ViewImports.cshtml"
using BlueFlamePizza.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaf789774561d8dc6dc89a7d0e153bd9fac4967c", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c7dd31cc85f54071827ab0ea429eeb4449ccd70", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlueFlamePizza.ViewModels.ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/product.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
   
    var count = ViewBag.cartItemCount;
    var cart_id_ViewBag = ViewBag.currentCartId;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 id=\"page-welcome\">Welcome!</h1>\r\n<div>\r\n");
#nullable restore
#line 9 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
     if (User.Identity.IsAuthenticated)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <span>Logged in as: ");
#nullable restore
#line 12 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                       Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(";</span>\r\n");
#nullable restore
#line 13 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
         using (Html.BeginForm("Logout", "Account", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button");
            BeginWriteAttribute("class", " class=\"", 403, "\"", 411, 0);
            EndWriteAttribute();
            WriteLiteral(" btn btn-info\">Logout</button>\r\n");
#nullable restore
#line 16 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div hidden id=\"currentSession\">");
#nullable restore
#line 18 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                               Write(ViewBag.currentSession);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <div hidden id=\"currentCartId\">");
#nullable restore
#line 19 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                              Write(ViewBag.currentCartId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n</div>\r\n\r\n<div class=\"menu-container row\">\r\n    <div class=\"col\">\r\n        <div class=\"cart\">\r\n            <h6 id=\"cartItemCount\">Items in cart: ");
#nullable restore
#line 25 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                                             Write(ViewBag.cartItemCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            ");
#nullable restore
#line 26 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
       Write(Html.ActionLink("Continue to cart", "Index", "Cart", new { cart_id = ViewBag.currentCartId }, new { @class = "btn btn-info cart-btn" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            \r\n        </div>\r\n\r\n        <div class=\"menu-categories\">\r\n");
#nullable restore
#line 31 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
             foreach (var category in Model.Categories)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 class=\"category-header\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1129, "\"", 1159, 2);
            WriteAttributeValue("", 1136, "#", 1136, 1, true);
#nullable restore
#line 34 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
WriteAttributeValue("", 1137, category.CategoryName, 1137, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 34 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                                                 Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </h6>\r\n");
#nullable restore
#line 36 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n\r\n    <div class=\"menu-products col-10\">\r\n\r\n");
#nullable restore
#line 43 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
         foreach (var category in Model.Categories)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h4 class=\"category-name\"");
            BeginWriteAttribute("id", " id=\"", 1402, "\"", 1429, 1);
#nullable restore
#line 45 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
WriteAttributeValue("", 1407, category.CategoryName, 1407, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 45 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                                                             Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
            <div class=""product-table-wrapper"">
                <table class=""table product-table"">
                    <tr>
                        <th>Product</th>
                        <th>Description</th>
                        <th>Price</th>
                        <th>Qty</th>
                        <th>Add</th>
                    </tr>

");
#nullable restore
#line 56 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                    foreach (var product in Model.Products)
                    {
                       

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                        if (category.CategoryName == product.Category.CategoryName)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"product-row\"");
            BeginWriteAttribute("id", " id=\"", 2060, "\"", 2083, 1);
#nullable restore
#line 60 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
WriteAttributeValue("", 2065, product.ProductId, 2065, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <td class=\"product-title\">");
#nullable restore
#line 61 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                                             Write(product.ProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"product-content\">");
#nullable restore
#line 62 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                                               Write(product.ProductContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"product-price\">");
#nullable restore
#line 63 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                                             Write(Html.DisplayFor(modelItem => product.ProductPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"product-qty\" id=\"product-qty\">\r\n                            <div class=\"button-col\">\r\n                                <input type=\"text\" class=\"product-order-count-form\"");
            BeginWriteAttribute("id", " id=\"", 2559, "\"", 2582, 1);
#nullable restore
#line 66 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
WriteAttributeValue("", 2564, product.ProductId, 2564, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""product-order-count-form"" value=""1"" readonly=""readonly"" />
                                <button class=""order-count-increase btn btn-outline-info"" id=""product-order-count-increase"">+</button>
                                <button class=""order-count-decrease btn btn-outline-info"" id=""product-order-count-decrease"">-</button>
                            </div>

                        </td>
                        <td>
                            <button class=""cart-add-button btn btn-info"">Add</button>
");
#nullable restore
#line 74 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                             if (category.CategoryName.Contains("Pizza"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <button class=\"customize-pizza-button btn btn-info\" id=\"customize-pizza\">Customize</button>\r\n");
#nullable restore
#line 77 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 80 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </table>\r\n            </div>\r\n");
#nullable restore
#line 84 "C:\Users\wight\source\repos\BlueFlamePizza\BlueFlamePizza\Views\Product\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aaf789774561d8dc6dc89a7d0e153bd9fac4967c14116", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlueFlamePizza.ViewModels.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591