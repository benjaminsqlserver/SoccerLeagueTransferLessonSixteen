using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using SoccerLeagueTransferApp.Data;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class ConfirmDeleteTransferTypeComponent
    {

        //custom method to delete a transfer type

        private async Task MuyikDeleteTransferType()
        {
            try
            {
                //delete transfer type record by passing in the transfertypeID of the selected record to the delete method as parameter
                await ConData.DeleteTransferType(TransferTypeID);

                //redirect to transfer types list page
                UriHelper.NavigateTo("transfer-types", true);
            }
            catch (Exception)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Transfer Type Delete Error", "An Error Occurred While You Were Deleting Transfer Type.Please Contact System Admin", 5000);
            }
        }


        //implement access control for this page

        [Inject]

        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public async Task CheckUserStatus()//it checks if anonymous user has signed in
        {
            try
            {
                var userState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

                if (userState.User.Claims.Any() && userState.User.IsInRole("SiteAdmin"))// check if user has any claims and see if user belongs to site admin role
                {

                    var conDataGetTransferTypeByTransferTypeIdResult = await ConData.GetTransferTypeByTransferTypeId(TransferTypeID);
                    transfertype = conDataGetTransferTypeByTransferTypeIdResult;
                }
                else
                {
                    UriHelper.NavigateTo("transfer-types", true);
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Application Error", "An Error Has Occurred.Please Contact Site Admin", 5000);
            }

        }

    }
}
