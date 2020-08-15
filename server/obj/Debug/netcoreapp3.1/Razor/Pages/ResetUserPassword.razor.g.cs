#pragma checksum "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60fcad647a7d51df2d9a4dfd60d25ea5c083ecf6"
// <auto-generated/>
#pragma warning disable 1591
namespace SoccerLeagueTransferApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\SoccerLeagueTransfer\server\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\SoccerLeagueTransfer\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\SoccerLeagueTransfer\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\SoccerLeagueTransfer\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\SoccerLeagueTransfer\server\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\SoccerLeagueTransfer\server\_Imports.razor"
using SoccerLeagueTransferApp.Shared;

#line default
#line hidden
#line 5 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
using Radzen;

#line default
#line hidden
#line 6 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
using Radzen.Blazor;

#line default
#line hidden
#line 7 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
using SoccerLeagueTransferApp.Models.ConData;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(LoginLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/reset-user-password")]
    public partial class ResetUserPassword : SoccerLeagueTransferApp.Pages.ResetUserPasswordComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(3, "\n    ");
                __builder2.OpenElement(4, "div");
                __builder2.AddAttribute(5, "class", "row");
                __builder2.AddMarkupContent(6, "\n      ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "col-md-12");
                __builder2.AddMarkupContent(9, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTemplateForm<SoccerLeagueTransferApp.Models.ConData.User>>(10);
                __builder2.AddAttribute(11, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<SoccerLeagueTransferApp.Models.ConData.User>(
#line 12 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                   user

#line default
#line hidden
                ));
                __builder2.AddAttribute(12, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#line 12 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                                                                                        user != null

#line default
#line hidden
                ));
                __builder2.AddAttribute(13, "Submit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<SoccerLeagueTransferApp.Models.ConData.User>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<SoccerLeagueTransferApp.Models.ConData.User>(this, 
#line 12 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                                                                                                                Form0Submit

#line default
#line hidden
                )));
                __builder2.AddAttribute(14, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder3) => {
                    __builder3.AddMarkupContent(15, "\n            ");
                    __builder3.OpenElement(16, "div");
                    __builder3.AddAttribute(17, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(18, "class", "row");
                    __builder3.AddMarkupContent(19, "\n              ");
                    __builder3.OpenElement(20, "div");
                    __builder3.AddAttribute(21, "class", "col-md-3");
                    __builder3.AddMarkupContent(22, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenHeading>(23);
                    __builder3.AddAttribute(24, "Size", "H1");
                    __builder3.AddAttribute(25, "style", "text-align: center; width: 396.2874984741211px");
                    __builder3.AddAttribute(26, "Text", "Reset Your Password");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(27, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(28, "\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(29, "\n            ");
                    __builder3.OpenElement(30, "div");
                    __builder3.AddAttribute(31, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(32, "class", "row");
                    __builder3.AddMarkupContent(33, "\n              ");
                    __builder3.OpenElement(34, "div");
                    __builder3.AddAttribute(35, "class", "col-md-3");
                    __builder3.AddMarkupContent(36, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(37);
                    __builder3.AddAttribute(38, "Component", "EmailAddress");
                    __builder3.AddAttribute(39, "style", "width: 100%");
                    __builder3.AddAttribute(40, "Text", "Email Address");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(41, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(42, "\n              ");
                    __builder3.OpenElement(43, "div");
                    __builder3.AddAttribute(44, "class", "col-md-9");
                    __builder3.AddMarkupContent(45, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextBox>(46);
                    __builder3.AddAttribute(47, "AutoComplete", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#line 26 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                             false

#line default
#line hidden
                    ));
                    __builder3.AddAttribute(48, "Placeholder", "Enter Your Email Address ");
                    __builder3.AddAttribute(49, "style", "width: 100%");
                    __builder3.AddAttribute(50, "Name", "EmailAddress");
                    __builder3.AddAttribute(51, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#line 26 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                                                                                                               user.EmailAddress

#line default
#line hidden
                    ));
                    __builder3.AddAttribute(52, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => user.EmailAddress = __value, user.EmailAddress))));
                    __builder3.AddAttribute(53, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => user.EmailAddress));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(54, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(55);
                    __builder3.AddAttribute(56, "Component", "EmailAddress");
                    __builder3.AddAttribute(57, "Text", "Email Address Is Required");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(58, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenEmailValidator>(59);
                    __builder3.AddAttribute(60, "Component", "EmailAddress");
                    __builder3.AddAttribute(61, "Text", "Please Enter Valid Email Address");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(62, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(63, "\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(64, "\n            ");
                    __builder3.OpenElement(65, "div");
                    __builder3.AddAttribute(66, "class", "row");
                    __builder3.AddMarkupContent(67, "\n              ");
                    __builder3.OpenElement(68, "div");
                    __builder3.AddAttribute(69, "class", "col offset-sm-3");
                    __builder3.AddMarkupContent(70, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(71);
                    __builder3.AddAttribute(72, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#line 36 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                           ButtonStyle.Primary

#line default
#line hidden
                    ));
                    __builder3.AddAttribute(73, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#line 36 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                                                            ButtonType.Submit

#line default
#line hidden
                    ));
                    __builder3.AddAttribute(74, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#line 36 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                                                                                     ButtonSize.Medium

#line default
#line hidden
                    ));
                    __builder3.AddAttribute(75, "Text", "Reset ");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(76, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(77);
                    __builder3.AddAttribute(78, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#line 38 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                           ButtonStyle.Light

#line default
#line hidden
                    ));
                    __builder3.AddAttribute(79, "Text", "Cancel");
                    __builder3.AddAttribute(80, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 38 "C:\SoccerLeagueTransfer\server\Pages\ResetUserPassword.razor"
                                                                                    Button2Click

#line default
#line hidden
                    )));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(81, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(82, "\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(83, "\n          ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(84, "\n      ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(85, "\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(86, "\n  ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591