#pragma checksum "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18f1edf8205a5e49660218d9d6b38f6f14c6825a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart__PaypalPartial), @"mvc.1.0.view", @"/Views/Cart/_PaypalPartial.cshtml")]
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
#line 1 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\_ViewImports.cshtml"
using ShoppingCartApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\_ViewImports.cshtml"
using ShoppingCartApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18f1edf8205a5e49660218d9d6b38f6f14c6825a", @"/Views/Cart/_PaypalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4205ecb86708745206c2de3c28ef5e00366ddc24", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cart__PaypalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("paypalform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("https://www.sandbox.paypal.com/us/cgi-bin/webscr"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml"
   
    int count = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18f1edf8205a5e49660218d9d6b38f6f14c6825a4602", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"cmd\" value=\"_cart\">\r\n    <input type=\"hidden\" name=\"upload\" value=\"1\">\r\n    <input type=\"hidden\" name=\"business\" value=\"usamamehmood@gmail.com\">\r\n\r\n");
#nullable restore
#line 10 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 377, "\"", 400, 2);
                WriteAttributeValue("", 384, "item_name_", 384, 10, true);
#nullable restore
#line 12 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml"
WriteAttributeValue("", 394, count, 394, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 401, "\"", 426, 1);
#nullable restore
#line 12 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml"
WriteAttributeValue("", 409, item.ProductName, 409, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n        <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 458, "\"", 478, 2);
                WriteAttributeValue("", 465, "amount_", 465, 7, true);
#nullable restore
#line 13 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml"
WriteAttributeValue("", 472, count, 472, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 479, "\"", 498, 1);
#nullable restore
#line 13 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml"
WriteAttributeValue("", 487, item.Price, 487, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n        <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 530, "\"", 552, 2);
                WriteAttributeValue("", 537, "quantity_", 537, 9, true);
#nullable restore
#line 14 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml"
WriteAttributeValue("", 546, count, 546, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 553, "\"", 575, 1);
#nullable restore
#line 14 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml"
WriteAttributeValue("", 561, item.Quantity, 561, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 15 "D:\usama_work\Web Development\ASP.NET\ShoppingCartApp\ShoppingCartApp\Views\Cart\_PaypalPartial.cshtml"
        count++;
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"currency_code\" value=\"USD\">\r\n    <input type=\"image\" src=\"http://www.paypal.com/en_US/i/btn/x-click-but01.gif\" name=\"submit\" alt=\"Make payments with PayPal - it\'s fast, free and secure!\">\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
