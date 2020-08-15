using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SoccerLeagueTransferApp.Data;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class ConfirmDeletePlayerPositionComponent
    {

        //custom method to delete a player position

        private async Task MuyikDeletePlayerPosition()
        {
            try
            {
                //delete player position record by passing in the positionID of the selected record to the delete method as parameter
                await ConData.DeletePlayerPosition(PositionID);

                //redirect to player position list page
                UriHelper.NavigateTo("player-positions", true);
            }
            catch(Exception)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Position Delete Error", "An Error Occurred While You Were Deleting Player Position.Please Contact System Admin", 5000);
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
                    var conDataGetPlayerPositionByPositionIdResult = await ConData.GetPlayerPositionByPositionId(PositionID);
                    playerposition = conDataGetPlayerPositionByPositionIdResult;

                }
                else
                {
                    UriHelper.NavigateTo("player-positions",true);//redirect to login page
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Application Error", "An Error Has Occurred.Please Contact Site Admin", 5000);
            }

        }

    }
}
