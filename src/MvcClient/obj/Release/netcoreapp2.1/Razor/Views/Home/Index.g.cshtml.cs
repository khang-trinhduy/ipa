#pragma checksum "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ddb5fb96d81a079e001c846e447b4c17cadbce15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\_ViewImports.cshtml"
using MvcClient;

#line default
#line hidden
#line 1 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddb5fb96d81a079e001c846e447b4c17cadbce15", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d85b62b0638c1fde9125c8ffd754efc24f227a99", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MvcClient.Models.Grant>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetPermission", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(120, 49, true);
            WriteLiteral("<h2>OpenID Connect MVC Client</h2>\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(169, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be0c369ed52d471784e917604219e017", async() => {
                BeginContext(199, 10, true);
                WriteLiteral("Permission");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(213, 26, true);
            WriteLiteral("\r\n</div>\r\n<hr />\r\n\r\n<dl>\r\n");
            EndContext();
#line 14 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
            BeginContext(287, 12, true);
            WriteLiteral("        <dt>");
            EndContext();
            BeginContext(300, 10, false);
#line 16 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
       Write(claim.Type);

#line default
#line hidden
            EndContext();
            BeginContext(310, 19, true);
            WriteLiteral("</dt>\r\n        <dd>");
            EndContext();
            BeginContext(330, 11, false);
#line 17 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
       Write(claim.Value);

#line default
#line hidden
            EndContext();
            BeginContext(341, 7, true);
            WriteLiteral("</dd>\r\n");
            EndContext();
#line 18 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(355, 34, true);
            WriteLiteral("</dl>\r\n<h2>Properties</h2>\r\n<dl>\r\n");
            EndContext();
#line 22 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
     foreach (var prop in (await Context.AuthenticateAsync()).Properties.Items)
    {

#line default
#line hidden
            BeginContext(477, 12, true);
            WriteLiteral("        <dt>");
            EndContext();
            BeginContext(490, 8, false);
#line 24 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
       Write(prop.Key);

#line default
#line hidden
            EndContext();
            BeginContext(498, 19, true);
            WriteLiteral("</dt>\r\n        <dd>");
            EndContext();
            BeginContext(518, 10, false);
#line 25 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
       Write(prop.Value);

#line default
#line hidden
            EndContext();
            BeginContext(528, 7, true);
            WriteLiteral("</dd>\r\n");
            EndContext();
#line 26 "C:\Users\trinh\Downloads\Combined_AspId_and_EFStorage\src\MvcClient\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(542, 5, true);
            WriteLiteral("</dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MvcClient.Models.Grant> Html { get; private set; }
    }
}
#pragma warning restore 1591
