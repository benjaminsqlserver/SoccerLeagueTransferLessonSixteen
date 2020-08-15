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
    public partial class ClubDetailComponent
    {

        [Inject]

        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private async Task CheckUserStatus()//it checks if anonymous user has signed in
        {
            var userState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            if (userState.User.Claims.Any())//we want all logged in users to be able to access this page
            {
                if (userState.User.IsInRole("SiteAdmin"))// see if user belongs to site admin role
                {
                    canEdit = true;

                }

            }
            else
            {
                UriHelper.NavigateTo("login");
            }
        }


        

    }
}
