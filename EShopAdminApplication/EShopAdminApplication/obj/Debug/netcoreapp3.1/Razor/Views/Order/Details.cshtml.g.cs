#pragma checksum "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "355ffa84a67548ca96836569432f6a34f73cb6c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(EShopAdminApplication.Pages.Order.Views_Order_Details), @"mvc.1.0.view", @"/Views/Order/Details.cshtml")]
namespace EShopAdminApplication.Pages.Order
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
#line 1 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\_ViewImports.cshtml"
using EShopAdminApplication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"355ffa84a67548ca96836569432f6a34f73cb6c7", @"/Views/Order/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c21ee8adedf1ae40e79ec651d5e261770da556ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EShopAdminApplication.Models.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <p>\r\n        <a class=\"btn btn-success\">");
#nullable restore
#line 13 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml"
                              Write(Model.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </p>\r\n\r\n");
#nullable restore
#line 16 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml"
     for (int i = 0; i < Model.Tickets.Count(); i++)
    {
        var item = Model.Tickets.ElementAt(i).SelectedTicket;

        if (i % 3 == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 23 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml"
            }


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-3 m-4\">\r\n                <div class=\"card\" style=\"width: 18rem; height: 30rem;\">\r\n                    <img class=\"card-img-top\" style=\"height: 70%\"");
            BeginWriteAttribute("src", " src=\"", 678, "\"", 701, 1);
#nullable restore
#line 27 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml"
WriteAttributeValue("", 684, item.TicketImage, 684, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n                    <div class=\"card-body\">\r\n                        <h3>");
#nullable restore
#line 29 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml"
                       Write(item.TicketName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <p>");
#nullable restore
#line 30 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml"
                      Write(item.TicketDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p>");
#nullable restore
#line 31 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml"
                      Write(item.TicketPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 36 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml"

            if (i % 3 == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 40 "C:\Users\Vlado\Desktop\интегрирани системи\EShopAdminApplication\EShopAdminApplication\Views\Order\Details.cshtml"
        }

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EShopAdminApplication.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591