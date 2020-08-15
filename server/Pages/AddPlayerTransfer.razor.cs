using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SoccerLeagueTransferApp.Data;
using Blazored.SessionStorage;
using SoccerLeagueTransferApp.Models.ConData;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class AddPlayerTransferComponent
    {
        //implement access control for this page

        [Inject]

        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public async Task CheckUserStatus()//it checks if anonymous user has signed in
        {
            try
            {
                var userState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

                if (userState.User.Claims.Any() && (userState.User.IsInRole("SiteAdmin")|| userState.User.IsInRole("Club Manager")))// check if user has any claims and see if user belongs to site admin role or club manager role
                {

                    
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

        [Inject]

        ISessionStorageService sessionStorage { get; set; }
        private async Task MuyikGetPlayerList()
        {
            //get the teamID of currently logged on user

            int? teamID = await sessionStorage.GetItemAsync<int?>("TeamID");

            getPlayersResult = await ConData.MuyikGetPlayers(teamID);
            originatingClubList = await ConData.MuyikGetOriginatingClubList(teamID);

            if (teamID > 0)
            {
                playertransfer.OriginatingClubID = teamID;
                
            }


        }


        //custom method to transfer player

        private async Task MuyikTransferPlayer()
        {
            try
            {
                var conDataCreatePlayerTransferResult = await ConData.CreatePlayerTransfer(playertransfer);
                //update player's current club
                await ConData.MuyikChangePlayerClub(playertransfer);


                //redirect to list page 

                UriHelper.NavigateTo("player-transfers", true);
            }
            catch (System.Exception conDataCreatePlayerTransferException)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new PlayerTransfer!",7000);
            }
        }


        private async Task ValidateTransferDate()
        {
            if(playertransfer.TransferDate.Date > DateTime.Now.Date)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Transfer Date Error", "Transfer Date Can Not Be In The Future", 5000);
                return;
            }
        }
    }
}
