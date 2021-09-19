#pragma checksum "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ee9d162c891ca21d9959daf328373fccd662bb6"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee9d162c891ca21d9959daf328373fccd662bb6", @"/Views/MoneySystem/GetExpenseListForThisMonth.cshtml")]
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
            WriteLiteral(@"	<div class=""table-responsive"">
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
            WriteLiteral("\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<th scope=\"row\">");
#nullable restore
#line 26 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                                   Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\t\t\t\t\t\t<td>");
#nullable restore
#line 27 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td>");
#nullable restore
#line 28 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td>");
#nullable restore
#line 29 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td>");
#nullable restore
#line 30 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.TimeAdded);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td>");
#nullable restore
#line 31 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
                       Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 870, "\"", 940, 1);
#nullable restore
#line 33 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
WriteAttributeValue("", 877, Url.Action("EditExpense", "MoneySystem", new { ID = item.ID }), 877, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">\r\n\t\t\t\t\t\t\t\t<i class=\"fas fa-edit\"></i>\r\n\t\t\t\t\t\t\t\t<span>\r\n\t\t\t\t\t\t\t\t\t<strong>Edit</strong>\r\n\t\t\t\t\t\t\t\t</span>\r\n\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 1117, "\"", 1189, 1);
#nullable restore
#line 41 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
WriteAttributeValue("", 1124, Url.Action("DeleteExpense", "MoneySystem", new { ID = item.ID }), 1124, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">\r\n\t\t\t\t\t\t\t\t<i class=\"far fa-trash-alt\"></i>\r\n\t\t\t\t\t\t\t\t<span>\r\n\t\t\t\t\t\t\t\t\t<strong>Delete</strong>\r\n\t\t\t\t\t\t\t\t</span>\r\n\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 49 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t</tbody>\r\n\t\t</table>\r\n\t</div>\r\n");
#nullable restore
#line 53 "D:\Projects C#\FamilyMoneyManagementSystem\FamilyMoneyManagementSystem\Views\MoneySystem\GetExpenseListForThisMonth.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
