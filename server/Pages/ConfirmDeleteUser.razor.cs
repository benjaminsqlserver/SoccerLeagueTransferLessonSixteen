using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using SoccerLeagueTransferApp.Models.ConData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SoccerLeagueTransferApp.Data;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class ConfirmDeleteUserComponent
    {

        [Inject]

        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public async Task CheckUserStatus()//it checks if anonymous user has signed in
        {
            try
            {
                var userState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

                if (userState.User.Claims.Any() && userState.User.IsInRole("SiteAdmin"))// check if user has any claims and see if user belongs to site admin role
                {
                    //do nothing

                }
                else
                {
                    UriHelper.NavigateTo("login");//redirect to login page
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Application Error", "An Error Has Occurred.Please Contact Site Admin", 5000);
            }

        }

        //method to load current user roles

        private async Task MuyikGetCurrentUserRoles()
        {
            var usersInRoles = await ConData.MuyikGetExistingUserRoles(user.UserID);
            

            if (usersInRoles.Any())
            {

                foreach (UsersInRole userInRole in usersInRoles)
                {
                    userRoleList = userRoleList + userInRole.Role.RoleName + " ";
                    
                }

                
            }
        }



        //method to delete user

        private async Task MuyikDeleteUser()
        {
            try
            {
                await ConData.DeleteUser(user.UserID);
                UriHelper.NavigateTo("users", true);
            }
            catch(Exception ex)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Error On User Delete", "An Error Occurred While You Were Deleting This User.Please Contact System Admin");
            }
            
        }

        private async Task MuyikCancel()
        {
            UriHelper.NavigateTo("users", true);
        }
    }
}
