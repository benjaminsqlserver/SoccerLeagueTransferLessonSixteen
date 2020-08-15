using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SoccerLeagueTransferApp.Data;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class ConfirmDeletePlayerTransferComponent
    {
        ISessionStorageService sessionStorage { get; set; }

        //implement access control for this page

        [Inject]

        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public async Task CheckUserStatus()//it checks if anonymous user has signed in
        {
            try
            {
                var userState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

                if (userState.User.Claims.Any() && (userState.User.IsInRole("SiteAdmin") || userState.User.IsInRole("Club Manager")))// check if user has any claims and see if user belongs to site admin role or club manager role
                {


                    //get the teamID of currently logged on user

                    int? teamID = await sessionStorage.GetItemAsync<int?>("TeamID");

                    if (userState.User.IsInRole("Club Manager"))//if currently logged on user is a club manager
                    {
                        //check if the teamID of the club manager matches the current club id of selected player transfer record

                        if (playertransfer.OriginatingClubID != teamID)
                        {
                            UriHelper.NavigateTo("player-transfers", true);
                        }
                    }




                }
                else
                {
                    UriHelper.NavigateTo("player-transfers", true);
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Application Error", "An Error Has Occurred.Please Contact Site Admin", 5000);
            }

        }


        //custom method to delete a transfer

        private async Task MuyikDeleteTransfer()
        {
            try
            {
                await ConData.DeletePlayerTransfer(TransferID);//delete selected transfer record from the grid

                //redirect to list page

                UriHelper.NavigateTo("player-transfers", true);
            }
            catch(Exception)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Transfer Delete Error!", "An Error Occurred While Deleting Transfer Record!", 7000);
            }
           
        }

        


    }
}
