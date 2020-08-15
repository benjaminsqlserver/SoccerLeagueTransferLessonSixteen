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
using System.Runtime.CompilerServices;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class ChangeYourPasswordComponent
    {
        [Inject]

        ISessionStorageService sessionStorage { get; set; }

        [Inject]

        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private async Task CheckUserStatus()//it checks if anonymous user has signed in
        {
            try
            {
                var userState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

                if (userState.User.Claims.Any())// check if user has any claims (if user is logged in)
                {
                    int userID = await sessionStorage.GetItemAsync<int>("UserID");//get userID from session manager


                    //get user detail from data store



                    user = await ConData.MuyikGetUserByUserID(userID);

                    //get user roles from data store

                    userRoleNames = await ConData.MuyikGetRolesList(user.UserID);

                    if(userRoleNames.Any())// check if any role name was returned
                    {
                        //iterate over each role name
                        foreach(String roleName in userRoleNames)
                        {
                            userRoles = userRoles + roleName + " ";
                        }
                    }

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



        //method to reset password controls

        private async Task ResetPasswordControls()
        {
            user.Password = String.Empty;
            confirmPassword = String.Empty;
        }

        //method to change user password

        private async Task ChangeUserPassword()
        {
            try
            {
                await ConData.MuyikChangeUserPassword(user);//call change user password routine in condata service

                //display success message

                NotificationService.Notify(NotificationSeverity.Success, "Password Change Success!", "You Have Successfully Changed Your Password", 6000);

                //reset password controls

                await ResetPasswordControls();
            }
            catch(Exception)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Password Change Error", "An Error Occurred While Changing Your Password.Contact System Admin", 5000);
            }
        }

    }
}
