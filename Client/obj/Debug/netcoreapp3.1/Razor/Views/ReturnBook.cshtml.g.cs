#pragma checksum "D:\MyPrograms\DOt_Net\Client\Views\ReturnBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d95b44af37649c597492a56bce9618d78b3c468"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReturnBook), @"mvc.1.0.view", @"/Views/ReturnBook.cshtml")]
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
#line 1 "D:\MyPrograms\DOt_Net\Client\Views\ReturnBook.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d95b44af37649c597492a56bce9618d78b3c468", @"/Views/ReturnBook.cshtml")]
    public class Views_ReturnBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<form method=\"post\">\r\n    <p>\r\n        <label>Выберите книгу:</label>\r\n        <select name=\"bookId\">\r\n");
#nullable restore
#line 9 "D:\MyPrograms\DOt_Net\Client\Views\ReturnBook.cshtml"
             foreach (BookDTO book in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <option");
            BeginWriteAttribute("value", " value=", 242, "", 257, 1);
#nullable restore
#line 11 "D:\MyPrograms\DOt_Net\Client\Views\ReturnBook.cshtml"
WriteAttributeValue("", 249, book.Id, 249, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 11 "D:\MyPrograms\DOt_Net\Client\Views\ReturnBook.cshtml"
                                  Write(book.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 11 "D:\MyPrograms\DOt_Net\Client\Views\ReturnBook.cshtml"
                                               Write(book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 12 "D:\MyPrograms\DOt_Net\Client\Views\ReturnBook.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n    </p>\r\n\r\n    <p>\r\n        <input type=\"submit\" value=\"Отправить\" />\r\n    </p>\r\n</form>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BookDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591