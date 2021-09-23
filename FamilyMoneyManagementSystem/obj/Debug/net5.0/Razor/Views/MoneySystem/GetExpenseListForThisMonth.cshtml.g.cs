#pragma checksum "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c66aaae69ce78182ad3bb012e0530311f32e285"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MoneySystem_GetExpenseListForThisMonth), @"mvc.1.0.view", @"/Views/MoneySystem/GetExpenseListForThisMonth.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c66aaae69ce78182ad3bb012e0530311f32e285", @"/Views/MoneySystem/GetExpenseListForThisMonth.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_MoneySystem_GetExpenseListForThisMonth : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
  
	ViewData["Title"] = "Income This Month";
	Layout = "~/Views/Shared/_SecondaryLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
 if (ViewBag.ListOfExpenses.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""table-responsive"">
        <table class=""table table-hover text-center mx-auto w-auto"">
            <thead class=""table-light"">
                <tr>
                    <th scope=""col"">ID</th>
                    <th scope=""col"">Name</th>
                    <th scope=""col"">Description</th>
                    <th scope=""col"">Amount</th>
                    <th scope=""col"">Time added</th>
                    <th scope=""col"">Type</th>
                    <th scope=""col"">Edit</th>
                    <th scope=""col"">Delete</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 23 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                 foreach (var item in ViewBag.ListOfExpenses)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
#nullable restore
#line 26 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                                   Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <td>");
#nullable restore
#line 27 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 28 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 29 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 30 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.TimeAdded);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1236, "\"", 1306, 1);
#nullable restore
#line 33 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
WriteAttributeValue("", 1243, Url.Action("EditExpense", "MoneySystem", new { ID = item.ID }), 1243, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success"">
                                <i class=""fas fa-edit""></i>
                                <span>
                                    <strong>Edit</strong>
                                </span>
                            </a>
                        </td>
                        <td>
                            <a");
            BeginWriteAttribute("href", " href=\"", 1660, "\"", 1732, 1);
#nullable restore
#line 41 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
WriteAttributeValue("", 1667, Url.Action("DeleteExpense", "MoneySystem", new { ID = item.ID }), 1667, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-danger"">
                                <i class=""far fa-trash-alt""></i>
                                <span>
                                    <strong>Delete</strong>
                                </span>
                            </a>
                        </td>
                    </tr>
");
#nullable restore
#line 49 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n        <div class=\"row col col-lg-5 m-lg-auto text-center p-4\">\r\n            <div class=\"text-end col-sm\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 2245, "\"", 2287, 1);
#nullable restore
#line 54 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
WriteAttributeValue("", 2252, Url.Action("Index", "MoneySystem"), 2252, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Go back</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 58 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<h2 class=\"text-center\">You have no expenses for this month!</h2>\r\n    <div class=\"row col col-lg-5 m-lg-auto text-center p-4\">\r\n        <div class=\"text-end col-sm\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 2569, "\"", 2611, 1);
#nullable restore
#line 64 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
WriteAttributeValue("", 2576, Url.Action("Index", "MoneySystem"), 2576, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Go back</a>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 67 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
