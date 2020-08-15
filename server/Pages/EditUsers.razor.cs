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
    public partial class EditUsersComponent
    {
        //custom custom to edit an application user and associated role list

        private async Task MuyikEditUser()
        {
            try
            {
                //check if user has been assigned to any role
                if (userRoleNames.Any())
                {
                    //delete existing user roles

                    long rolesCount = await ConData.MuyikDeleteExistingUserRoles(user.UserID); //get roles count after deleting existing userRoles

                    if (rolesCount > 0)//this implies that there was an error while we were deleting existing user roles
                    {
                        NotificationService.Notify(NotificationSeverity.Error, "Error On User Update", "An Error Occurred While You Were Updating This User.Please Contact System Admin");
                    }
                    else//success in deleting existing user roles
                    {

                        List<UsersInRole> usersInRoles = new List<UsersInRole>();//create new userInroles list
                        foreach (string roleName in userRoleNames)//iterate over all rolenames
                        {
                            Role role = await ConData.MuyikGetRoleByName(roleName);//check if a role which matches current role exists in datastore
                            if (role != null && role.RoleID > 0)
                            {
                                usersInRoles.Add(new UsersInRole { RoleID = role.RoleID, UserID=user.UserID });//create new user in role object and add it to userInRoles list
                            }
                        }

                        //save user in roles list

                        await ConData.MuyikSaveNewRoleList(usersInRoles);

                       

                        //edit current user object

                        await ConData.UpdateUser(user.UserID, user);

                        //redirect to users list page and reload it from the server

                        UriHelper.NavigateTo("users",true);




                    }

                }
            }
            catch(Exception ex)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Error On User Update", "An Error Occurred While You Were Updating This User.Please Contact System Admin");
            }
            
        }

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
            var userRoleNames1 = new List<string>();

            if(usersInRoles.Any())
            {
                foreach(UsersInRole userInRole in usersInRoles)
                {
                    userRoleNames1.Add(userInRole.Role.RoleName);
                }

                userRoleNames = userRoleNames1;
            }
        }
    }
}
